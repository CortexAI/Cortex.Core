using System;
using System.Threading;
using System.Threading.Tasks;
using Cortex.Core.Model;

namespace Cortex.Core
{
    public class Session : IDisposable
    {
        private readonly ProcessGraph _processGraph;
        private Task _task;
        private CancellationTokenSource _cts;

        public Session(ProcessGraph processGraph)
        {
            _cts = new CancellationTokenSource();
            _processGraph = processGraph;
        }

        public bool IsRunning => _task?.IsCompleted == false;

        public void Dispose()
        {
            Stop();
        }

        public void Start()
        {
            _task = Task.Factory.StartNew(Handler, _cts.Token, _cts.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
        }

        private void Handler(object token)
        {
            foreach (var element in _processGraph.Elements)
            {
                element.Init((CancellationToken) token);
            }
        }

        public void Stop()
        {
            if (!IsRunning)
                return;
            _cts.Cancel();
        }
    }
}