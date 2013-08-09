using System;
using System.Globalization;

namespace TwoFactorNet
{
    /// <summary>
    /// Implementation of HMAC-Based One-Time Password (RFC 4226)
    /// </summary>
    public class Hotp : Otp
    {
        public Hotp() : base() {}
        
        public Hotp(string secret, int passwordSize) : base(secret,passwordSize){}


        /// <summary>
        /// Generates a HMAC-Based One-Time Password for a given counter value.
        /// </summary>
        /// <param name="counter">The counter.</param>
        /// <returns></returns>
        public override string GeneratePassword(long counter)
        {
            return CalculatePassword(counter).ToString(CultureInfo.InvariantCulture);
        }
    }
}
