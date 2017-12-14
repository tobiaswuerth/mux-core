using System.Collections.Generic;

namespace ch.wuerth.tobias.mux.Core.data
{
    public abstract class DataSource<T>
    {
        public abstract IEnumerable<T> Get();
    }
}