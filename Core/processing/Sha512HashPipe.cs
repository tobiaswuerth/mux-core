using System;
using System.Security.Cryptography;
using System.Text;
using ch.wuerth.tobias.ProcessPipeline;

namespace ch.wuerth.tobias.mux.Core.processing
{
    public class Sha512HashPipe : ProcessPipe<String, String>
    {
        public Sha512HashPipe() : base(o =>
        {
            using (SHA512 shaM = new SHA512Managed())
            {
                Byte[] bData = Encoding.UTF8.GetBytes(o ?? String.Empty);
                Byte[] bHash = shaM.ComputeHash(bData);
                String hash = Convert.ToBase64String(bHash);
                return hash;
            }
        }) { }
    }
}