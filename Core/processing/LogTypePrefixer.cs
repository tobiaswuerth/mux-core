using System;
using ch.wuerth.tobias.mux.Core.logging;
using ch.wuerth.tobias.ProcessPipeline;

namespace ch.wuerth.tobias.mux.Core.processing
{
    public class LogTypePrefixer : ProcessPipe<dynamic, String>
    {
        private readonly LoggerType _type;

        public LogTypePrefixer(LoggerType type)
        {
            _type = type;
        }

        protected override String OnProcess(dynamic obj)
        {
            return $"[{_type}] {obj ?? String.Empty}";
        }
    }
}