using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ch.wuerth.tobias.mux.Core.logging;

namespace ch.wuerth.tobias.mux.Core.processor
{
    public class ExceptionProcessor : IProcessor<Exception, String>
    {
        public (String output, Boolean success) Handle(Exception ex, LoggerBundle logger)
        {
            if (null == ex)
            {
                logger?.Exception?.Log(new ArgumentNullException(nameof(ex)));
                return (null, false);
            }

            StringBuilder sb = new StringBuilder();

            new List<(String Title, String Value)>
                {
                    ("Type      ", ex.GetType().Name)
                    , ("Message   ", ex.Message)
                    , ("Source    ", ex.Source)
                    , ("HelpLink  ", ex.HelpLink)
                    , ("HResult   ", ex.HResult.ToString())
                    , ("TargetSite", ex.TargetSite?.Name)
                }.Where(x => !String.IsNullOrWhiteSpace(x.Value))
                .Select(x => $"{x.Title} : {x.Value.Trim().Replace(Environment.NewLine, "")}{Environment.NewLine}")
                .ToList()
                .ForEach(x => sb.Append(x));

            sb.Append($"Stacktrace:{Environment.NewLine}{ex.StackTrace}{Environment.NewLine}");

            if (ex.Data?.Count > 0)
            {
                sb.Append($"Data :{Environment.NewLine}");
                foreach (Object key in ex.Data.Keys)
                {
                    sb.Append($" -> [{key}, {ex.Data[key]}]{Environment.NewLine}");
                }
            }

            if (null == ex.InnerException)
            {
                return (sb.ToString(), true);
            }

            (String output, Boolean success) res = Handle(ex.InnerException, logger);
            if (!res.success)
            {
                return res;
            }

            sb.Append($"----- INNER EXCEPTION -----{Environment.NewLine}");
            sb.Append(res.output);

            return (sb.ToString(), true);
        }
    }
}