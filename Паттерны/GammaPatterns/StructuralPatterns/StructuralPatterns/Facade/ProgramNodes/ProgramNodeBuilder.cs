namespace StructuralPatterns.Facade.ProgramNodes
{
    using System;

    public class ProgramNodeBuilder
    {
        private ProgramNode root;

        public ProgramNode GetRootNode()
        {
            return this.root;
        }

        public virtual ProgramNode NewAssigment(ProgramNode variable, ProgramNode expression)
        {
            return new ExpressionNode();
        }

        public virtual ProgramNode NewCondition(ProgramNode condition, ProgramNode truePart, ProgramNode falsePart)
        {
            return new ExpressionNode();
        }

        public virtual ProgramNode NewReturnStatement(ProgramNode value)
        {
            return new StatementNode();
        }

        public virtual ProgramNode NewVariable(char variableName)
        {
            return new StatementNode();
        }
    }
}

