using System;
using System.Threading;
using Cortex.Core.Model;
using Cortex.Core.Model.Serialization;

namespace Cortex.Core.Nodes.Types
{
    public class NetTypeNode<T> : Node
    {
        private readonly OutputPin<T> _valuePin = new OutputPin<T>("Value");

        public OutputPin<T> Output => _valuePin;
        
        public NetTypeNode()
        {
            AddOutputPin(_valuePin);
            Value = default(T);
        }

        public NetTypeNode(T value)
        {
            AddOutputPin(_valuePin);
            Value = value;
        }

        public T Value { get; set; }

        public override void Save(IPersisterWriter writer)
        {
            writer.Set("Value", Value);
        }

        public override void Load(IPersisterReader reader)
        {
            Value = reader.Get<T>("Value");
        }

        protected override void Handler()
        {
            throw new InvalidOperationException();
        }

        public override void Init(CancellationToken token)
        {
            _valuePin.Emit(Value);
        }
    }
}