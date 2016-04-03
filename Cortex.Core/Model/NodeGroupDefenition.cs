namespace Cortex.Core.Model
{
    public class NodeGroupDefenition
    {
        public NodeGroupDefenition(string name)
        {
            Name = name;
        }

        public NodeGroupDefenition(NodeGroupDefenition parentGroup, string name)
        {
            Name = name;
            ParentGroup = parentGroup;
        }

        public string Name { get; private set; }
        public NodeGroupDefenition ParentGroup { get; private set; }
    }
}