using System;
using System.IO;
using System.Text;
using ch.wuerth.tobias.mux.Core.events;
using global::ch.wuerth.tobias.mux.Core.global;

namespace ch.wuerth.tobias.mux.Core.logging.information
{
    public class InformationFileLogger : InformationLogger
    {
        public InformationFileLogger(ICallback<Exception> exceptionCallback) : base(exceptionCallback) { }

        private static String LogFilePath
        {
            get
            {
                return Path.Combine(Location.LogsDirectoryPath, $"mux_log_information-{DateTime.Now:yyyyMMdd}.log");
            }
        }

        protected override Boolean Process(String obj, LoggerFlags flags)
        {
            if (null == obj)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(DateTimePrefix);
            sb.Append(" ");
            sb.Append(obj);

            if (!flags.HasFlag(LoggerFlags.NoNewline))
            {
                sb.Append(Environment.NewLine);
            }

            File.AppendAllText(LogFilePath, sb.ToString());
            return true;
        }
    }
}