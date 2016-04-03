using System.ComponentModel.Composition;
using Cortex.Core.Model;

namespace Cortex.Core.Nodes.Types
{
    internal class Defenitions
    {
        [Export] 
        public static NodeGroupDefenition Types = 
            new NodeGroupDefenition(WellKnownGroups.Common, "Types");

        [Export] 
        public static NodeDefenition Bool =
            new NodeDefenition<NetTypeNode<bool>>(Types, "Bool", null, "Bool node");

        [Export] 
        public static NodeDefenition Double =
            new NodeDefenition<NetTypeNode<double>>(Types, "Double", null, "Double node");

        [Export] 
        public static NodeDefenition Int =
            new NodeDefenition<NetTypeNode<int>>(Types, "Integer", null, "Int node");

        [Export] 
        public static NodeDefenition String =
            new NodeDefenition<NetTypeNode<string>>(Types, "String", null, "String node");
    }
}