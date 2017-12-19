using System;

namespace ch.wuerth.tobias.mux.Core.plugin
{
    public class PluginConfigurator
    {
        public String Name { get; private set; }

        public PluginConfigurator RegisterName(String name)
        {
            String value = name?.Trim() ?? throw new ArgumentNullException(nameof(name));
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"{nameof(name)} cannot be empty");
            }

            Name = value;
            return this;
        }
    }
}