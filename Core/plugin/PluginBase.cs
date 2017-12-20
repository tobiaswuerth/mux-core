using System;
using ch.wuerth.tobias.mux.Core.exceptions;
using ch.wuerth.tobias.mux.Core.logging;

namespace ch.wuerth.tobias.mux.Core.plugin
{
    public abstract class PluginBase
    {
        protected PluginBase(LoggerBundle logger)
        {
            Logger = logger;
        }

        private Boolean IsInitialized { get; set; }

        protected LoggerBundle Logger { get; }

        public Boolean Initialize(PluginConfigurator configurator)
        {
            try
            {
                ConfigurePlugin(configurator);
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

            OnProcessStarted();
            Process(args);
            OnProcessStopped();
        }

        protected virtual void OnProcessStarted()
        {
            Logger?.Information?.Log("A new process has been started.");
        }

        protected virtual void OnProcessStopped()
        {
            Logger?.Information?.Log("A process has been stopped.");
        }

        protected abstract void ConfigurePlugin(PluginConfigurator configurator);
        protected abstract void Process(String[] args);
    }
}