using System;
using System.Collections.Generic;

namespace ch.wuerth.tobias.mux.Core.definitions.models
{
    public interface IMusicBrainzTag
    {
        Int32 UniqueId { get; set; }
        String UniqueHash { get; set; }
        Int32 Count { get; set; }
        String Name { get; set; }

        // references

        IList<IMusicBrainzRecord> Records { get; set; }
    }
}