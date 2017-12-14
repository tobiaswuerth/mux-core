using System;
using ch.wuerth.tobias.mux.Core.events;

namespace ch.wuerth.tobias.mux.Core.logging
{
    public class InformationConsoleLogger : Logger<String>
    {
        public override Boolean Log(String obj, ICallback<Exception> onError = null)
        {
            try
            {
                Console.WriteLine($"{DateTimePrefix} {obj}");
                return true;
            }
            catch (Exception ex)
            {
                onError?.Push(ex);
                return false;
            }
        }
    }
}