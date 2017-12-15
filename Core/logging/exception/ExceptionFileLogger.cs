﻿using System;
using System.IO;
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
            get { return Path.Combine(Location.LogsDirectoryPath, @"\mux_log_exceptions.log"); }
        }

        protected override Boolean Process(Exception obj)
        {
            if (null == obj)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            (String output, Boolean success) res = _processor.Handle(obj, new LoggerBundle {Exception = this});
            if (!res.success)
            {
                throw new ProcessAbortedException();
            }

            File.AppendAllText(LogFilePath, $"{DateTimePrefix} {res.output}");
            return true;
        }
    }
}