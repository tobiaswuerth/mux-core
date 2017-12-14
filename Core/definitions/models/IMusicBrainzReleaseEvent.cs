using System;
using System.Collections.Generic;

namespace ch.wuerth.tobias.mux.Core.definitions.models
{
    public interface IMusicBrainzReleaseEvent
    {
        Int32 UniqueId { get; set; }
        String UniqueHash { get; set; }
        DateTime? Date { get; set; }

        // references

        IMusicBrainzArea Area { get; set; }
        IList<IMusicBrainzRelease> Releases { get; set; }
    }
}