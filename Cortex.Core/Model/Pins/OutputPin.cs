namespace Cortex.Core.Model.Pins
{
    public class OutputPin<T> : BaseOutputPin<T>
    {
        public override void Emit(T o)
        {
            foreach (var listener in _listeners)
            {
                listener.Post(o);
            }
        }

        public OutputPin(string name) : base(name)
        {
        }
    }
}