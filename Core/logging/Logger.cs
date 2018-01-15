using System;
using ch.wuerth.tobias.mux.Core.events;

namespace ch.wuerth.tobias.mux.Core.logging
{
    public abstract class Logger<T>
    {
        private readonly ICallback<Exception> _exceptionCallback;

        protected Logger(ICallback<Exception> exceptionCallback)
        {
            _exceptionCallback = exceptionCallback;
        }

        protected static String DateTimePrefix
        {
            get
            {
                return $"[{DateTime.Now:s}]";
            }
        }

        public Boolean Log(T obj)
        {
            try
            {
                return Process(obj);
            }
            catch (Exception ex)
            {
                _exceptionCallback?.Push(ex);
                return false;
            }
        }

        protected abstract Boolean Process(T obj);
    }
}