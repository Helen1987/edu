using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ConsoleApplication1.ServiceReference1;

namespace ConsoleApplication1
{
    class Dict
    {
        private DictServiceSoapClient _client;

        public Dict()
        {
            _client = new DictServiceSoapClient();

        }


        public IQueryable<string> Match
        {
            get { return new Query<string>(new MatchQueryProvider(_client)); }
        }
    }

    internal class MatchQueryProvider : QueryProvider
    {
        private readonly DictServiceSoapClient _client;

        public MatchQueryProvider(DictServiceSoapClient client)
        {
            _client = client;
        }

        public override object Execute(Expression expression)
        {
            Console.WriteLine(expression);

            expression = Evaluator.PartialEval(expression);

            Console.WriteLine(expression);


            DictParser parser = new DictParser();
            parser.Parse(expression);

            MatchInDictRequest request = new MatchInDictRequest();

            request.dictId = "wn";

            request.strategy = parser.Strategy;
            request.word = parser.Word;

            var response = _client.MatchInDict(request);
            
            return response.MatchInDictResult.Select(x=>x.Word);
        }
    }

    internal class DictParser : ExpressionVisitor
    {
        public string Strategy { get; set; }

        public string Word { get; set; }

        public void Parse(Expression expression)
        {
            base.Visit(expression);
        }

        protected override Expression VisitMethodCall(MethodCallExpression m)
        {
            if (m.Method.DeclaringType == typeof(Queryable) && m.Method.Name == "Where")
            {
                Visit(m.Arguments[1]);
            }
            else if (m.Method.DeclaringType == typeof(string))
            {
                switch (m.Method.Name)
                {
                    case "StartsWith":
                        Strategy = "prefix";
                        break;
                    case "EndsWith":
                        Strategy = "suffix";
                        break;
                    case "Contains":
                        Strategy = "substring";
                        break;
                    default:
                        throw new ArgumentException();
                }
                Visit(m.Arguments[0]);
            }
            else
            {
                throw new ArgumentException();
            }
            return m;
        }

        protected override Expression VisitConstant(ConstantExpression c)
        {
            Word = (string)c.Value;
            return c;
        }

    }
}