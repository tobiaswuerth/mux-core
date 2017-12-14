using ch.wuerth.tobias.mux.Core.logging.exception;
using ch.wuerth.tobias.mux.Core.logging.information;

namespace ch.wuerth.tobias.mux.Core.logging
{
    public class LoggerBundle
    {
        public InformationLogger Information { get; set; }
        public ExceptionLogger Exception { get; set; }
    }
}