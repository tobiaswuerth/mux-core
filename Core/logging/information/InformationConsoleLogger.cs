using System;
using System.Text;
using ch.wuerth.tobias.mux.Core.events;

namespace ch.wuerth.tobias.mux.Core.logging.information
{
    public class InformationConsoleLogger : InformationLogger
    {
        public InformationConsoleLogger(ICallback<Exception> exceptionCallback) : base(exceptionCallback) { }

        protected override Boolean Process(String obj, LogMessageFlags flags)
        {
            if (null == obj)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(DateTimePrefix);
            sb.Append(" ");
            sb.Append(obj);

            if (!flags.HasFlag(LogMessageFlags.NoNewline))
            {
                sb.Append(Environment.NewLine);
            }

            Console.Write(sb.ToString());
            return true;
        }
    }
}