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
            var times = _times.Take();
            for (var i = 0; i < times; i++)
                _index.Emit(i);
        }
    }
}