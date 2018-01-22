using System;

namespace ch.wuerth.tobias.mux.Core.logging
{
    [ Flags ]
    public enum LogFlags
    {
        None = 0
        , SuffixNewLine = 1 << 0
        , PrefixTimeStamp = 1 << 1
        , PrefixLoggerType = 1 << 2
    }
}