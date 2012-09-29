namespace StructuralPatterns.Adapter.PluggableAdapter.DelegateObject
{
    using System.Collections.Generic;

    public interface ITreeAccessorDelegate
    {
        GraphicNode CreateGraphicNode(TreeDisplay tree, Node node);
        IEnumerable<Node> GetChildren(TreeDisplay tree, Node node);
    }
}

