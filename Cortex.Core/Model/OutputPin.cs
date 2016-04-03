using System;
using System.Collections.Generic;
using Cortex.Core.Model.Utilities;

namespace Cortex.Core.Model
{
    public class OutputPin<T> : IOutputPin<T>
    {
        public void Emit(T o)
        {
            foreach (var listener in _listeners)
            {
                listener.Enqueue(o);
            }
        }

        public string Name { get; }
        public Type Type => typeof(T);
        public IEnumerable<IInputPin> Listeners => _listeners;

        private readonly List<IInputPin> _listeners = new List<IInputPin>();

        public OutputPin(string name)
        {
            Name = name;
        }

        public void AddListener(IInputPin input)
        {
            if (input != null)
            {
                if (typeof (T).IsCastableTo(input.Type))
                {
                    _listeners.Add(input);
                }
            }
            else
            {
                throw new InvalidOperationException("Can't attach input pin to this");
            }
        }

        public void AddListener<TInput>(IInputPin<TInput> input)
        {
            if (input != null)
            {
                if (typeof (T).IsCastableTo(typeof (TInput)))
                {
                    _listeners.Add(input);
                }
            }
            else
            {
                throw new InvalidOperationException("Can't attach input pin to this");
            }
        }

        public void RemoveListener(IInputPin input)
        {
            if (input != null && _listeners.Contains(input))
            {
                _listeners.Remove(input);
            }
        }
    }
}