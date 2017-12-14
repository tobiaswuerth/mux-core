using System;

namespace ch.wuerth.tobias.mux.Core.models
{
    public interface IMusicBrainzAlias
    {
        Int32 UniqueId { get; set; }
        String UniqueHash { get; set; }
        String Begin { get; set; }
        String End { get; set; }
        Boolean Ended { get; set; }
        String Locale { get; set; }
        String Name { get; set; }
        String Primary { get; set; }
        String ShortName { get; set; }
        String Type { get; set; }
        String TypeId { get; set; }
    }
}