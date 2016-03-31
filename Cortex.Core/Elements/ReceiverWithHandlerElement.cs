using Cortex.Core.Model;

namespace Cortex.Core.Elements
{
    public abstract class ReceiverWithHandlerElement<T> : BaseElement
    {
        protected ReceiverWithHandlerElement()
        {
            AddInputPin(new InputPin<T>(typeof(T).Name, Handler));
        }

        protected abstract void Handler(IInputPin pin, T o);
    }
}