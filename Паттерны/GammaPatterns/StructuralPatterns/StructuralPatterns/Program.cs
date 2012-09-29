namespace StructuralPatterns
{
    using StructuralPatterns.Adapter;
    using StructuralPatterns.Adapter.PluggableAdapter.AbstractMethods;
    using StructuralPatterns.Adapter.PluggableAdapter.DelegateObject;
    using StructuralPatterns.Bridge.System;
    using StructuralPatterns.Decorator;
    using StructuralPatterns.Facade;
    using StructuralPatterns.Flyweight;
    using System;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    internal class Program
    {
        private static void Main(string[] args)
        {
            IGraphicInterface adapter = new TextAdapterObject();
            adapter.Draw();
            IGraphicInterface classAdapter = new TextAdapterClass();
            classAdapter.SetPosition(0, 1);
            StructuralPatterns.Adapter.PluggableAdapter.AbstractMethods.TreeDisplay tree = new DirectoryTreeDisplay();
            tree.Display();
            StructuralPatterns.Adapter.PluggableAdapter.DelegateObject.TreeDisplay treeDelegate = new StructuralPatterns.Adapter.PluggableAdapter.DelegateObject.TreeDisplay();
            treeDelegate.SetDelegate(new DirectoryBrowser());
            treeDelegate.Display();
            tree.Display();
            IComponent element = new ConcreteDecorator(new ConcreteComponent());
            element.Display();
            View view = View.LargeIcon;
            new ApplicationWindow(view).DrawContents();
            new IconWindow(view).SetOrigin(new Point(10, 20));
            Console.WriteLine(Environment.NewLine + "Flyweight");
            GlyphContext gc = new GlyphContext();
            Font times12 = new Font("Times New Roman", 12f);
            Font timesItalic12 = new Font(times12, FontStyle.Italic);
            gc.SetFont(times12, 6);
            gc.Insert(6);
            gc.SetFont(timesItalic12, 6);
            GlyphFactory factory = new GlyphFactory();
            Row row = factory.CreateRow();
            Charachter n = factory.CreateCharacter('n');
            row.Insert(n, gc);
            row.Insert(n, gc);
            row.Draw(View.LargeIcon, gc);
            Console.WriteLine("End Flyweight" + Environment.NewLine);
            new Compiler().Compile(new FileStream("facade.txt", FileMode.OpenOrCreate), new BytecodeStream());
        }
    }
}

