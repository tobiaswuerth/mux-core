﻿using System;
using System.Globalization;
using ch.wuerth.tobias.mux.Core.events;

namespace ch.wuerth.tobias.mux.Core.processor
{
    public class DateTimeStringProcessor : IProcessor<String, DateTime?>
    {
        public (DateTime? output, Boolean success) Handle(String input, ICallback<Exception> onException = null)
        {
            if (DateTime.TryParseExact(input, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None,
                out DateTime dt1))
            {
                return (dt1, true);
            }
            if (DateTime.TryParseExact(input, "yyyy-MM", CultureInfo.InvariantCulture, DateTimeStyles.None,
                out DateTime dt2))
            {
                return (dt2, true);
            }
            if (DateTime.TryParseExact(input, "yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                out DateTime dt3))
            {
                return (dt3, true);
            }

            return (null, false);
        }
    }
}