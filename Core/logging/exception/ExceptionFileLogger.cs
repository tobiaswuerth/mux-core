﻿using System;
using System.IO;
using System.Text;
using ch.wuerth.tobias.mux.Core.events;
using ch.wuerth.tobias.mux.Core.exceptions;
using ch.wuerth.tobias.mux.Core.processor;
using global::ch.wuerth.tobias.mux.Core.global;

namespace ch.wuerth.tobias.mux.Core.logging.exception
{
    public class ExceptionFileLogger : ExceptionLogger
    {
        private readonly IProcessor<Exception, String> _processor = new ExceptionProcessor();

        public ExceptionFileLogger(ICallback<Exception> exceptionCallback) : base(exceptionCallback) { }

        public static String LogFilePath
        {
            get
            {
                return Path.Combine(Location.LogsDirectoryPath, $"mux_log_exception-{DateTime.Now:yyyyMMdd}.log");
            }
        }

        protected override Boolean Process(Exception obj, LogMessageFlags flags)
        {
            if (null == obj)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            (String output, Boolean success) res = _processor.Handle(obj
                , new LoggerBundle
                {
                    Exception = this
                });
            if (!res.success)
            {
                throw new ProcessAbortedException();
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(DateTimePrefix);
            sb.Append("An exception occurred");
            sb.Append(Environment.NewLine);
            sb.Append("##### EXCEPTION BEGIN #####");
            sb.Append(Environment.NewLine);
            sb.Append(res.output);
            sb.Append("###### EXCEPTION END ######");

            if (!flags.HasFlag(LogMessageFlags.NoNewline))
            {
                sb.Append(Environment.NewLine);
            }

            File.AppendAllText(LogFilePath, sb.ToString());
            return true;
        }
    }
}