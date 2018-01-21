using System;
using System.Collections.Generic;
using System.Linq;

namespace ch.wuerth.tobias.mux.Core.logging
{
    public static class LoggerBundle
    {
        private static readonly Dictionary<LogTypes, List<Logger>> Logger = new Dictionary<LogTypes, List<Logger>>();

        static LoggerBundle()
        {
            Enum.GetNames(typeof(LogTypes))
                .ToList()
                .ForEach(x => Logger[(LogTypes) Enum.Parse(typeof(LogTypes), x)] = new List<Logger>());
        }

        public static void Register(Logger logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            Logger[logger.Type].Add(logger);
        }

        public static void Deregister(Logger logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            Logger[logger.Type].Remove(logger);
        }

        public static void Trace(params Object[] obj)
        {
            try
            {
                Logger[LogTypes.Trace].ForEach(x => x.Log(obj));
            }
            catch (Exception ex)
            {
                Debug(ex);
            }
        }

        public static void Debug(params Object[] obj)
        {
            try
            {
                Logger[LogTypes.Debug].ForEach(x => x.Log(obj));
            }
            catch (Exception ex)
            {
                Inform(ex);
            }
        }

        public static void Inform(params Object[] obj)
        {
            try
            {
                Logger[LogTypes.Info].ForEach(x => x.Log(obj));
            }
            catch (Exception ex)
            {
                Warn(ex);
            }
        }

        public static void Warn(params Object[] obj)
        {
            try
            {
                Logger[LogTypes.Warning].ForEach(x => x.Log(obj));
            }
            catch (Exception ex)
            {
                Error(ex);
            }
        }

        public static void Error(params Object[] obj)
        {
            try
            {
                Logger[LogTypes.Error].ForEach(x => x.Log(obj));
            }
            catch (Exception ex)
            {
                Fatal(ex);
            }
        }

        public static void Fatal(params Object[] obj)
        {
            Logger[LogTypes.Fatal].ForEach(x => x.Log(obj));
        }
    }
}