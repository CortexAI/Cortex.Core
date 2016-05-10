namespace Cortex.Core.Model
{
    public enum TakeBehaviour
    {
        /// <summary>
        /// Consumes the value, resets the input ReadyEvent
        /// </summary>
        Consume,

        /// <summary>
        /// Last posted value will be cached, so ReadyEvent will be set all the time
        /// </summary>
        CacheLast
    }
}