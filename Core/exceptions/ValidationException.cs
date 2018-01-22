using System;
using System.Runtime.Serialization;

namespace ch.wuerth.tobias.mux.Core.exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException() { }

        public ValidationException(String message) : base(message) { }

        public ValidationException(String message, Exception innerException) : base(message, innerException) { }

        protected ValidationException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}