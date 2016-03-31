using Cortex.Core.Model;

namespace Cortex.Core.Elements.Logic
{
    public class Repeat : BaseElement
    {
        private readonly OutputPin<int> _index = new OutputPin<int>("Index");

        public Repeat()
        {
            AddInputPin(new InputPin<int>("Times", Handler));
            AddOutputPin(_index);
        }

        private void Handler(IInputPin inputPin, int count)
        {
            for (var i = 0; i < count; i++)
                _index.Emit(i);
        }
    }
}