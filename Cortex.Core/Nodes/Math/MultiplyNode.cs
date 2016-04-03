namespace Cortex.Core.Nodes.Math
{
    public class MultiplyNode : MathNode
    {
        public override double Calc(double a, double b)
        {
            return a * b;
        }
    }
}