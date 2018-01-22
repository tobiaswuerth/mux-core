using System;
using System.Runtime.Serialization;

namespace ch.wuerth.tobias.mux.Core.exceptions
{
    public class PathOccupiedException : Exception
    {
        public PathOccupiedException() { }

        public PathOccupiedException(String message) : base(message) { }

        public PathOccupiedException(String message, Exception innerException) : base(message, innerException) { }

        protected PathOccupiedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}