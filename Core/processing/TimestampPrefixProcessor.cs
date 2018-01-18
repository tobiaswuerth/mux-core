using System;
using ch.wuerth.tobias.ProcessPipeline;

namespace ch.wuerth.tobias.mux.Core.processing
{
    public class TimestampPrefixProcessor : ProcessSegment<String, String>
    {
        protected override String OnProcess(String obj)
        {
            return $"[{DateTime.Now:s}] {obj ?? String.Empty}";
        }
    }
}