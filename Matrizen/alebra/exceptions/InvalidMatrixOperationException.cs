using System.Runtime.Serialization;

namespace Matrizen.alebra
{
    [Serializable]
    internal class InvalidMatrixOperationException : Exception
    {
        public InvalidMatrixOperationException() : base()
        {
        }

        public InvalidMatrixOperationException(string? message) : base(message)
        {
        }

        public InvalidMatrixOperationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidMatrixOperationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

    }
}