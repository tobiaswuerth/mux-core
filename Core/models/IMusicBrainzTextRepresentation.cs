using System;

namespace ch.wuerth.tobias.mux.Core.models
{
    public interface IMusicBrainzTextRepresentation
    {
        Int32 UniqueId { get; set; }
        String UniqueHash { get; set; }
        String Language { get; set; }
        String Script { get; set; }
    }
}