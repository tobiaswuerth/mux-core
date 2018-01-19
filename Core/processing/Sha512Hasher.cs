using System;
using System.Security.Cryptography;
using System.Text;
using ch.wuerth.tobias.ProcessPipeline;

namespace ch.wuerth.tobias.mux.Core.processing
{
    public class Sha512Hasher : ProcessPipe<String, String>
    {
        protected override String OnProcess(String obj)
        {
            using (SHA512 shaM = new SHA512Managed())
            {
                Byte[] bData = Encoding.UTF8.GetBytes(obj ?? String.Empty);
                Byte[] bHash = shaM.ComputeHash(bData);
                String hash = Convert.ToBase64String(bHash);
                return hash;
            }
        }
    }
}