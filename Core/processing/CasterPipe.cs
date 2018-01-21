using System;
using ch.wuerth.tobias.ProcessPipeline;

namespace ch.wuerth.tobias.mux.Core.processing
{
    public class CasterPipe<T> : ProcessPipe<Object, T> where T : class
    {
        protected CasterPipe() : base(o => o as T) { }
    }
}