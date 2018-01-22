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
                return Path.Combine(Location.LogsDirectoryPath, $"mux_log_{Type}-{DateTime.Now:yy-MM-dd}.log");
            }
        }

        protected override ProcessPipe<String, String> GetExecuteLogPipe()
        {
            return new WriterPipe(new StreamWriter(File.OpenWrite(LogPath), Encoding.UTF8));
        }
    }
}