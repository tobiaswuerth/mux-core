using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ch.wuerth.tobias.mux.Core.logging.logger;
using global::ch.wuerth.tobias.mux.Core.global;

namespace ch.wuerth.tobias.mux.Core.logging
{
    public static class LoggerBundle
    {
        private static readonly Dictionary<String, Type> LoggerMapping = new Dictionary<String, Type>
        {
            {
                LoggingConfig.KEY_CONSOLE, typeof(ConsoleLogger)
            }
            ,
            {
                LoggingConfig.KEY_FILE, typeof(FileLogger)
            }
        };

        private static readonly Dictionary<LogTypes, List<Logger>> Loggers = new Dictionary<LogTypes, List<Logger>>();

        static LoggerBundle()
        {
            Initialize();
            LoadConfiguration();
        }

        private static String LoggingConfigurationPath
        {
            get
            {
                return Path.Combine(Location.ApplicationDataDirectoryPath, "mux_config_logging.json");
            }
        }

        private static void LoadConfiguration()
        {
            List<Logger> preInitLoggers = Enum.GetNames(typeof(LogTypes))
                .Select(x => Activator.CreateInstance(typeof(ConsoleLogger), Enum.Parse<LogTypes>(x)) as Logger)
                .ToList();
            preInitLoggers.ForEach(Register);

            LoggingConfig config = Configurator.Request<LoggingConfig>(LoggingConfigurationPath);
            if (null == config)
            {
                Warn($"Could not load config file '{LoggingConfigurationPath}'. Continuing with default loggers.");
                return;
            }

            Debug($"Successfully read config file '{LoggingConfigurationPath}'");

            Debug("Applying logging config...");
            preInitLoggers.ForEach(Deregister);
            config.Loggers.ToList()
                .ForEach(pair => pair.Value.ForEach(s =>
                {
                    if (!LoggerMapping.ContainsKey(s))
                    {
                        return;
                    }

                    Trace(Logger.DefaultLogFlags & ~LogFlags.SuffixNewLine, $"Trying to create instance of type {s}...");
                    Logger logger = Activator.CreateInstance(LoggerMapping[s], pair.Key) as Logger;
                    Trace(Logger.DefaultLogFlags & ~LogFlags.PrefixLoggerType & ~LogFlags.PrefixTimeStamp, "Ok.");
                    Trace($"Trying to register logger of type '{s}'...");
                    Register(logger);
                    Trace($"Registered logger of type '{s}'");
                }));
            Debug("Logging config applied");
        }

        private static void Initialize()
        {
            Enum.GetNames(typeof(LogTypes))
                .ToList()
                .ForEach(x => Loggers[(LogTypes) Enum.Parse(typeof(LogTypes), x)] = new List<Logger>());
        }

        public static void Register(Logger logger)
        {
            if (logger == null)
            {
                Warn(new ArgumentNullException(nameof(logger)));
                return;
            }

            Loggers[logger.Type].Add(logger);
        }

        public static void Deregister(Logger logger)
        {
            if (logger == null)
            {
                Warn(new ArgumentNullException(nameof(logger)));
                return;
            }

            Loggers[logger.Type].Remove(logger);
        }

        public static void Trace(params Object[] obj)
        {
            Trace(Logger.DefaultLogFlags, obj);
        }

        public static void Trace(LogFlags flags, params Object[] obj)
        {
            try
            {
                Loggers[LogTypes.Trace].ForEach(x => x.Log(flags, obj));
            }
            catch (Exception ex)
            {
                Debug(ex);
            }
        }

        public static void Debug(params Object[] obj)
        {
            Debug(Logger.DefaultLogFlags, obj);
        }

        public static void Debug(LogFlags flags, params Object[] obj)
        {
            try
            {
                Loggers[LogTypes.Debug].ForEach(x => x.Log(flags, obj));
            }
            catch (Exception ex)
            {
                Inform(ex);
            }
        }

        public static void Inform(params Object[] obj)
        {
            Inform(Logger.DefaultLogFlags, obj);
        }

        public static void Inform(LogFlags flags, params Object[] obj)
        {
            try
            {
                Loggers[LogTypes.Info].ForEach(x => x.Log(flags, obj));
            }
            catch (Exception ex)
            {
                Warn(ex);
            }
        }

        public static void Warn(params Object[] obj)
        {
            Warn(Logger.DefaultLogFlags, obj);
        }

        public static void Warn(LogFlags flags, params Object[] obj)
        {
            try
            {
                Loggers[LogTypes.Warning].ForEach(x => x.Log(flags, obj));
            }
            catch (Exception ex)
            {
                Error(ex);
            }
        }

        public static void Error(params Object[] obj)
        {
            Error(Logger.DefaultLogFlags, obj);
        }

        public static void Error(LogFlags flags, params Object[] obj)
        {
            try
            {
                Loggers[LogTypes.Error].ForEach(x => x.Log(flags, obj));
            }
            catch (Exception ex)
            {
                Fatal(ex);
            }
        }

        public static void Fatal(params Object[] obj)
        {
            Fatal(Logger.DefaultLogFlags, obj);
        }

        public static void Fatal(LogFlags flags, params Object[] obj)
        {
            Loggers[LogTypes.Fatal].ForEach(x => x.Log(flags, obj));
        }
    }
}