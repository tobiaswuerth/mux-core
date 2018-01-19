using System;
using ch.wuerth.tobias.ProcessPipeline;

namespace ch.wuerth.tobias.mux.Core.processing
{
    public class CustomParser<TFrom, TTo> : ProcessPipe<TFrom, TTo>
    {
        public delegate TTo ParseEvent(TFrom obj);

        private readonly ParseEvent _parseEvent;

        public CustomParser(ParseEvent parseEvent)
        {
            _parseEvent = parseEvent ?? throw new ArgumentNullException(nameof(parseEvent));
        }

        protected override TTo OnProcess(TFrom obj)
        {
            return _parseEvent.Invoke(obj);
        }
    }
}