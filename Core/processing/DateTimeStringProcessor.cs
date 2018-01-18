using System;
using System.Globalization;
using ch.wuerth.tobias.ProcessPipeline;

namespace ch.wuerth.tobias.mux.Core.processing
{
    public class DateTimeStringProcessor : ProcessSegment<String, DateTime?>
    {
        protected override DateTime? OnProcess(String obj)
        {
            if (DateTime.TryParseExact(obj, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt1))
            {
                return dt1;
            }
            if (DateTime.TryParseExact(obj, "yyyy-MM", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt2))
            {
                return dt2;
            }
            if (DateTime.TryParseExact(obj, "yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt3))
            {
                return dt3;
            }

            return null;
        }
    }
}