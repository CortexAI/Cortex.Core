using Cortex.Core.Model;

namespace Cortex.Core.Nodes.Logic
{
    public class Branch : Node
    {
        private readonly InputPin<bool> _condition = new InputPin<bool>("Value");
        private readonly OutputPin<bool> _onTrue = new OutputPin<bool>("True");
        private readonly OutputPin<bool> _onFalse = new OutputPin<bool>("False");

        public Branch()
        {
            var condition = new InputPin<bool>("Value");
            AddInputPin(condition);
            AddOutputPin(_onTrue);
            AddOutputPin(_onFalse);
        }

        protected override void Handler()
        {
            if (_condition.Take())
                _onTrue.Emit(true);
            else
                _onFalse.Emit(false);
        }
    }
}