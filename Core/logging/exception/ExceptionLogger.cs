using System;
using ch.wuerth.tobias.mux.Core.events;

namespace ch.wuerth.tobias.mux.Core.logging.exception
{
    public abstract class ExceptionLogger : Logger<Exception>
    {
        protected ExceptionLogger(ICallback<Exception> exceptionCallback) : base(exceptionCallback) { }
    }
}