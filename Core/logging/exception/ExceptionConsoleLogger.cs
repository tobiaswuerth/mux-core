using System;
using System.Text;
using ch.wuerth.tobias.mux.Core.events;
using ch.wuerth.tobias.mux.Core.exceptions;
using ch.wuerth.tobias.mux.Core.processor;

namespace ch.wuerth.tobias.mux.Core.logging.exception
{
    public class ExceptionConsoleLogger : ExceptionLogger
    {
        private readonly IProcessor<Exception, String> _processor = new ExceptionProcessor();

        public ExceptionConsoleLogger(ICallback<Exception> exceptionCallback) : base(exceptionCallback) { }

        protected override Boolean Process(Exception obj)
        {
            if (null == obj)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            (String output, Boolean success) res = _processor.Handle(obj
                , new LoggerBundle
                {
                    Exception = this
                });
            if (!res.success)
            {
                throw new ProcessAbortedException();
            }

            StringBuilder sb = new StringBuilder();
            sb.Append($"An exception occurred{Environment.NewLine}");
            sb.Append($"##### EXCEPTION BEGIN #####{Environment.NewLine}");
            sb.Append(res.output);
            sb.Append("###### EXCEPTION END ######");

            Console.WriteLine($"{DateTimePrefix} {sb}");
            return true;
        }
    }
}