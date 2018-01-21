using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ch.wuerth.tobias.mux.Core.exceptions;
using ch.wuerth.tobias.mux.Core.io;
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
                OnInitialize();
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
                throw new NotInitializedException();
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
            StringBuilder sb = new StringBuilder();
            OnActionHelp(sb);
            LoggerBundle.Inform(sb.ToString());
        }

        protected virtual void OnActionHelp(StringBuilder sb)
        {
            sb.Append($"Plugin '{Name}' has no specific help message defined");
        }

        protected T RequestConfig<T>() where T : class
        {
            String configPath = Path.Combine(Location.ApplicationDataDirectoryPath, $"mux_config_plugin_{Name}.json");
            if (!File.Exists(configPath))
            {
                LoggerBundle.Debug($"File '{configPath}' not found. Trying to create it...");
                FileInterface.Save(Activator.CreateInstance<T>(), configPath);
                LoggerBundle.Debug($"Successfully created file '{configPath}'");
                LoggerBundle.Inform($"Please adjust the newly created file '{configPath}' as needed and run again");
                throw new ProcessAbortedException();
            }

            (T output, Boolean success) readResult = FileInterface.Read<T>(configPath);
            if (!readResult.success)
            {
                throw new ProcessAbortedException();
            }

            LoggerBundle.Trace($"Successfully read configuration file '{configPath}'");
            return readResult.output;
        }

        protected virtual void OnInitialize() { }
        protected abstract void Process(String[] args);
    }
}