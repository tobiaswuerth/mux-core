using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ch.wuerth.tobias.ProcessPipeline;

namespace ch.wuerth.tobias.mux.Core.processing
{
    public class ExceptionStringifierPipe : ProcessPipe<Exception, String>
    {
        public ExceptionStringifierPipe() : base(exception =>
        {
            if (null == exception)
            {
                return null;
            }

            StringBuilder sb = new StringBuilder();

            new List<(String Title, String Value)>
                {
                    ("Type      ", exception.GetType().Name)
                    , ("Message   ", exception.Message)
                    , ("Source    ", exception.Source)
                    , ("HelpLink  ", exception.HelpLink)
                    , ("HResult   ", exception.HResult.ToString())
                    , ("TargetSite", exception.TargetSite?.Name)
                    , ("Stacktrace", $"{Environment.NewLine}{exception.StackTrace}")
                }.Where(x => !String.IsNullOrWhiteSpace(x.Value))
                .Select(x => $"{x.Title} : {x.Value.Trim().Replace(Environment.NewLine, "")}{Environment.NewLine}")
                .ToList()
                .ForEach(x => sb.Append(x));

            if (exception.Data?.Count > 0)
            {
                sb.Append($"Data :{Environment.NewLine}");
                foreach (Object key in exception.Data.Keys)
                {
                    sb.Append($" -> [{key}, {exception.Data[key]}]{Environment.NewLine}");
                }
            }

            if (null == exception.InnerException)
            {
                return sb.ToString();
            }

            String innerEx = new ExceptionStringifierPipe().Process(exception.InnerException);

            sb.Append($"----- INNER EXCEPTION -----{Environment.NewLine}");
            sb.Append(innerEx);

            return sb.ToString();
        }) { }
    }
}