using System;
using System.Text;
using ch.wuerth.tobias.mux.Core.processing;
using ch.wuerth.tobias.ProcessPipeline;
using ch.wuerth.tobias.ProcessPipeline.pipes;

namespace ch.wuerth.tobias.mux.Core.logging
{
    public abstract class Logger
    {
        public static LogFlags DefaultLogFlags = LogFlags.PrefixLoggerType | LogFlags.PrefixTimeStamp | LogFlags.SuffixNewLine;
        private ProcessPipe<String, String> _executeLogPipe;

        private Boolean _isInitialized;
        private ProcessPipe<Object, String> _prepareLogPipe;

        protected Logger(LogTypes type)
        {
            Type = type;
        }

        public LogTypes Type { get; }

        private void Initialize()
        {
            LoggerBundle.Inform($"Initializing logger of type '{Type}'...");

            _prepareLogPipe = new ValidationPipe<Object>(o => o != null) // validate
                .Connect(new ConditionalPipe<Object, String>(o => o is Exception
                    , new CasterPipe<Object, Exception>().Connect(new ExceptionStringifierPipe())
                    , new ProcessPipe<Object, String>(o => o.ToString()))) // object -> string
                .Connect(new ValidationPipe<String>(o => !String.IsNullOrWhiteSpace(o))) // validate
                .Connect(new ProcessPipe<String, String>(s => s.Trim())); // trim

            _executeLogPipe = GetExecuteLogPipe();

            _isInitialized = true;

            LoggerBundle.Inform($"Done initializing logger of type '{Type}'");
        }

        protected abstract ProcessPipe<String, String> GetExecuteLogPipe();

        public void Log(LogFlags flags, params Object[] args)
        {
            if (!_isInitialized)
            {
                Initialize();
            }

            StringBuilder sb = new StringBuilder();
            ProcessPipe<Object, String> preparePipe = _prepareLogPipe.Connect(new LogFlagPipe(Type, flags));

            foreach (Object arg in args)
            {
                try
                {
                    sb.Append(preparePipe.Process(arg));
                }
                catch (Exception ex)
                {
                    BubbleException(flags, ex);
                }
            }

            _executeLogPipe.Process(sb.ToString());
        }

        private void BubbleException(LogFlags flags, Exception ex)
        {
            switch (Type)
            {
                case LogTypes.Trace:
                    LoggerBundle.Debug(flags, ex);
                    break;
                case LogTypes.Debug:
                    LoggerBundle.Inform(flags, ex);
                    break;
                case LogTypes.Info:
                    LoggerBundle.Warn(flags, ex);
                    break;
                case LogTypes.Warning:
                    LoggerBundle.Error(flags, ex);
                    break;
                case LogTypes.Error:
                    LoggerBundle.Fatal(flags, ex);
                    break;
                case LogTypes.Fatal:
                    throw ex;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Log(params Object[] args)
        {
            Log(DefaultLogFlags, args);
        }
    }
}