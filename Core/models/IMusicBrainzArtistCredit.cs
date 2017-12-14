using System;

namespace ch.wuerth.tobias.mux.Core.models
{
    public interface IMusicBrainzArtistCredit
    {
        Int32 UniqueId { get; set; }
        String UniqueHash { get; set; }
        String Joinphrase { get; set; }
        String Name { get; set; }
    }
}