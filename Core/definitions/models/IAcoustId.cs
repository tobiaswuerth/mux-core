using System;
using System.Collections.Generic;

namespace ch.wuerth.tobias.mux.Core.definitions.models
{
    public interface IAcoustId
    {
        Int32 UniqueId { get; set; }
        String Id { get; set; }

        // references

        IList<IAcoustIdResult> AcoustIdResults { get; set; }
        IList<IMusicBrainzRecord> MusicbrainzRecords { get; set; }
    }
}