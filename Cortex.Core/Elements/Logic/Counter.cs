using Cortex.Core.Model;

namespace Cortex.Core.Elements.Logic
{
    public class Counter : BaseElement
    {
        private readonly OutputPin<int> _counterPin = new OutputPin<int>("Count");
        private int _count;

        public Counter()
        {
            AddInputPin(new TouchPin("Touch", Handler));
            AddOutputPin(_counterPin);
        }

        private void Handler(IInputPin inputPin)
        {
            _count++;
            _counterPin.Emit(_count);
        }

        public override void Init()
        {
            _count = 0;
        }
    }
}