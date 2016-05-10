namespace Cortex.Core.Nodes.Math
{
    public class Multiply
        : MathBaseNode
    {
        public override double Calc(double a, double b)
        {
            return a * b;
        }
    }
}