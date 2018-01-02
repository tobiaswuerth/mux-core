using System;
using System.IO;
using ch.wuerth.tobias.mux.Core.exceptions;
using ch.wuerth.tobias.mux.Core.io;
using ch.wuerth.tobias.mux.Core.logging;
using ch.wuerth.tobias.mux.Core.global;

namespace ch.wuerth.tobias.mux.Core.plugin
{
    public abstract class PluginBase
    {
        protected PluginBase(String pluginName, LoggerBundle logger)
        {
            Name = pluginName;
            Logger = logger;
        }

        public String Name { get; }

        public Boolean IsInitialized { get; set; }

        protected LoggerBundle Logger { get; }

        public Boolean Initialize()
        {
            try
            {
                OnInitialize();
                IsInitialized = true;
            }
            catch (Exception ex)
            {
                Logger?.Exception?.Log(ex);
            }

            return IsInitialized;
        }

        public void Work(String[] args)
        {
            if (!IsInitialized)
            {
                throw new NotInitializedException();
            }

            OnProcessStarting();
            Process(args);
            OnProcessStopping();
        }

        protected virtual void OnProcessStarting()
        {
            Logger?.Information?.Log($"A new process of plugin '{Name}' is starting");
        }

        protected virtual void OnProcessStopping()
        {
            Logger?.Information?.Log($"A process of plugin '{Name}' is stopping");
        }

        protected T RequestConfig<T>() where T : class
        {
            String configPath = Path.Combine(Location.ApplicationDataDirectoryPath, $"mux_config_plugin_{Name}.json");
            if (!File.Exists(configPath))
            {
                Logger?.Information?.Log($"File '{configPath}' not found. Trying to create it...");
                FileInterface.Save(Activator.CreateInstance<T>(), configPath, false, Logger);
                Logger?.Information?.Log($"Successfully created file '{configPath}'");
                Logger?.Information?.Log(
                    $"Please adjust the newly created file '{configPath}' as needed and run again");
                throw new ProcessAbortedException();
            }

            (T output, Boolean success) readResult = FileInterface.Read<T>(configPath, Logger);
            if (!readResult.success)
            {
                throw new ProcessAbortedException();
            }

            Logger?.Information?.Log($"Successfully read configuration file '{configPath}'");
            return readResult.output;
        }

        protected virtual void OnInitialize() { }
        protected abstract void Process(String[] args);
    }
}