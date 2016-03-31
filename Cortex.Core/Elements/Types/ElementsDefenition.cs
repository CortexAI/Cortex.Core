using System.ComponentModel.Composition;
using Cortex.Core.Model;

namespace Cortex.Core.Elements.Types
{
    internal class ElementsDefenition
    {
        [Export] 
        public static ElementGroupDefenition Types = 
            new ElementGroupDefenition(WellKnownGroups.Common, "Types");

        [Export] 
        public static ElementItemDefenition Bool =
            new ElementItemDefenition<NetTypeElement<bool>>(Types, "Bool", null, "Bool element");

        [Export] 
        public static ElementItemDefenition Double =
            new ElementItemDefenition<NetTypeElement<double>>(Types, "Double", null, "Double element");

        [Export] 
        public static ElementItemDefenition Int =
            new ElementItemDefenition<NetTypeElement<int>>(Types, "Integer", null, "Int element");

        [Export] 
        public static ElementItemDefenition String =
            new ElementItemDefenition<NetTypeElement<string>>(Types, "String", null, "String element");
    }
}