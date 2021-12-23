using System;
using System.Runtime.Serialization;

namespace MathMTS.algebra.exceptions
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