using System;
using System.Collections.Generic;

namespace ch.wuerth.tobias.mux.Core.definitions.models
{
    public interface IMusicBrainzRecord
    {
        Int32 UniqueId { get; set; }
        String Disambiguation { get; set; }
        DateTime? LastMusicBrainzApiCall { get; set; }
        Int32? Length { get; set; }
        String MusicBrainzApiCallError { get; set; }
        String MusicbrainzId { get; set; }
        String Title { get; set; }
        Boolean? Video { get; set; }

        // references 

        IList<IAcoustId> AcoustIds { get; set; }
        IList<IMusicBrainzAlias> Aliases { get; set; }
        IList<IMusicBrainzArtistCredit> ArtistCredit { get; set; }
        IList<IMusicBrainzRelease> Releases { get; set; }
        IList<IMusicBrainzTag> Tags { get; set; }
    }
}