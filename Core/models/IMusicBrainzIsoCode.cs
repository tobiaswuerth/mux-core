using System;

namespace ch.wuerth.tobias.mux.Core.models
{
    public interface IMusicBrainzIsoCode
    {
        Int32 UniqueId { get; set; }
        String Code { get; set; }
    }
}