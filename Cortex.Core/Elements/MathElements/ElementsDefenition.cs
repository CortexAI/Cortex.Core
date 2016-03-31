﻿using System.ComponentModel.Composition;
using Cortex.Core.Model;

namespace Cortex.Core.Elements.MathElements
{
    internal class ElementsDefenition
    {
        [Export] 
        public static ElementGroupDefenition MathElements 
            = new ElementGroupDefenition(WellKnownGroups.Common, "Math Elements");

        [Export] 
        public static ElementItemDefenition AddElement =
            new ElementItemDefenition<AdditionElement>(MathElements, "Addition (+)", null, "Simple addition");

        [Export] 
        public static ElementItemDefenition Subtract =
            new ElementItemDefenition<SubtractionElement>(MathElements, "Subtraction (-)", null, "Simple subtraction");

        [Export] 
        public static ElementItemDefenition Division =
            new ElementItemDefenition<DivisionElement>(MathElements, "Division (/)", null, "Simple division");

        [Export] 
        public static ElementItemDefenition Multiply =
            new ElementItemDefenition<MultiplyElement>(MathElements, "Multiplication (*)", null, "Simple multiplication");

        [Export]
        public static ElementItemDefenition Random =
            new ElementItemDefenition<RandomElement>(MathElements, "Random", null, "Generates random value in (0,1) range");
    }
}