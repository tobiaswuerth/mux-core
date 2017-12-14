using System;

namespace ch.wuerth.tobias.mux.Core.models
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
    }
}