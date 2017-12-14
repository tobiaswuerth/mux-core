using System;
using ch.wuerth.tobias.mux.Core.events;

namespace ch.wuerth.tobias.mux.Core.processor
{
    public interface IProcessor<in TFrom, TTo>
    {
        (TTo output, Boolean success) Handle(TFrom input, ICallback<Exception> onException = null);
    }
}