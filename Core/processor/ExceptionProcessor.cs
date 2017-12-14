using System;
using System.Text;
using ch.wuerth.tobias.mux.Core.events;

namespace ch.wuerth.tobias.mux.Core.processor
{
    public class ExceptionProcessor : IProcessor<Exception, String>
    {
        public (String output, Boolean success) Handle(Exception input, ICallback<Exception> onException = null)
        {
            if (null == input)
            {
                Exception ex = new ArgumentNullException(nameof(input));
                onException?.Push(ex);
                return (null, false);
            }

            StringBuilder sb = new StringBuilder();
            if (null != input.InnerException)
            {
                (String output, Boolean success) res = Handle(input.InnerException, onException);
                if (!res.success)
                {
                    return res;
                }

                sb.Append(res.output);
                sb.Append(Environment.NewLine);
                sb.Append("-----");
                sb.Append(Environment.NewLine);
            }

            sb.Append($"An error occurred: {input.Message}");
            sb.Append(Environment.NewLine);
            sb.Append($"Stacktrace: {input.StackTrace}");

            return (sb.ToString(), true);
        }
    }
}