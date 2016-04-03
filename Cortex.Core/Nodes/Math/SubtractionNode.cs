namespace Cortex.Core.Nodes.Math
{
    public class SubtractionNode : MathNode
    {
        public override double Calc(double a, double b)
        {
            return a - b;
        }
    }
}