using System.Threading;

namespace Cortex.Core.Model.Pins
{
    public interface IInputPin: IPin
    {
        WaitHandle ReadyHandle { get; }
        void Post(object item);
    }

    public interface IInputPin<T> : IInputPin
    {
        void Post(T item);
        bool TryTake(out T item);
        T Take();
    }
}