using System;
using System.Collections.Generic;
using System.Text;

namespace EncryptionPlugin
{
    public interface IEncoder
    {
        byte[] Encrypt(byte[] data);

        byte[] Decrypt(byte[] data);
    }
}
