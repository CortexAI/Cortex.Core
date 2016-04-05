using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Cortex.Core.Model
{
    public class InputPin<T> : IInputPin<T>
    {
        private readonly ConcurrentQueue<T> _queue;
        private readonly ManualResetEventSlim _newItemEvent;

        public WaitHandle NewItem => _newItemEvent.WaitHandle;

        public string Name { get; }
        public Type Type => typeof(T);

        public InputPin(string name)
        {
            _newItemEvent = new ManualResetEventSlim(false);
            Name = name;
            _queue = new ConcurrentQueue<T>();
        }

        /// <summary>
        /// Casts and adds an item to the queue.
        /// </summary>
        /// <param name="o"></param>
        public void Enqueue(object o)
        {
            if (typeof(T) == o.GetType())
                Enqueue((T) o);
            else if(typeof(T) != typeof(object))
                Enqueue((T) Convert.ChangeType(o, typeof (T)));
            else
                Enqueue((T) o);
        }

        /// <summary>
        /// Enqueues a direct typed item
        /// </summary>
        /// <param name="o"></param>
        public void Enqueue(T o)
        {
            _queue.Enqueue(o);
            _newItemEvent.Set();
        }

        /// <summary>
        /// Return last queued item, if there is only 1 item remaining then it will not be dequeued
        /// </summary>
        /// <param name="item">Queued item</param>
        /// <returns>Result of dequeue</returns>
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
        /// Tries to take an item from the queue, otherwise throws an exception.
        /// </summary>
        /// <returns>Queued item</returns>
        public T Take()
        {
            T item;
            if(TryTake(out item))
                return item;

            throw new InvalidOperationException("Can't take item from queue");
        }
    }
}