using System;
using System.IO;
using ch.wuerth.tobias.ProcessPipeline;

namespace ch.wuerth.tobias.mux.Core.processing
{
    public class Writer : ProcessPipe<(String format, Object[] args), (String format, Object[] args)>, IDisposable
    {
        private readonly TextWriter _writer;

        public Writer(TextWriter stream)
        {
            _writer = stream ?? throw new ArgumentNullException(nameof(stream));
        }

        public void Dispose()
        {
            _writer.Dispose();
        }

        ~Writer()
        {
            Dispose();
        }

        protected override (String format, Object[] args) OnProcess((String format, Object[] args) obj)
        {
            _writer.Write(obj.format, obj.args);
            return obj;
        }
    }
}