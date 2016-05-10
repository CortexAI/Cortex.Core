using System.Collections.Generic;
using System.Threading;
using Cortex.Core.Model.Pins;

namespace Cortex.Core.Model.Nodes
{
    public interface INode : IConatinerNode
    {
        IEnumerable<IInputPin> Inputs { get; }
        IEnumerable<IOutputPin> Outputs { get; }
        void Init(CancellationToken token);
    }
}