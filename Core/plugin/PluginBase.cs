using System;
using ch.wuerth.tobias.mux.Core.exceptions;
using ch.wuerth.tobias.mux.Core.logging;

namespace ch.wuerth.tobias.mux.Core.plugin
{
    public abstract class PluginBase
    {
        protected PluginBase(LoggerBundle logger = null)
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

        public void Work(params String[] args)
        {
            if (!IsInitialized)
            {
                throw new NotInitializedException();
            }

            OnProcessStarted();
            Process(args);
            OnProcessStopped();
        }

        protected virtual void OnProcessStarted() { }
        protected virtual void OnProcessStopped() { }
        protected abstract void ConfigurePlugin(PluginConfigurator configurator);
        protected abstract void Process(params String[] args);
    }
}