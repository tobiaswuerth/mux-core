using System;
using System.Collections.Generic;

namespace ch.wuerth.tobias.mux.Core.definitions.models
{
    public interface IMusicBrainzTextRepresentation
    {
        Int32 UniqueId { get; set; }
        String UniqueHash { get; set; }
        String Language { get; set; }
        String Script { get; set; }

        // references

        IList<IMusicBrainzRelease> Releases { get; set; }
    }
}