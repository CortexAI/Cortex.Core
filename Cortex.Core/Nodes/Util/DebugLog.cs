using System;
using Cortex.Core.Model;
using Cortex.Core.Model.Nodes;
using Cortex.Core.Model.Pins;

namespace Cortex.Core.Nodes.Util
{
    public class DebugLog : BaseNode
    {
        private readonly InputPin<object> _input = new InputPin<object>("Object");

        public DebugLog()
        {
            AddInputPin(_input);   
        }

        protected override void Handler()
        {
            var o = _input.Take();
            System.Diagnostics.Debug.WriteLine(o);
            Console.WriteLine(o);
        }
    }
}