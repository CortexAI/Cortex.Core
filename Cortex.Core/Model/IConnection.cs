using System;

namespace Cortex.Core.Model
{
    public interface IConnection : INode, IDisposable
    {
        IElement StartElement { get; }
        IElement EndElement { get; }
        IOutputPin StartPin { get; }
        IInputPin EndPin { get; }


        void Establish();
        void Clear();
    }
}