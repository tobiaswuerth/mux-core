using System;
using System.IO;
using ch.wuerth.tobias.mux.Core.events;
using global::ch.wuerth.tobias.mux.Core.global;

namespace ch.wuerth.tobias.mux.Core.logging.information
{
    public class InformationFileLogger : InformationLogger
    {
        public static String LogFilePath
        {
            get { return Path.Combine(Location.LogsDirectoryPath, @"\mux_log_information.log"); }
        }

        public override Boolean Log(String obj, ICallback<Exception> onError = null)
        {
            if (null == obj)
            {
                onError?.Push(new ArgumentNullException(nameof(obj)));
                return false;
            }

            try
            {
                File.AppendAllText(LogFilePath, $"{DateTimePrefix} {obj}");
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