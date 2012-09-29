namespace StructuralPatterns.Facade
{
    using StructuralPatterns.Facade.Generators;
    using StructuralPatterns.Facade.ProgramNodes;
    using System;
    using System.IO;

    public class Compiler
    {
        public void Compile(FileStream input, BytecodeStream output)
        {
            Scanner scanner = new Scanner(input);
            ProgramNodeBuilder builder = new ProgramNodeBuilder();
            new Parser().Parse(scanner, builder);
            RISCCodeGenerator generator = new RISCCodeGenerator(output);
            builder.GetRootNode().Traverse(generator);
        }
    }
}

