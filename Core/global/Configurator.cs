using System;
using System.IO;
using ch.wuerth.tobias.mux.Core.exceptions;
using ch.wuerth.tobias.mux.Core.io;
using ch.wuerth.tobias.mux.Core.logging;

namespace ch.wuerth.tobias.mux.Core.global
{
    public static class Configurator
    {
        public static T Request<T>(String path) where T : class
        {
            LoggerBundle.Debug($"Requested configuration '{path}'");

            if (!File.Exists(path))
            {
                LoggerBundle.Trace($"File '{path}' not found. Trying to create it...");
                FileInterface.Save(Activator.CreateInstance<T>(), path);
                LoggerBundle.Trace($"Successfully created file '{path}'");

                LoggerBundle.Inform(
                    $"Changes to the newly created file '{path}' will take effect after restarting the executable. Adjust default value as needed and restart the application.");
            }

            LoggerBundle.Trace($"Trying to read file '{path}'...");
            (T result, Boolean success) = FileInterface.Read<T>(path);
            if (!success)
            {
                LoggerBundle.Warn(new ProcessAbortedException());
                return null;
            }

            LoggerBundle.Debug($"Successfully read configuration file '{path}'");
            return result;
        }
    }
}