using System;
using System.Runtime.Serialization;

namespace ch.wuerth.tobias.mux.Core.exceptions
{
    public class NotInitializedException : Exception
    {
        public NotInitializedException() { }

        public NotInitializedException(String message) : base(message) { }

        public NotInitializedException(String message, Exception innerException) : base(message, innerException) { }

        protected NotInitializedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}