using System.Threading;
using Cortex.Core.Model;
using Cortex.Core.Model.Nodes;
using Cortex.Core.Model.Pins;

namespace Cortex.Core.Nodes.Util
{
    internal class Sleep : BaseNode
    {
        private readonly InputPin<object> _touch = new InputPin<object>("Start sleep");
        private readonly InputPin<int> _time = new InputPin<int>("Time");
        private readonly OutputPin<object> _output = new OutputPin<object>("End");

        public Sleep()
        {
            AddInputPin(_touch);
            AddInputPin(_time);
            AddOutputPin(_output);
        }

        protected override void Handler()
        {
            Thread.Sleep(_time.Take());
            _output.Emit(null);
        }
    }
}