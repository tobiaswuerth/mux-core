using System;
using System.Collections.Generic;

namespace ch.wuerth.tobias.mux.Core.logging
{
    public class LoggingConfig
    {
        public const String KEY_CONSOLE = "console";
        public const String KEY_FILE = "file";

        public Dictionary<LogTypes, List<String>> Loggers { get; set; } = new Dictionary<LogTypes, List<String>>
        {
            {
                LogTypes.Trace, new List<String>()
            }
            ,
            {
                LogTypes.Debug, new List<String>()
            }
            ,
            {
                LogTypes.Info, new List<String>
                {
                    KEY_CONSOLE
                }
            }
            ,
            {
                LogTypes.Warning, new List<String>
                {
                    KEY_CONSOLE
                }
            }
            ,
            {
                LogTypes.Error, new List<String>
                {
                    KEY_CONSOLE
                    , KEY_FILE
                }
            }
            ,
            {
                LogTypes.Fatal, new List<String>
                {
                    KEY_CONSOLE
                    , KEY_FILE
                }
            }
        };
    }
}