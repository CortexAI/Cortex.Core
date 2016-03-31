using Cortex.Core.Model;

namespace Cortex.Core.Elements.Logic
{
    public class Branch : BaseElement
    {
        private readonly OutputPin<bool> _onTrue = new OutputPin<bool>("True");
        private readonly OutputPin<bool> _onFalse = new OutputPin<bool>("False");

        public Branch()
        {
            var condition = new InputPin<bool>("Value", Handler);
            AddInputPin(condition);
            AddOutputPin(_onTrue);
            AddOutputPin(_onFalse);
        }

        private void Handler(IInputPin inputPin, bool value)
        {
            if (value)
                _onTrue.Emit(true);
            else
                _onFalse.Emit(false);
        }
    }
}