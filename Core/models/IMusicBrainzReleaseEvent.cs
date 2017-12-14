using System;

namespace ch.wuerth.tobias.mux.Core.models
{
    public interface IMusicBrainzReleaseEvent
    {
        Int32 UniqueId { get; set; }
        String UniqueHash { get; set; }
        DateTime? Date { get; set; }
    }
}