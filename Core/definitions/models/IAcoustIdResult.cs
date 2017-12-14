using System;

namespace ch.wuerth.tobias.mux.Core.definitions.models
{
    public interface IAcoustIdResult
    {
        Int32 UniqueId { get; set; }
        Double Score { get; set; }

        // references 

        ITrack Track { get; set; }
        IAcoustId AcoustId { get; set; }
    }
}