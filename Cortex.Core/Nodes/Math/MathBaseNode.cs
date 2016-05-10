using Cortex.Core.Model;
using Cortex.Core.Model.Nodes;
using Cortex.Core.Model.Pins;

namespace Cortex.Core.Nodes.Math
{
    public abstract class MathBaseNode : BaseNode
    {
        public IInputPin<double> A => _a;
        public IInputPin<double> B => _b;

        private readonly InputPin<double> _a;
        private readonly InputPin<double> _b;
        private readonly OutputPin<double> _output = new OutputPin<double>("Result"); 

        protected MathBaseNode()
        {
            _a = new InputPin<double>("A");
            _b = new InputPin<double>("B");
            AddInputPin(_a);
            AddInputPin(_b);
            AddOutputPin(_output);
        }

        protected override void Handler()
        {
            _output.Emit(Calc(_a.Take(),_b.Take()));
        }

        public abstract double Calc(double a, double b);
    }
}