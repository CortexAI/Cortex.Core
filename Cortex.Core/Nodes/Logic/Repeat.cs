using Cortex.Core.Model;

namespace Cortex.Core.Nodes.Logic
{
    public class Repeat : Node
    {
        private readonly OutputPin<int> _index = new OutputPin<int>("Index");
        private readonly InputPin<int> _times = new InputPin<int>("Times");

        public Repeat()
        {
            AddInputPin(_times);
            AddOutputPin(_index);
        }

        protected override void Handler()
        {
            for (var i = 0; i < _times.Get(); i++)
                _index.Emit(i);
        }
    }
}