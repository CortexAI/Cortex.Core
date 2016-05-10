using System;
using System.Collections.Generic;
using Cortex.Core.Model.Exceptions;
using Cortex.Core.Model.Utilities;

namespace Cortex.Core.Model.Pins
{
    public abstract class BaseOutputPin<T> : IOutputPin<T>
    {
        public abstract void Emit(T o);

        public string Name { get; }
        public Type Type => typeof(T);
        public IEnumerable<IInputPin> Listeners => _listeners;

        protected readonly List<IInputPin> _listeners = new List<IInputPin>();

        protected BaseOutputPin(string name)
        {
            Name = name;
        }

        public void AddListener(IInputPin input)
        {
            if (input != null)
            {
                if (typeof(T).IsCastableTo(input.Type))
                {
                    _listeners.Add(input);
                }
            }
            else
            {
                throw new PinTypeMismatchException();
            }
        }

        public void AddListener<TInput>(IInputPin<TInput> input)
        {
            if (input != null)
            {
                if (typeof(T).IsCastableTo(typeof(TInput)))
                {
                    _listeners.Add(input);
                }
            }
            else
            {
                throw new PinTypeMismatchException();
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