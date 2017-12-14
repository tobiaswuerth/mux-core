using System;

namespace ch.wuerth.tobias.mux.Core.models
{
    public interface IAcoustId
    {
        Int32 UniqueId { get; set; }
        String Id { get; set; }
    }
}