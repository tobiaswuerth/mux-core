using System;
using System.IO;
using System.Text;
using ch.wuerth.tobias.mux.Core.processing;
using ch.wuerth.tobias.ProcessPipeline;
using global::ch.wuerth.tobias.mux.Core.global;

namespace ch.wuerth.tobias.mux.Core.logging.logger
{
    public class FileLogger : Logger
    {
        public FileLogger(LogTypes type) : base(type) { }

        private String LogPath
        {
            get
            {
                return Path.Combine(Location.LogsDirectoryPath
                    , $"mux_log_{Type.ToString().ToLower()}-{DateTime.Now:yyMMdd}.log");
            }
        }

        protected override ProcessPipe<String, String> GetExecuteLogPipe()
        {
            String logDir = Path.GetDirectoryName(LogPath);
            if (!Directory.Exists(logDir))
            {
                LoggerBundle.Trace(DefaultLogFlags & ~LogFlags.SuffixNewLine
                    , $"Creating directory '{logDir}' for file logger of type '{Type}'...");
                Directory.CreateDirectory(logDir);
                LoggerBundle.Trace(DefaultLogFlags & ~LogFlags.PrefixLoggerType & ~LogFlags.PrefixTimeStamp, "Ok.");
            }
            FileStream fileStream = File.Open(LogPath, FileMode.Append, FileAccess.Write, FileShare.Read);
            StreamWriter writer = new StreamWriter(fileStream, Encoding.UTF8);
            return new WriterPipe(writer);
        }
    }
}