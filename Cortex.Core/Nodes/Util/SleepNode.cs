using System.Threading;
using Cortex.Core.Model;

namespace Cortex.Core.Nodes.Util
{
    internal class SleepNode : Node
    {
        private readonly InputPin<object> _touch = new InputPin<object>("Start sleep");
        private readonly InputPin<int> _time = new InputPin<int>("Time");
        private readonly OutputPin<object> _output = new OutputPin<object>("End");

        public SleepNode()
        {
            AddInputPin(_touch);
            AddInputPin(_time);
            AddOutputPin(_output);
        }

        protected override void Handler()
        {
            Thread.Sleep(_time.Get());
            _output.Emit(null);
        }

        
    }
}