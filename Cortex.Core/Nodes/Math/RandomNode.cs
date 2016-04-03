using System;
using Cortex.Core.Model;

namespace Cortex.Core.Nodes.Math
{
    public class RandomNode : Node
    {
        private readonly OutputPin<double> _output = new OutputPin<double>("Random");
        private readonly Random _random;

        public RandomNode()
        {
            AddInputPin(new InputPin<object>("Generate"));
            AddOutputPin(_output);
            _random = new Random();
        }

        protected override void Handler()
        {
            _output.Emit(_random.NextDouble());
        }
    }
}