using System.ComponentModel.Composition;
using Cortex.Core.Model;

namespace Cortex.Core.Elements.Logic
{
    internal class ElementsDefenition
    {
        [Export] 
        public static ElementGroupDefenition LogicElements = 
            new ElementGroupDefenition(WellKnownGroups.Common, "Logic");

        [Export] public static ElementItemDefenition Repeat =
            new ElementItemDefenition<Repeat>(LogicElements, "Repeat", null, "Simple 'For' loop");

        [Export] public static ElementItemDefenition Condition =
            new ElementItemDefenition<Branch>(LogicElements, "Branch", null, "Branching based on condition");

        [Export]
        public static ElementItemDefenition Counter =
    new ElementItemDefenition<Counter>(LogicElements, "Counter", null, "Counting");

        [Export]
        public static ElementItemDefenition Greater =
            new ElementItemDefenition<Greater>(LogicElements, "Greater", null, "A is greater than B (A > B)");

        [Export]
        public static ElementItemDefenition GreaterEq =
            new ElementItemDefenition<GreaterEq>(LogicElements, "Greater or equal", null, "A is greater or equal than B (A >= B)");

        [Export]
        public static ElementItemDefenition Less =
            new ElementItemDefenition<Less>(LogicElements, "Less", null, "A is lesser than B (A < B)");

        [Export]
        public static ElementItemDefenition LessEq =
            new ElementItemDefenition<LessOrEq>(LogicElements, "Lesser or equal", null, "A is lesser or equal than B (A <= B)");

        [Export]
        public static ElementItemDefenition Eq =
            new ElementItemDefenition<Eq>(LogicElements, "Equal", null, "A is equal B (A == B)");

        [Export]
        public static ElementItemDefenition NotEq =
            new ElementItemDefenition<NotEqual>(LogicElements, "Not equal", null, "A is not equal B (A != B)");
    }
}