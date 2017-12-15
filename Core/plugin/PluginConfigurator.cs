using System;

namespace ch.wuerth.tobias.mux.Core.plugin
{
    public class PluginConfigurator
    {
        public String Name { get; private set; }

        public PluginConfigurator RegisterName(String name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            return this;
        }
    }
}