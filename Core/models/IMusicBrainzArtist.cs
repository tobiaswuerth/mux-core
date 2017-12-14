using System;

namespace ch.wuerth.tobias.mux.Core.models
{
    public interface IMusicBrainzArtist
    {
        Int32 UniqueId { get; set; }
        String UniqueHash { get; set; }
        String Disambiguation { get; set; }
        String Name { get; set; }
        String SortName { get; set; }
    }
}