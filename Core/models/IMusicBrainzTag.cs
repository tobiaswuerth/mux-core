using System;

namespace ch.wuerth.tobias.mux.Core.models
{
    public interface IMusicBrainzTag
    {
        Int32 UniqueId { get; set; }
        String UniqueHash { get; set; }
        Int32 Count { get; set; }
        String Name { get; set; }
    }
}