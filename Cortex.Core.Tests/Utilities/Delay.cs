using System.Threading;
using Cortex.Core.Model;
using Cortex.Core.Model.Nodes;
using Cortex.Core.Model.Pins;

namespace Cortex.Core.Tests.Utilities
{
    class Delay : BaseNode
    {
        private readonly InputPin<object> _input;
        private readonly OutputPin<object> _output;
        private readonly int _amount;

        public Delay(int amount = 1000)
        {
            _amount = amount;
            _input = new InputPin<object>("Input");
            _output = new OutputPin<object>("Output");
            AddInputPin(_input);
            AddOutputPin(_output);
        }

        protected override void Handler()
        {
            var o = _input.Take();
            Thread.Sleep(_amount);
            _output.Emit(o);
        }
    }
}
