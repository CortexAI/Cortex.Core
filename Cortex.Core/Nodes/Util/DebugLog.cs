using System;
using Cortex.Core.Model;

namespace Cortex.Core.Nodes.Util
{
    public class DebugLog : Node
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