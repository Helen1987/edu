namespace StructuralPatterns.Facade.ProgramNodes
{
    using StructuralPatterns.Facade.Generators;
    using System;

    public class ProgramNode
    {
        protected ProgramNode()
        {
        }

        public virtual void Add(ProgramNode node)
        {
        }

        public virtual void GetSourcePosition(int line, int index)
        {
        }

        public virtual void Remove(ProgramNode node)
        {
        }

        public virtual void Traverse(CodeGenerator generator)
        {
        }
    }
}

