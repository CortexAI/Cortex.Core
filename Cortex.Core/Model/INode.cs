using System.Collections.Generic;
using System.Threading;

namespace Cortex.Core.Model
{
    public interface INode : IConatinerNode
    {
        IEnumerable<IInputPin> Inputs { get; }
        IEnumerable<IOutputPin> Outputs { get; }
        void Init(CancellationToken token);
    }
}