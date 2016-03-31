using System;

namespace Cortex.Core.Model
{
    public interface IInputPin : IPin
    {
        void Handle(object o);
        event Action<IInputPin, object> AfterPinProcessed;
    }
}