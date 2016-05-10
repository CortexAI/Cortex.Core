using System;
using Cortex.Core.Model;
using Cortex.Core.Model.Nodes;
using Cortex.Core.Model.Pins;

namespace Cortex.Core.Nodes.Math
{
    public class Random : BaseNode
    {
        private readonly OutputPin<double> _output = new OutputPin<double>("Random");
        private readonly System.Random _random;

        public Random()
        {
            AddInputPin(new InputPin<object>("Generate"));
            AddOutputPin(_output);
            _random = new System.Random();
        }

        protected override void Handler()
        {
            _output.Emit(_random.NextDouble());
        }
    }
}