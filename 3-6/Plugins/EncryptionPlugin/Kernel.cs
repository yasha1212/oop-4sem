using System;
using System.Collections.Generic;
using System.Text;
using ThirdLaboratory;

namespace EncryptionPlugin
{
    public class Kernel : IFunctionalPlugin
    {
        public byte[] ProcessInput(byte[] data)
        {
            var cryptoService = new CryptoService();
            return cryptoService.Decrypt(data);
        }

        public byte[] ProcessOutput(byte[] data)
        {
            var cryptoService = new CryptoService();
            return cryptoService.Encrypt(data);
        }
    }
}
