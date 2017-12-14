using System;
using System.Collections.Generic;

namespace ch.wuerth.tobias.mux.Core.definitions.models
{
    public interface IMusicBrainzArtistCredit
    {
        Int32 UniqueId { get; set; }
        String UniqueHash { get; set; }
        String Joinphrase { get; set; }
        String Name { get; set; }

        // references

        IMusicBrainzArtist Artist { get; set; }
        IList<IMusicBrainzRecord> Records { get; set; }
        IList<IMusicBrainzRelease> Releases { get; set; }
    }
}