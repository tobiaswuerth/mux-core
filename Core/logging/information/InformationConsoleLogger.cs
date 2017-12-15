using System;
using ch.wuerth.tobias.mux.Core.events;

namespace ch.wuerth.tobias.mux.Core.logging.information
{
    public class InformationConsoleLogger : InformationLogger
    {
        public InformationConsoleLogger(ICallback<Exception> exceptionCallback) : base(exceptionCallback) { }

        protected override Boolean Process(String obj)
        {
            if (null == obj)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            Console.WriteLine($"{DateTimePrefix} {obj}");
            return true;
        }
    }
}