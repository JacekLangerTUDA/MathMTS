using System.Runtime.Serialization;

namespace Matrizen.alebra.exceptions
{
    public class InvalidVectorOperationException : Exception
    {
        public InvalidVectorOperationException() : base()
        {
        }

        public InvalidVectorOperationException(string? message) : base(message)
        {
        }

        public InvalidVectorOperationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidVectorOperationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
