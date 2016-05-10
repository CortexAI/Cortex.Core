using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Cortex.Core.Model.Pins
{
    /// <summary>
    /// Queued implementation of input pin. Values posted to this pin
    /// will be automatically queued and dequeued accroding to Take and Post calls.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class InputPin<T> : IInputPin<T>
    {
        private readonly ConcurrentQueue<T> _queue;
        private readonly ManualResetEventSlim _readyEvent;
        private readonly TakeBehaviour _takeBehaviour;

        public WaitHandle ReadyHandle => _readyEvent.WaitHandle;

        public string Name { get; }
        public Type Type => typeof(T);

        public InputPin(string name, TakeBehaviour takeBehaviour = TakeBehaviour.Consume)
        {
            Name = name;
            _readyEvent = new ManualResetEventSlim(false);
            _queue = new ConcurrentQueue<T>();
            _takeBehaviour = takeBehaviour;
        }

        /// <summary>
        /// Casts and adds an item to the queue.
        /// </summary>
        /// <param name="o"></param>
        public void Post(object o)
        {
            if (typeof(T) == o.GetType())
                Post((T) o);
            else if(typeof(T) != typeof(object))
                Post((T) Convert.ChangeType(o, typeof (T)));
            else
                Post((T) o);
        }

        /// <summary>
        /// Enqueues a direct typed item
        /// </summary>
        /// <param name="o"></param>
        public void Post(T o)
        {
            _queue.Enqueue(o);
            _readyEvent.Set();
        }

        /// <summary>
        /// Return last queued item, if there is only 1 item remaining then it will not be dequeued
        /// </summary>
        /// <param name="item">Queued item</param>
        /// <returns>Result of dequeue</returns>
        public bool TryTake(out T item)
        {
            if (_takeBehaviour == TakeBehaviour.CacheLast && _queue.Count == 1)
                return _queue.TryPeek(out item);

            var res = _queue.TryDequeue(out item);
            if(res && _queue.IsEmpty)
                _readyEvent.Reset();
            return res;
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