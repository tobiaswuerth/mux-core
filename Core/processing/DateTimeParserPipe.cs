using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ch.wuerth.tobias.ProcessPipeline;

namespace ch.wuerth.tobias.mux.Core.processing
{
    public class DateTimeParserPipe : ProcessPipe<String, DateTime?>
    {
        private static readonly List<String> DateTimePatterns = new List<String>
        {
            "yyyy-MM-dd"
            , "yyyy-MM"
            , "yyyy"
        };

        public DateTimeParserPipe() : base(o =>
        {
            DateTime dateTime = DateTime.MinValue;
            return DateTimePatterns.Any(p
                => DateTime.TryParseExact(o, p, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
                ? (DateTime?) dateTime
                : null;
        }) { }
    }
}