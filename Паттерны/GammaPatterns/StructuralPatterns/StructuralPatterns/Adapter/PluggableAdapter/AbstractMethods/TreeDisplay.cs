namespace StructuralPatterns.Adapter.PluggableAdapter.AbstractMethods
{
    using System;
    using System.Collections.Generic;

    public abstract class TreeDisplay
    {
        private Node root;

        protected TreeDisplay()
        {
        }

        public void AddGraphicNode(GraphicNode node)
        {
        }

        public void BuildTree(Node node)
        {
            foreach (Node currentNode in this.GetChildren(node))
            {
                this.AddGraphicNode(this.CreateGraphicNode(currentNode));
                this.BuildTree(currentNode);
            }
        }

        public abstract GraphicNode CreateGraphicNode(Node node);
        public void Display()
        {
            this.BuildTree(this.root);
        }

        public abstract IEnumerable<Node> GetChildren(Node node);
    }
}

