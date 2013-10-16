using System;
using System.Security.Cryptography;

namespace TwoFactorNet
{
    /// <summary>
    /// Base class for implementations of One-Time Password Algorithms
    /// </summary>
    public abstract class Otp
    {
        public byte[] Secret { get; set; }
        public long PasswordSize { get; set; }

        protected Otp()
        {
            Secret = new byte[0];
            PasswordSize = 6;
        }

        protected Otp(byte[] secret, int passwordSize)
        {
            Secret = secret;
            PasswordSize = passwordSize;
        }

        /// <summary>
        /// Generates a One Time Password.
        /// </summary>
        /// <param name="seed">The seed.</param>
        /// <returns></returns>
        public abstract string GeneratePassword(long seed);

        /// <summary>
        /// Calculates the password.
        /// </summary>
        /// <returns></returns>
        protected internal long CalculatePassword(long seed)
        {
            // Convert the seed (long) to a byte array & flip the array if the system is LittleEndian as specs demand seed be in high-order / BigEndian
            // examples 
            // (long) 255 => byte[8] {0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00} => {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF}
            // (long) 256 => byte[8] {0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00} => {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00}
            byte[] seedBytes = BitConverter.GetBytes(seed);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(seedBytes);

            // get a generator and compute a 20 byte HMAC-SHA1 hash from key + seed (normally a counter or time)
            HMAC hashGenerator = new HMACSHA1(Secret);
            byte[] calculatedHash = hashGenerator.ComputeHash(seedBytes);

            // using the last byte in the raw hash, mask it to grab the last 4 bits of this byte (basically a random number 0 (0000) - 15 (1111))
            // Use this as the starting offset to convert 4 consecutive bytes from the raw hash array 
            // into a 32bit int (thus a random value from 0 to 2,147,483,647) as the computedCode
            int offset = calculatedHash[19] & 0x0F;
            int computedCode =  (calculatedHash[offset + 0] & 0x7F) << 24 |
                                (calculatedHash[offset + 1] & 0xFF) << 16 |
                                (calculatedHash[offset + 2] & 0xFF) << 8  |
                                (calculatedHash[offset + 3] & 0xFF);

            // take computedCode modulo 10^PasswordSize to return a value that is the max length of the PasswordSize or less
            // example
            // 1234567890 % 10^6 = 567890
            // 1234 % 10^6 = 1234
            return (computedCode % Convert.ToInt32(Math.Pow(10, PasswordSize)));
        }
    }
}