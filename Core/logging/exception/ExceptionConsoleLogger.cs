using System;
using ch.wuerth.tobias.mux.Core.events;
using ch.wuerth.tobias.mux.Core.processor;

namespace ch.wuerth.tobias.mux.Core.logging.exception
{
    public class ExceptionConsoleLogger : ExceptionLogger
    {
        private readonly IProcessor<Exception, String> _processor = new ExceptionProcessor();

        public override Boolean Log(Exception obj, ICallback<Exception> onError = null)
        {
            (String output, Boolean success) res = _processor.Handle(obj, onError);
            if (!res.success)
            {
                return false;
            }

            try
            {
                Console.WriteLine($"{DateTimePrefix} {res.output}");
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