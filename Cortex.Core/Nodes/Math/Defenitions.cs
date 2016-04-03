using System.ComponentModel.Composition;
using Cortex.Core.Model;

namespace Cortex.Core.Nodes.Math
{
    internal class Defenitions
    {
        [Export] 
        public static NodeGroupDefenition MathNodes 
            = new NodeGroupDefenition(WellKnownGroups.Common, "Math Elements");

        [Export] 
        public static NodeDefenition AddElement =
            new NodeDefenition<AdditionNode>(MathNodes, "Addition (+)", null, "Simple addition");

        [Export] 
        public static NodeDefenition Subtract =
            new NodeDefenition<SubtractionNode>(MathNodes, "Subtraction (-)", null, "Simple subtraction");

        [Export] 
        public static NodeDefenition Division =
            new NodeDefenition<DivisionNode>(MathNodes, "Division (/)", null, "Simple division");

        [Export] 
        public static NodeDefenition Multiply =
            new NodeDefenition<MultiplyNode>(MathNodes, "Multiplication (*)", null, "Simple multiplication");

        [Export]
        public static NodeDefenition Random =
            new NodeDefenition<RandomNode>(MathNodes, "Random", null, "Generates random value in (0,1) range");
    }
}