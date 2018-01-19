using System;
using ch.wuerth.tobias.ProcessPipeline;

namespace ch.wuerth.tobias.mux.Core.processing
{
    public class TimeStamper : ProcessPipe<dynamic, String>
    {
        protected override String OnProcess(dynamic obj)
        {
            return $"[{DateTime.Now:s}] {obj ?? String.Empty}";
        }
    }
}