using System;
using System.Collections.Generic;

namespace Cortex.Core.Model
{
    public class OutputPin<T> : IOutputPin<T>
    {
        public IEnumerable<IInputPin> Listeners => _listeners;
        public string Name { get; private set; }
        public Type Type => typeof (T);

        private readonly List<IInputPin> _listeners = new List<IInputPin>();

        public OutputPin(string name)
        {
            Name = name;
        }

        public void Emit(T o)
        {
            foreach (var endPoint in _listeners)
            {
                endPoint.Handle(o);
            }
        }

        public void AddListener(IInputPin pin)
        {
            if (pin != null)
            {
                _listeners.Add(pin);
            }
            else
            {
                throw new InvalidOperationException("Can't attach input pin to this");
            }
        }

        public void RemoveListener(IInputPin pin)
        {
            if (pin != null && _listeners.Contains(pin))
            {
                _listeners.Remove(pin);
            }
        }
    }
}