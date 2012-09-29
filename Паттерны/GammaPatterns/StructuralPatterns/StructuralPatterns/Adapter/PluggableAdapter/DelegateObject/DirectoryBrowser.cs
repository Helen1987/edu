namespace StructuralPatterns.Adapter.PluggableAdapter.DelegateObject
{
    using System;
    using System.Collections.Generic;

    public class DirectoryBrowser : ITreeAccessorDelegate
    {
        public GraphicNode CreateGraphicNode(TreeDisplay tree, Node node)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Node> GetChildren(TreeDisplay tree, Node node)
        {
            Console.WriteLine("Return children nodes from DirectoryBrowser");
            return new List<Node>(0);
        }
    }
}

