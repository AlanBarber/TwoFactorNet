using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace TwoStepNet
{
    /// <summary>
    /// Base class for implementations of One-Time Password Algorithms
    /// </summary>
    public abstract class Otp
    {
        public string Secret { get; set; }
        public long PasswordSize { get; set; }

        protected Otp()
        {
            Secret = string.Empty;
            PasswordSize = 6;
        }

        protected Otp(string secret, int passwordSize)
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
            byte[] encodedSecretBytes = Encoding.ASCII.GetBytes(Secret);
            byte[] seedBytes = BitConverter.GetBytes(seed);
            Array.Reverse(seedBytes);

            HMAC hashGenerator = new HMACSHA1(encodedSecretBytes);
            byte[] calculatedHash = hashGenerator.ComputeHash(seedBytes);

            int offset = calculatedHash[19] & 0x0F;
            int computedCode =  (calculatedHash[offset + 0] & 0x7F) << 24 |
                                (calculatedHash[offset + 1] & 0xFF) << 16 |
                                (calculatedHash[offset + 2] & 0xFF) << 8  |
                                (calculatedHash[offset + 3] & 0xFF);

            return (computedCode % Convert.ToInt32(Math.Pow(10, PasswordSize)));
        }
    }
}