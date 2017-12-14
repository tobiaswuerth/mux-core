using System;

namespace ch.wuerth.tobias.mux.Core.models
{
    public interface IMusicBrainzArea
    {
        Int32 UniqueId { get; set; }
        String Disambiguation { get; set; }
        String Id { get; set; }
        String Name { get; set; }
        String SortName { get; set; }
    }
}