using System;
using System.Collections.Generic;
using System.IO;
using ch.wuerth.tobias.mux.Core.exceptions;
using ch.wuerth.tobias.mux.Core.logging;
using global::ch.wuerth.tobias.mux.Core.global;

namespace ch.wuerth.tobias.mux.Core.plugin
{
    public abstract class PluginBase
    {
        private readonly Dictionary<String, Action> _actions = new Dictionary<String, Action>();

        protected PluginBase(String pluginName)
        {
            Name = pluginName;
        }

        public String Name { get; }

        public Boolean IsInitialized { get; set; }

        public void RegisterAction(String key, Action action)
        {
            if (action == null)
            {
                LoggerBundle.Warn(new ArgumentNullException(nameof(action)));
                return;
            }

            if (key == null)
            {
                LoggerBundle.Warn(new ArgumentNullException(nameof(key)));
                return;
            }

            _actions[key] = action;
        }

        public void TriggerActions(List<String> keys)
        {
            keys.ForEach(TriggerAction);
        }

        public void TriggerAction(String key)
        {
            if (key == null)
            {
                LoggerBundle.Warn(new ArgumentNullException(nameof(key)));
                return;
            }

            if (!_actions.ContainsKey(key))
            {
                LoggerBundle.Debug(new KeyNotFoundException($"No action with name '{key}' found"));
                return;
            }

            _actions[key].Invoke();
        }

        public Boolean Initialize()
        {
            try
            {
                LoggerBundle.Trace($"Initializing plugin '{Name}'...");
                OnInitialize();
                LoggerBundle.Trace($"Successfully initialized plugin '{Name}'");

                RegisterDefaultActions();
                IsInitialized = true;
            }
            catch (Exception ex)
            {
                LoggerBundle.Error(ex);
            }

            return IsInitialized;
        }

        private void RegisterDefaultActions()
        {
            RegisterAction("help", OnActionHelp);
            RegisterAction("-help", OnActionHelp);
            RegisterAction("--help", OnActionHelp);
            RegisterAction("/help", OnActionHelp);
        }

        public void Work(String[] args)
        {
            if (!IsInitialized)
            {
                LoggerBundle.Error($"Plugin '{Name}'", new NotInitializedException());
                return;
            }

            OnProcessStarting();
            Process(args);
            OnProcessStopping();
        }

        protected virtual void OnProcessStarting()
        {
            LoggerBundle.Inform($"A new process of plugin '{Name}' is starting");
        }

        protected virtual void OnProcessStopping()
        {
            LoggerBundle.Inform($"A process of plugin '{Name}' is stopping");
        }

        private void OnActionHelp()
        {
            LoggerBundle.Inform(GetHelp());
        }

        protected virtual String GetHelp()
        {
            return $"Plugin '{Name}' has no specific help message defined";
        }

        protected T RequestConfig<T>() where T : class
        {
            String path = Path.Combine(Location.ApplicationDataDirectoryPath, $"mux_config_plugin_{Name}.json");
            return Configurator.Request<T>(path);
        }

        protected virtual void OnInitialize() { }
        protected abstract void Process(String[] args);
    }
}