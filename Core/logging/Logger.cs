using System;
using ch.wuerth.tobias.mux.Core.events;

namespace ch.wuerth.tobias.mux.Core.logging
{
    public abstract class Logger<T>
    {
        public static String DateTimePrefix
        {
            get { return $"[{DateTime.Now:d T}]"; }
        }

        public abstract Boolean Log(T obj, ICallback<Exception> onError = null);
    }
}