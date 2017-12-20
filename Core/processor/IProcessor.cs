using System;
using ch.wuerth.tobias.mux.Core.logging;

namespace ch.wuerth.tobias.mux.Core.processor
{
    public interface IProcessor<in TFrom, TTo>
    {
        (TTo output, Boolean success) Handle(TFrom input, LoggerBundle logger);
    }
}