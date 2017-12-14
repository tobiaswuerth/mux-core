using System;
using System.Collections.Generic;

namespace ch.wuerth.tobias.mux.Core.definitions.models
{
    public interface IMusicBrainzArtist
    {
        Int32 UniqueId { get; set; }
        String UniqueHash { get; set; }
        String Disambiguation { get; set; }
        String Name { get; set; }
        String SortName { get; set; }

        // references

        IList<IMusicBrainzAlias> Aliases { get; set; }
        IList<IMusicBrainzArtistCredit> Credits { get; set; }
    }
}