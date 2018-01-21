using System;
using ch.wuerth.tobias.mux.Core.logging;
using ch.wuerth.tobias.ProcessPipeline;

namespace ch.wuerth.tobias.mux.Core.processing
{
    public class LogTypePrefixPipe : ProcessPipe<Object, String>
    {
        public LogTypePrefixPipe(LoggerType type) : base(o => $"[{type}] {o ?? String.Empty}") { }
    }
}