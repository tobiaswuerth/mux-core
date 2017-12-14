using System;

namespace ch.wuerth.tobias.mux.Core.models
{
    public interface IAcoustIdResult
    {
        Int32 UniqueId { get; set; }
        Double Score { get; set; }
    }
}