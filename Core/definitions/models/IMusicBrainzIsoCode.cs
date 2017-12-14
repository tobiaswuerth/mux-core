using System;
using System.Collections.Generic;

namespace ch.wuerth.tobias.mux.Core.definitions.models
{
    public interface IMusicBrainzIsoCode
    {
        Int32 UniqueId { get; set; }
        String Code { get; set; }

        // references

        IList<IMusicBrainzArea> Areas { get; set; }
    }
}