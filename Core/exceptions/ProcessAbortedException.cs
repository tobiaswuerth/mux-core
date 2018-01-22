using System;
using System.Runtime.Serialization;

namespace ch.wuerth.tobias.mux.Core.exceptions
{
    public class ProcessAbortedException : Exception
    {
        public ProcessAbortedException() { }

        public ProcessAbortedException(String message) : base(message) { }

        public ProcessAbortedException(String message, Exception innerException) : base(message, innerException) { }

        protected ProcessAbortedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}