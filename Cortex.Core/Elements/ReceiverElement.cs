using System;
using Cortex.Core.Model;

namespace Cortex.Core.Elements
{
    public abstract class ReceiverElement<T> : BaseElement
    {
        protected ReceiverElement()
        {
            AddInputPin(new InputPin<T>(typeof(T).Name, null));
        }

        protected ReceiverElement(Action<IInputPin, T> handler)
        {
            AddInputPin(new InputPin<T>(typeof(T).Name, handler));
        }
    }


}