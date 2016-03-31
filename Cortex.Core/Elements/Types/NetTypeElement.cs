using Cortex.Core.Model;
using Cortex.Core.Model.Serialization;

namespace Cortex.Core.Elements.Types
{
    public class NetTypeElement<T> : BaseElement
    {
        private readonly OutputPin<T> _valuePin = new OutputPin<T>("Value");
        
        public NetTypeElement()
        {
            AddOutputPin(_valuePin);
            Value = default(T);
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

        public override void Init()
        {
            _valuePin.Emit(Value);
        }
    }
}