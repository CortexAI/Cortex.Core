using System;
using System.Diagnostics;
using Cortex.Core.Model;

namespace Cortex.Core.Elements.DebugElements
{
    public class DebugLog : BaseElement
    {
        private readonly InputPin<object> _input = new InputPin<object>("Object", Handler);

        public DebugLog()
        {
            AddInputPin(_input);   
        }

        private static void Handler(IInputPin inputPin, object o)
        {
            Debug.WriteLine(o);
            Console.WriteLine(o);
        }
    }
}