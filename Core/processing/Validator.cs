using ch.wuerth.tobias.ProcessPipeline;

namespace ch.wuerth.tobias.mux.Core.processing
{
    public class Validator<T> : ProcessPipe<T, T>
    {
        public delegate void ValidationEvent(T obj);

        private readonly ValidationEvent _validationEvent;

        public Validator(ValidationEvent validationEvent)
        {
            _validationEvent = validationEvent;
        }

        protected override T OnProcess(T obj)
        {
            _validationEvent.Invoke(obj);
            return obj;
        }
    }
}