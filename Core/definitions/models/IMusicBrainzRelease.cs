using System;
using System.Collections.Generic;

namespace ch.wuerth.tobias.mux.Core.definitions.models
{
    public interface IMusicBrainzRelease
    {
        Int32 UniqueId { get; set; }
        String UniqueHash { get; set; }
        String Barcode { get; set; }
        String Country { get; set; }
        DateTime? Date { get; set; }
        String Disambiguation { get; set; }
        String Id { get; set; }
        String PackagingId { get; set; }
        String Quality { get; set; }
        String Status { get; set; }
        String StatusId { get; set; }
        String Title { get; set; }

        // references

        IList<IMusicBrainzAlias> Aliases { get; set; }
        IList<IMusicBrainzArtistCredit> ArtistCredit { get; set; }
        IList<IMusicBrainzReleaseEvent> ReleaseEvents { get; set; }
        IMusicBrainzTextRepresentation TextRepresentation { get; set; }
        IList<IMusicBrainzRecord> MusicBrainzRecords { get; set; }
    }
}