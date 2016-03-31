using System;

namespace Cortex.Core.Model
{
    public class InputPin<T> : IInputPin
    {
        public string Name { get; }
        public Type Type => typeof(T);

        private readonly Action<IInputPin, T> _handler;

        public InputPin(string name, Action<IInputPin, T> handler)
        {
            Name = name;
            _handler = handler;
        }

        public void Handle(object o)
        {
            _handler?.Invoke(this, (T)o);
            AfterPinProcessed?.Invoke(this, o);
        }

        public event Action<IInputPin, object> AfterPinProcessed;
    }

    class TouchPin : IInputPin
    {
        public string Name { get; }
        public Type Type => null;
        private readonly Action<IInputPin> _handler;

        public TouchPin(string name, Action<IInputPin> handler)
        {
            Name = name;
            _handler = handler;
        }

        public void Handle(object o)
        {
            _handler?.Invoke(this);
            AfterPinProcessed?.Invoke(this, o);
        }

        public event Action<IInputPin, object> AfterPinProcessed;
    }
}