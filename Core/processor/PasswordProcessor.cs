using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using ch.wuerth.tobias.mux.Core.logging;

namespace ch.wuerth.tobias.mux.Core.processor
{
    public class PasswordProcessor : IProcessor<String, String>
    {
        public (String output, Boolean success) Handle(String input, LoggerBundle logger)
        {
            try
            {
                using (SHA512 shaM = new SHA512Managed())
                {
                    Byte[] bData = Encoding.UTF8.GetBytes(input ?? String.Empty);
                    Byte[] bHash = shaM.ComputeHash(bData);
                    String hash = Convert.ToBase64String(bHash);
                    return (hash, true);
                }
            }
            catch (Exception ex)
            {
                logger?.Exception?.Log(ex);
                return (null, false);
            }
        }
    }
}