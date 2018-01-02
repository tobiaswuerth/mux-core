using System;
using System.IO;
using ch.wuerth.tobias.mux.Core.events;
using global::ch.wuerth.tobias.mux.Core.global;

namespace ch.wuerth.tobias.mux.Core.logging.information
{
    public class InformationFileLogger : InformationLogger
    {
        public InformationFileLogger(ICallback<Exception> exceptionCallback) : base(exceptionCallback) { }

        private static String LogFilePath
        {
            get { return Path.Combine(Location.LogsDirectoryPath, $"mux_log_information-{DateTime.Now:yyyyMMdd}.log"); }
        }

        protected override Boolean Process(String obj)
        {
            if (null == obj)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            File.AppendAllText(LogFilePath, $"{DateTimePrefix} {obj}{Environment.NewLine}");
            return true;
        }
    }
}