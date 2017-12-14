using System;
using System.IO;
using ch.wuerth.tobias.mux.Core.events;
using ch.wuerth.tobias.mux.Core.processor;
using global::ch.wuerth.tobias.mux.Core.global;

namespace ch.wuerth.tobias.mux.Core.logging
{
    public class ExceptionFileLogger : Logger<Exception>
    {
        private readonly IProcessor<Exception, String> _processor = new ExceptionProcessor();

        public static String LogFilePath
        {
            get { return Path.Combine(Location.LogsDirectoryPath, @"\mux_log_exceptions.log"); }
        }

        public override Boolean Log(Exception obj, ICallback<Exception> onError = null)
        {
            (String output, Boolean success) res = _processor.Handle(obj, onError);
            if (!res.success)
            {
                return false;
            }

            try
            {
                File.AppendAllText(LogFilePath, $"{DateTimePrefix} {res.output}");
                return true;
            }
            catch (Exception ex)
            {
                onError?.Push(ex);
                return false;
            }
        }
    }
}