using System;

namespace Cortex.Core.Model.Pins
{
    public class CloningOutputPin<T> : BaseOutputPin<T>
        where T : ICloneable
    {
        public CloningOutputPin(string name) : base(name)
        {
        }

        public override void Emit(T o)
        {
            foreach (var listener in _listeners)
            {
                listener.Post((T)o.Clone());
            }
        }
    }
}