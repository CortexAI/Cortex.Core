using System;

namespace Cortex.Core.Model
{
    public abstract class NodeDefenition
    {
        protected NodeDefenition(NodeGroupDefenition group, string name, Uri icon, string description)
        {
            Group = group;
            Name = name;
            IconUri = icon;
            Description = description;
        }

        public NodeGroupDefenition Group { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public Uri IconUri { get; private set; }

        public abstract INode CreateElement();
    }

    public class NodeDefenition<T> : NodeDefenition
        where T : INode, new()
    {
        public NodeDefenition(NodeGroupDefenition group, string name, Uri icon, string description)
            : base(group, name, icon, description)
        {
        }

        public override INode CreateElement()
        {
            return new T();
        }
    }
}