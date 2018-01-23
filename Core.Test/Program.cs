using System;
using ch.wuerth.tobias.mux.Core.logging;

namespace ch.wuerth.tobias.mux.Core.Test
{
    internal class Program
    {
        private static void Main(String[] args)
        {
            // mainly for debugging
            LoggerBundle.Trace("TEST");
            LoggerBundle.Debug("TEST");
            LoggerBundle.Inform("TEST");
            LoggerBundle.Warn(new Exception());
            LoggerBundle.Error(new Exception());
            LoggerBundle.Fatal(new Exception());
        }
    }
}