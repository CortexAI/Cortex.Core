using System;

namespace Cortex.Core.Model.Exceptions
{
    public class PinTypeMismatchException : Exception
    {
        public PinTypeMismatchException()
        {
        }

        public PinTypeMismatchException(string message)
            : base(message)
        {
        }

        public PinTypeMismatchException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
