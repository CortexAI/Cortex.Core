using System;
using System.Linq;
using Cortex.Core.Model.Nodes;
using Cortex.Core.Model.Pins;
using Cortex.Core.Model.Serialization;

namespace Cortex.Core.Model
{
    public class Connection : IConnection
    {
        private IOutputPin _startPin;
        private IInputPin _endPin;

        public Connection(INode startNode, IOutputPin startPin, INode endNode, IInputPin endPin)
        {
            StartNode = startNode;
            EndNode = endNode;

            if (!startNode.Outputs.Contains(startPin) || !EndNode.Inputs.Contains(endPin))
                throw new InvalidOperationException("Pins not from this elements");
            _startPin = startPin;
            _endPin = endPin;
        }

        public Connection()
        {
        }

        public INode StartNode { get; private set; }

        public INode EndNode { get; private set; }

        public IOutputPin StartPin => _startPin;

        public IInputPin EndPin => _endPin;

        public void Establish()
        {
            if (!StartPin.Listeners.Contains(EndPin))
            {
                _startPin.AddListener(_endPin);
            }
        }

        public void Clear()
        {
            if (StartPin.Listeners.Contains(EndPin))
            {
                _startPin.RemoveListener(_endPin);
            }
        }

        public void Save(IPersisterWriter persister)
        {
            persister.Set("startNode", StartNode);
            persister.Set("endNode", EndNode);
            persister.Set("StartPin", StartNode.Outputs.ToList().IndexOf(StartPin));
            persister.Set("EndPin", EndNode.Inputs.ToList().IndexOf(EndPin));
        }

        public void Load(IPersisterReader persister)
        {
            StartNode = persister.Get<INode>("startNode");
            EndNode = persister.Get<INode>("endNode");
            _startPin = StartNode.Outputs.ElementAt(persister.Get<int>("StartPin"));
            _endPin = EndNode.Inputs.ElementAt(persister.Get<int>("EndPin"));
        }

        public void Dispose()
        {
            Clear();
        }
    }
}