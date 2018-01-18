using System;
using ch.wuerth.tobias.mux.Core.logging;
using ch.wuerth.tobias.ProcessPipeline;

namespace ch.wuerth.tobias.mux.Core.processing
{
    public class LogTypePrefixProcessor : ProcessSegment<String, String>
    {
        private readonly LoggerType _type;

        public LogTypePrefixProcessor(LoggerType type)
        {
            _type = type;
        }

        protected override String OnProcess(String obj)
        {
            return $"[{_type}] {obj ?? String.Empty}";
        }
    }
}