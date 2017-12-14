using System;

namespace ch.wuerth.tobias.mux.Core.models
{
    public interface IUser
    {
        Int32 UniqueId { get; set; }
        String Username { get; set; }
        String Password { get; set; }
    }
}