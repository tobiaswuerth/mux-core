using System;

namespace ch.wuerth.tobias.mux.Core.logging
{
    [ Flags ]
    public enum LogMessageFlags
    {
        NoNewline = 1 << 0
    }
}