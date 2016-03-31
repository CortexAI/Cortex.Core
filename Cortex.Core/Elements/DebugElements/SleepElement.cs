using System.Threading;
using Cortex.Core.Model;

namespace Cortex.Core.Elements.DebugElements
{
    internal class SleepElement : BaseElement
    {
        private readonly TouchPin _touch;
        private readonly CachedInputPin<int> _time = new CachedInputPin<int>("Time");
        private readonly OutputPin<object> _output = new OutputPin<object>("End");

        public SleepElement()
        {
            AddInputPin(_touch);
            AddInputPin(_time);
            AddOutputPin(_output);
            _touch = new TouchPin("Start sleep", Handler);
        }

        private void Handler(IInputPin inputPin)
        {
            Thread.Sleep(_time.CachedValue);
            _output.Emit(null);
        }

        
    }
}