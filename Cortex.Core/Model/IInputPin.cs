using System.Threading;

namespace Cortex.Core.Model
{
    public interface IInputPin: IPin
    {
        WaitHandle NewItem { get; }
        void Enqueue(object item);
    }

    public interface IInputPin<T> : IInputPin
    {
        void Enqueue(T item);
        bool TryGet(out T item);
        T Get();
    }
}