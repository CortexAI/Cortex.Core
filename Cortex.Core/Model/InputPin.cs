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
        public bool TryGet(out T item)
        {
            //_newItemEvent.WaitOne(Timeout.Infinite);
            if (_queue.Count > 1)
            {
                var res = _queue.TryDequeue(out item);
                _newItemEvent.Reset();
                return res;
            }
            
            var peekRes = _queue.TryPeek(out item);
            _newItemEvent.Reset();
            return peekRes;
        }


        /// <summary>
        /// Will wait until item is available.
        /// </summary>
        /// <returns>Queued item</returns>
        public T Get()
        {
            T item;
            TryGet(out item);
            return item;
        }
    }
}