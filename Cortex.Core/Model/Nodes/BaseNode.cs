﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cortex.Core.Model.Pins;
using Cortex.Core.Model.Serialization;

namespace Cortex.Core.Model.Nodes
{
    public abstract class BaseNode : INode
    {
        private readonly List<IInputPin> _inputs;
        private readonly List<IOutputPin> _outputs;

        protected BaseNode()
        {
            _inputs = new List<IInputPin>();
            _outputs = new List<IOutputPin>();
        }

        public IEnumerable<IInputPin> Inputs => _inputs;

        public IEnumerable<IOutputPin> Outputs => _outputs;

        public virtual void Init(CancellationToken token)
        {
            Task.Factory.StartNew(TaskMethod, token, token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
        }

        public virtual void Save(IPersisterWriter writer)
        {
        }

        public virtual void Load(IPersisterReader reader)
        {
        }

        protected void AddInputPin(IInputPin pin)
        {
            _inputs.Add(pin);
        }

        protected void AddOutputPin(IOutputPin pin)
        {
            _outputs.Add(pin);
        }

        protected abstract void Handler();

        private void TaskMethod(object token)
        {
            var waitHandles = _inputs.Select(i => i.ReadyHandle).ToArray();
            while (!((CancellationToken)token).IsCancellationRequested)
            {
                WaitHandle.WaitAll(waitHandles);
                Handler();
            }
            ((CancellationToken)token).ThrowIfCancellationRequested();
        }
    }
}