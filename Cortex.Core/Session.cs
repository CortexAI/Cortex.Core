using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cortex.Core.Model;

namespace Cortex.Core
{
    public class Session : IDisposable
    {
        private readonly ProcessGraph _processGraph;
        private Thread _thread;

        public Session(ProcessGraph processGraph)
        {
            _processGraph = processGraph;
        }

        public bool IsRunning
        {
            get
            {
                if (_thread == null)
                    return false;
                return _thread.IsAlive;
            }
        }

        public void Dispose()
        {
            Stop();
        }

        public void Start()
        {
            _thread = new Thread(() =>
            {
                foreach (var element in _processGraph.Elements)
                {
                    element.Init();
                }
            }) {Priority = ThreadPriority.AboveNormal, IsBackground = true };
            _thread.Start();
        }

        public void Stop()
        {
            if (!IsRunning) return;

            _thread.Interrupt();
            Task.Delay(2000).ContinueWith(delegate
            {
                if (IsRunning)
                {
                    _thread.Abort();
                    _thread = null;
                }
            });
        }
    }
}