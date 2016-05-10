using System;
using Cortex.Core.Model.Nodes;
using Cortex.Core.Model.Pins;

namespace Cortex.Core.Model
{
    public interface IConnection : IConatinerNode, IDisposable
    {
        INode StartNode { get; }
        INode EndNode { get; }
        IOutputPin StartPin { get; }
        IInputPin EndPin { get; }
        

        void Establish();
        void Clear();
    }
}