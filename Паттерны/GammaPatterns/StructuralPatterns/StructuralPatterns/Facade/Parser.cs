namespace StructuralPatterns.Facade
{
    using StructuralPatterns.Facade.ProgramNodes;
    using System;

    public class Parser
    {
        public virtual void Parse(Scanner scanner, ProgramNodeBuilder nodeBuilder)
        {
        }
    }
}

