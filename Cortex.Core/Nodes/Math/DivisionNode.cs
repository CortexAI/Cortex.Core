namespace Cortex.Core.Nodes.Math
{
    public class DivisionNode : MathNode
    {
        public override double Calc(double a, double b)
        {
            return a/b;
        }
    }
}