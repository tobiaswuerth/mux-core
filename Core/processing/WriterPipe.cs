using System;
using System.IO;
using ch.wuerth.tobias.ProcessPipeline;

namespace ch.wuerth.tobias.mux.Core.processing
{
    public class WriterPipe : ProcessPipe<String, String>, IDisposable
    {
        private readonly TextWriter _stream;

        public WriterPipe(TextWriter stream) : base(o =>
        {
            stream.Write(o ?? String.Empty);
            stream.Flush();
            return o;
        })
        {
            _stream = stream ?? throw new ArgumentNullException(nameof(stream));
        }

        public void Dispose()
        {
            try
            {
                _stream?.Flush();
                _stream?.Close();
                _stream?.Dispose();
            }
            catch (Exception)
            {
                // ignore
            }
        }

        ~WriterPipe()
        {
            Dispose();
        }
    }
}