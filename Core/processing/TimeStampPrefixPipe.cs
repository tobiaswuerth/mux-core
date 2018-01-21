using System;
using ch.wuerth.tobias.ProcessPipeline;

namespace ch.wuerth.tobias.mux.Core.processing
{
    public class TimeStampPrefixPipe : ProcessPipe<Object, String>
    {
        protected TimeStampPrefixPipe() : base(o => $"[{DateTime.Now:s}] {o ?? String.Empty}") { }
    }
}