using System;
using System.Security.Cryptography;

namespace TwoFactorNet.Generator
{
    public class RandomKey
    {
        private static readonly byte[] ValidBase32Characters = new byte[32]
        {
            0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4a, 0x4b, 0x4c, 0x4d, 0x4e, 0x4f, 0x50, // ABCDEFGHIJKLMNOP
            0x51, 0x52, 0x53, 0x54, 0x55, 0x56, 0x57, 0x58, 0x59, 0x5a, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37  // QRSTUVWXYZ234567
        };

        private static readonly int EncodedKeySize = 16;

        public static string GetRandomEncodedKey()
        {
            string encodedKey = string.Empty;
            for (int i = 0; i < EncodedKeySize; i++)
            {
                encodedKey += GetValidBase32Character();
            }
            return encodedKey;
        }

        private static string GetValidBase32Character()
        {
            var rngByte = new byte[1];
            var rngCsp = new RNGCryptoServiceProvider();
            while (!Array.Exists(ValidBase32Characters, e => e == rngByte[0]))
            {
                rngCsp.GetBytes(rngByte);
            }
            return System.Text.Encoding.ASCII.GetString(rngByte);
        }

    }
}
