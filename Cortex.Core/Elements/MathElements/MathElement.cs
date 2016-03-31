using Cortex.Core.Model;

namespace Cortex.Core.Elements.MathElements
{
    public abstract class MathElement : BaseElement
    {
        private readonly CachedInputPin<double> _a;
        private readonly CachedInputPin<double> _b;
        private readonly OutputPin<double> _output = new OutputPin<double>("Result"); 

        protected MathElement()
        {
            _a = new CachedInputPin<double>("A", Handler);
            _b = new CachedInputPin<double>("B", Handler);
            AddInputPin(_a);
            AddInputPin(_b);
            AddOutputPin(_output);
        }

        private void Handler(IInputPin inputPin, double d)
        {
            _output.Emit(Calc(_a.CachedValue, _b.CachedValue));
        }

        public abstract double Calc(double a, double b);
    }
}