using System.Collections.Generic;

namespace Cortex.Core.Model
{
    public interface IElement : INode
    {
        IEnumerable<IInputPin> Inputs { get; }
        IEnumerable<IOutputPin> Outputs { get; }
        void Init();
    }
}