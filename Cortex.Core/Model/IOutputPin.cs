using System.Collections.Generic;

namespace Cortex.Core.Model
{
    public interface IOutputPin : IPin
    {
        IEnumerable<IInputPin> Listeners { get; }
        void AddListener(IInputPin input);
        void RemoveListener(IInputPin input);
    }

    interface IOutputPin<in T> : IOutputPin
    {
        void Emit(T o);
    }
}