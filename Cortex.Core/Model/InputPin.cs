using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Cortex.Core.Model
{
    public class InputPin<T> : IInputPin<T>
    {
        private readonly ConcurrentQueue<T> _queue;
        private readonly ManualResetEvent _newItemEvent;

        public WaitHandle NewItem => _newItemEvent;

        public string Name { get; }
        public Type Type => typeof(T);

        public void Enqueue(object o)
        {
            Enqueue((T) Convert.ChangeType(o, typeof (T)));
        }

        public void Enqueue(T o)
        {
            _queue.Enqueue(o);
            _newItemEvent.Set();
        }

        public InputPin(string name)
        {
            _newItemEvent = new ManualResetEvent(false);
            Name = name;
            _queue = new ConcurrentQueue<T>();
        }

        /// <summary>
        /// Return last queued item, if there is only 1 item remaining then it will not be dequeued
        /// </summary>
        /// <param name="item">Output item</param>
        /// <returns></returns>
        public bool TryTake(out T item)
        {
            if (_queue.Count > 1)
                return _queue.TryDequeue(out item);
            
            var peekRes = _queue.TryPeek(out item);
            if(peekRes)
                _newItemEvent.Reset();
            return peekRes;
        }

        /// <summary>
        /// Will wait until item is available.
        /// </summary>
        /// <returns>Queued item</returns>
        public T Take()
        {
            T item;
            if(TryTake(out item))
                return item;
            else
                throw new InvalidOperationException("Can't take item from queue");
        }
    }
}