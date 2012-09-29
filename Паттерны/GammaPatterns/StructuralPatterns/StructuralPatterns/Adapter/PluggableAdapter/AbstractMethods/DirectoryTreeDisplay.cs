namespace StructuralPatterns.Adapter.PluggableAdapter.AbstractMethods
{
    using System;
    using System.Collections.Generic;

    public class DirectoryTreeDisplay : TreeDisplay
    {
        public override GraphicNode CreateGraphicNode(Node node)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Node> GetChildren(Node node)
        {
            return new List<Node>(5);
        }
    }
}

