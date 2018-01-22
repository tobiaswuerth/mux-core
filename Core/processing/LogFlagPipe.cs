using System;
using ch.wuerth.tobias.mux.Core.logging;
using ch.wuerth.tobias.ProcessPipeline;
using ch.wuerth.tobias.ProcessPipeline.pipes;

namespace ch.wuerth.tobias.mux.Core.processing
{
    public class LogFlagPipe : ProcessPipe<String, String>
    {
        public LogFlagPipe(LogTypes type, LogFlags flags) : base(o =>
        {
            ProcessPipe<String, String> pipe = new EmptyPipe<String>();
            if (flags.HasFlag(LogFlags.PrefixLoggerType))
            {
                pipe = pipe.Connect(new ProcessPipe<String, String>(s => $"[{type}] {s}"));
            }
            if (flags.HasFlag(LogFlags.PrefixTimeStamp))
            {
                pipe = pipe.Connect(new ProcessPipe<String, String>(s => $"[{DateTime.Now:s}] {s}"));
            }
            if (flags.HasFlag(LogFlags.SuffixNewLine))
            {
                pipe = pipe.Connect(new ProcessPipe<String, String>(s => $"{s}{Environment.NewLine}"));
            }
            return pipe.Process(o);
        }) { }
    }
}