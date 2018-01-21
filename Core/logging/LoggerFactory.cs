using System;
using System.Reflection;

namespace ch.wuerth.tobias.mux.Core.logging
{
    public static class LoggerFactory
    {
        public static Logger Build<T>(LogTypes logType) where T : Logger
        {
            return (Logger) Activator.CreateInstance(typeof(T), BindingFlags.CreateInstance, logType);
        }
    }
}