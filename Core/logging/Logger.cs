using System;
using ch.wuerth.tobias.mux.Core.events;

namespace ch.wuerth.tobias.mux.Core.logging
{
    public abstract class Logger<T>
    {
        protected readonly ICallback<Exception> ExceptionCallback;

        protected Logger(ICallback<Exception> exceptionCallback)
        {
            ExceptionCallback = exceptionCallback;
        }

        protected static String DateTimePrefix
        {
            get { return $"[{DateTime.Now:s}]"; }
        }

        public Boolean Log(T obj)
        {
            try
            {
                return Process(obj);
            }
            catch (Exception ex)
            {
                ExceptionCallback?.Push(ex);
                return false;
            }
        }

        protected abstract Boolean Process(T obj);
    }
}