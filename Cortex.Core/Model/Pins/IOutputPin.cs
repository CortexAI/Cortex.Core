using System.Collections.Generic;

namespace Cortex.Core.Model.Pins
{
    public interface IOutputPin : IPin
    {
        IEnumerable<IInputPin> Listeners { get; }
        void AddListener(IInputPin input);
        void AddListener<TInput>(IInputPin<TInput> input);
        void RemoveListener(IInputPin input);
    }

    public interface IOutputPin<in T> : IOutputPin
    {
        void Emit(T o);
    }
}