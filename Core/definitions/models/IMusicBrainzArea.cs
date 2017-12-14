using System;
using System.Collections.Generic;

namespace ch.wuerth.tobias.mux.Core.definitions.models
{
    public interface IMusicBrainzArea
    {
        Int32 UniqueId { get; set; }
        String Disambiguation { get; set; }
        String Id { get; set; }
        String Name { get; set; }
        String SortName { get; set; }

        // references 

        IList<IMusicBrainzIsoCode> Iso31661Codes { get; set; }
        IList<IMusicBrainzReleaseEvent> ReleaseEvents { get; set; }
    }
}