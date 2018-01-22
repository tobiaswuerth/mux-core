using ch.wuerth.tobias.mux.Core.logging;
using ch.wuerth.tobias.mux.Core.logging.logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ch.wuerth.tobias.mux.Core.Test
{
    [ TestClass ]
    public class Tests
    {
        [ TestMethod ]
        public void TestLoggerBundle()
        {
            // to allow for static constructor to be invoked
            LoggerBundle.Register(new ConsoleLogger(LogTypes.Trace));
        }
    }
}