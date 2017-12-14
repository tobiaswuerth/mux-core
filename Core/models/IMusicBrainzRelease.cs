using System;

namespace ch.wuerth.tobias.mux.Core.models
{
    public interface IMusicBrainzRelease
    {
        Int32 UniqueId { get; set; }
        String UniqueHash { get; set; }
        String Barcode { get; set; }
        String Country { get; set; }
        DateTime? Date { get; set; }
        String Disambiguation { get; set; }
        String Id { get; set; }
        String PackagingId { get; set; }
        String Quality { get; set; }
        String Status { get; set; }
        String StatusId { get; set; }
        String Title { get; set; }
    }
}