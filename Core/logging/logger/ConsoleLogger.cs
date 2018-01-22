using System;
using ch.wuerth.tobias.mux.Core.processing;
using ch.wuerth.tobias.ProcessPipeline;
using ch.wuerth.tobias.ProcessPipeline.pipes;

namespace ch.wuerth.tobias.mux.Core.logging.logger
{
    public class ConsoleLogger : Logger
    {
        public ConsoleLogger(LogTypes type) : base(type) { }

        protected override ProcessPipe<String, String> GetExecuteLogPipe()
        {
            return new ConditionalPipe<String, String>(o => LogTypes.Error == Type || LogTypes.Fatal == Type
                , new WriterPipe(Console.Error)
                , new WriterPipe(Console.Out));
        }
    }
}