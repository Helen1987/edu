namespace StructuralPatterns.Adapter.PluggableAdapter.DelegateObject
{
    using System;

    public class TreeDisplay
    {
        private Node root;
        private ITreeAccessorDelegate treeDelegate;

        protected void AddGraphicNode(GraphicNode node)
        {
        }

        public void BuildTree(Node node)
        {
            foreach (Node currentNode in this.treeDelegate.GetChildren(this, node))
            {
                this.AddGraphicNode(this.treeDelegate.CreateGraphicNode(this, currentNode));
                this.BuildTree(currentNode);
            }
        }

        public void Display()
        {
            this.BuildTree(this.root);
        }

        public void SetDelegate(ITreeAccessorDelegate treeDelegate)
        {
            this.treeDelegate = treeDelegate;
        }
    }
}

