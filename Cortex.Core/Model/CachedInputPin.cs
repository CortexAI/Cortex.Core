using System;

namespace Cortex.Core.Model
{
    public class CachedInputPin<T> : IInputPin
    {
        public string Name { get; private set; }
        public Type Type => typeof(T);
        public T CachedValue { get; private set; }

        private readonly Action<IInputPin, T> _handler;

        public CachedInputPin(string name, Action<IInputPin, T> handler = null, T initial = default(T))
        {
            Name = name;
            _handler = handler;
            CachedValue = initial;
        }

        public void Handle(object o)
        {
            CachedValue = (T) o;
            _handler?.Invoke(this, CachedValue);
            AfterPinProcessed?.Invoke(this, CachedValue);
        }

        public event Action<IInputPin, object> AfterPinProcessed;
    }
}