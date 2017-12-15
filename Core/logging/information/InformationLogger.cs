using System;
using ch.wuerth.tobias.mux.Core.events;

namespace ch.wuerth.tobias.mux.Core.logging.information
{
    public abstract class InformationLogger : Logger<String>
    {
        protected InformationLogger(ICallback<Exception> exceptionCallback) : base(exceptionCallback) { }
    }
}