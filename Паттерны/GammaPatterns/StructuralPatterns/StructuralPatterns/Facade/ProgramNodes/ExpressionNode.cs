namespace StructuralPatterns.Facade.ProgramNodes
{
    using StructuralPatterns.Facade.Generators;
    using System;
    using System.Collections.Generic;

    public class ExpressionNode : ProgramNode
    {
        private IList<ProgramNode> children;

        public override void Traverse(CodeGenerator generator)
        {
            generator.Visit(this);
            foreach (ProgramNode item in this.children)
            {
                item.Traverse(generator);
            }
        }
    }
}

