using System;
using ch.wuerth.tobias.ProcessPipeline;

namespace ch.wuerth.tobias.mux.Core.processing
{
    public class Caster<T> : ProcessPipe<dynamic, T>
    {
        protected override T OnProcess(dynamic obj)
        {
            return (T) obj;
        }
    }
}