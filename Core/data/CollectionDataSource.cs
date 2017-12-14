using System.Collections.Generic;

namespace ch.wuerth.tobias.mux.Core.data
{
    public class CollectionDataSource<T> : DataSource<T>
    {
        private readonly IEnumerable<T> _data;

        public CollectionDataSource(IEnumerable<T> data)
        {
            _data = data;
        }

        public override IEnumerable<T> Get()
        {
            return _data;
        }
    }
}