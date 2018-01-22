using System;
using ch.wuerth.tobias.mux.Core.exceptions;
using ch.wuerth.tobias.ProcessPipeline;

namespace ch.wuerth.tobias.mux.Core.processing
{
    public class ValidationPipe<T> : ProcessPipe<T, T>
    {
        public ValidationPipe(Func<T, Boolean> isValidIf) : base(o => isValidIf(o) ? o : throw new ValidationException()) { }
    }
}