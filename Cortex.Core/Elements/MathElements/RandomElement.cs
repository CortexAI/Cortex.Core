using System;
using Cortex.Core.Model;

namespace Cortex.Core.Elements.MathElements
{
    public class RandomElement : BaseElement
    {
        private readonly OutputPin<double> _output = new OutputPin<double>("Random");
        private readonly Random _random;

        public RandomElement()
        {
            AddInputPin(new TouchPin("Generate", Handler));
            AddOutputPin(_output);
            _random = new Random();
        }

        private void Handler(IInputPin inputPin)
        {
            _output.Emit(_random.NextDouble());
        }
    }
}