using System;
using ch.wuerth.tobias.ProcessPipeline;

namespace ch.wuerth.tobias.mux.Core.logging.logger
{
    public class FileLogger : Logger
    {
        public FileLogger(LogTypes type) : base(type) { }

        protected override ProcessPipe<String, String> GetExecuteLogPipe()
        {
            throw new NotImplementedException();
        }
    }
}