using System;
using System.IO;

namespace ch.wuerth.tobias.mux.Core.global
{
    public static class Location
    {
        public static String ApplicationDataDirectoryPath
        {
            get
            {
                return Path.Combine(Environment.CurrentDirectory, "mux_appdata");
            }
        }

        public static String LogsDirectoryPath
        {
            get
            {
                return Path.Combine(ApplicationDataDirectoryPath, "logs");
            }
        }

        public static String PluginsDirectoryPath
        {
            get
            {
                return Path.Combine(ApplicationDataDirectoryPath, "plugins");
            }
        }
    }
}