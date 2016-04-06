using System.Threading;

namespace Cortex.Core.Model
{
    public interface IInputPin: IPin
    {
        WaitHandle ReadyHandle { get; }
        void Enqueue(object item);
    }

    public interface IInputPin<T> : IInputPin
    {
        void Enqueue(T item);
        bool TryTake(out T item);
        T Take();
    }
}