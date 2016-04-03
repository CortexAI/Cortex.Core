using Cortex.Core.Model;

namespace Cortex.Core.Nodes.Math
{
    public abstract class MathNode : Node
    {
        public IInputPin<double> A => _a;
        public IInputPin<double> B => _b;

        private readonly InputPin<double> _a;
        private readonly InputPin<double> _b;
        private readonly OutputPin<double> _output = new OutputPin<double>("Result"); 

        protected MathNode()
        {
            _a = new InputPin<double>("A");
            _b = new InputPin<double>("B");
            AddInputPin(_a);
            AddInputPin(_b);
            AddOutputPin(_output);
        }

        protected override void Handler()
        {
            _output.Emit(Calc(_a.Get(),_b.Get()));
        }

        public abstract double Calc(double a, double b);
    }
}