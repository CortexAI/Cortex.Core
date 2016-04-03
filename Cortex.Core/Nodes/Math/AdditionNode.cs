namespace Cortex.Core.Nodes.Math
{
    public class AdditionNode : MathNode
    {
        public override double Calc(double a, double b)
        {
            return a + b;
        }
    }
}