namespace StructuralPatterns.Facade.Generators
{
    using StructuralPatterns.Facade;
    using StructuralPatterns.Facade.ProgramNodes;
    using System;

    public class CodeGenerator
    {
        private BytecodeStream output;

        protected CodeGenerator(BytecodeStream stream)
        {
            this.output = stream;
        }

        public virtual void Visit(ExpressionNode expression)
        {
        }

        public virtual void Visit(StatementNode statement)
        {
        }
    }
}

