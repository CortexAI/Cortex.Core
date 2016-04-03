using System.ComponentModel.Composition;
using Cortex.Core.Model;

namespace Cortex.Core.Nodes.Logic
{
    internal class Defenitions
    {
        [Export] 
        public static NodeGroupDefenition LogicNodes = 
            new NodeGroupDefenition(WellKnownGroups.Common, "Logic");

        [Export] public static NodeDefenition Repeat =
            new NodeDefenition<Repeat>(LogicNodes, "Repeat", null, "Simple 'For' loop");

        [Export] public static NodeDefenition Condition =
            new NodeDefenition<Branch>(LogicNodes, "Branch", null, "Branching based on condition");

        [Export]
        public static NodeDefenition Counter =
    new NodeDefenition<Counter>(LogicNodes, "Counter", null, "Counting");

        [Export]
        public static NodeDefenition Greater =
            new NodeDefenition<Greater>(LogicNodes, "Greater", null, "A is greater than B (A > B)");

        [Export]
        public static NodeDefenition GreaterEq =
            new NodeDefenition<GreaterEq>(LogicNodes, "Greater or equal", null, "A is greater or equal than B (A >= B)");

        [Export]
        public static NodeDefenition Less =
            new NodeDefenition<Less>(LogicNodes, "Less", null, "A is lesser than B (A < B)");

        [Export]
        public static NodeDefenition LessEq =
            new NodeDefenition<LessOrEq>(LogicNodes, "Lesser or equal", null, "A is lesser or equal than B (A <= B)");

        [Export]
        public static NodeDefenition Eq =
            new NodeDefenition<Eq>(LogicNodes, "Equal", null, "A is equal B (A == B)");

        [Export]
        public static NodeDefenition NotEq =
            new NodeDefenition<NotEqual>(LogicNodes, "Not equal", null, "A is not equal B (A != B)");
    }
}