using System;
using System.Collections.Generic;
using System.Text;
using ch.wuerth.tobias.mux.Core.logging;

namespace ch.wuerth.tobias.mux.Core.plugin
{
    public abstract class PluginBase
    {
        private readonly LoggerBundle _logger;
        public Boolean IsInitialized { get; set; }

        protected PluginBase(LoggerBundle logger = null)
        {
            _logger = logger;
        }

        public Boolean Initialize(PluginConfigurator configurator)
        {
            try
            {
                ConfigurePlugin(configurator);
                IsInitialized = true;
            }
            catch (Exception ex)
            {
                _logger?.Exception?.Log(ex);
            }

            return IsInitialized;
        }

        protected abstract void ConfigurePlugin(PluginConfigurator configurator);
        protected abstract void Process(params String[] args);
    }
}
