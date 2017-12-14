using System;
using System.Collections.Generic;

namespace ch.wuerth.tobias.mux.Core.definitions.models
{
    public interface ITrack
    {
        Int32 UniqueId { get; set; }
        Double? Duration { get; set; }
        String Fingerprint { get; set; }
        String FingerprintError { get; set; }
        String FingerprintHash { get; set; }
        DateTime? LastAcoustIdApiCall { get; set; }
        DateTime? LastFingerprintCalculation { get; set; }
        String Path { get; set; }

        // references 

        IList<IAcoustIdResult> AcoustIdResults { get; set; }
    }
}