using Cortex.Core.Model;

namespace Cortex.Core.Nodes.Logic
{
    public abstract class Predicate : Node
    {
        private readonly OutputPin<bool> _res = new OutputPin<bool>("Result");
        protected readonly InputPin<double> _a;
        protected readonly InputPin<double> _b;

        protected Predicate()
        {
            _a = new InputPin<double>("A");
            _b = new InputPin<double>("B");
            AddInputPin(_a);
            AddInputPin(_b);
            AddOutputPin(_res);
        }

        protected override void Handler()
        {
            _res.Emit(Process(_a.Take(),_b.Take()));
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