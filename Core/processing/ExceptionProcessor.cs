using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ch.wuerth.tobias.ProcessPipeline;

namespace ch.wuerth.tobias.mux.Core.processing
{
    public class ExceptionProcessor : ProcessSegment<Exception, String>
    {
        protected override String OnProcess(Exception ex)
        {
            if (null == ex)
            {
                return null;
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
                    , ("Stacktrace", $"{Environment.NewLine}{ex.StackTrace}")
                }.Where(x => !String.IsNullOrWhiteSpace(x.Value))
                .Select(x => $"{x.Title} : {x.Value.Trim().Replace(Environment.NewLine, "")}{Environment.NewLine}")
                .ToList()
                .ForEach(x => sb.Append(x));

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
                return sb.ToString();
            }

            String innerEx = OnProcess(ex.InnerException);

            sb.Append($"----- INNER EXCEPTION -----{Environment.NewLine}");
            sb.Append(innerEx);

            return sb.ToString();
        }
    }
}