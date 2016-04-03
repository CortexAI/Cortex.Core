using System.Threading;
using Cortex.Core.Model;

namespace Cortex.Core.Nodes.Logic
{
    public class Counter : Node
    {
        private readonly OutputPin<int> _counterPin = new OutputPin<int>("Count");

        private readonly object _valueLock = new object();
        private int _count;

        public int Count
        {
            get
            {
                lock (_valueLock)
                {
                    return _count;
                }
            }
            set
            {
                lock (_valueLock)
                {
                    _count = value;
                }
            }
        }

        public Counter()
        {
            AddInputPin(new InputPin<object>("Touch"));
            AddOutputPin(_counterPin);
        }

        protected override void Handler()
        {
            Count++;
            _counterPin.Emit(Count);
        }

        public override void Init(CancellationToken token)
        {
            Count = 0;
            base.Init(token);
        }
    }
}