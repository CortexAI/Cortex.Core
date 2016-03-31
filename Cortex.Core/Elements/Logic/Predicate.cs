using Cortex.Core.Model;

namespace Cortex.Core.Elements.Logic
{
    public abstract class Predicate : BaseElement
    {
        private readonly OutputPin<bool> _res = new OutputPin<bool>("Result");
        protected readonly CachedInputPin<double> _a;
        protected readonly CachedInputPin<double> _b;

        protected Predicate()
        {
            _a = new CachedInputPin<double>("A", Handler);
            _b = new CachedInputPin<double>("B", Handler);
            AddInputPin(_a);
            AddInputPin(_b);
            AddOutputPin(_res);
        }

        private void Handler(IInputPin inputPin, double value)
        {
            _res.Emit(Process(_a.CachedValue,_b.CachedValue));
        }

        protected abstract bool Process(double a, double b);
    }

    public class Greater : Predicate
    {
        protected override bool Process(double a, double b) => a > b;
    }

    public class GreaterEq : Predicate
    {
        protected override bool Process(double a, double b) => a >= b;
    }

    public class Less : Predicate
    {
        protected override bool Process(double a, double b) => a < b;
    }

    public class LessOrEq : Predicate
    {
        protected override bool Process(double a, double b) => a <= b;
    }

    public class Eq : Predicate
    {
        protected override bool Process(double a, double b) => a == b;
    }

    public class NotEqual : Predicate
    {
        protected override bool Process(double a, double b) => a != b;
    }
}