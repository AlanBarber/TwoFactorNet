using System;
using System.Globalization;

namespace TwoStepNet
{
    /// <summary>
    /// Implementation of Time-Based One-Time Password (RFC 6238)
    /// </summary>
    public class Totp : Otp
    {
        public int TimeInterval { get; set; }
        
        public Totp() : base()
        {
            TimeInterval = 30;
        }
        
        public Totp(string secret, int passwordSize) : base(secret, passwordSize)
        {
            TimeInterval = 30;
        }        

        public Totp(string secret, int passwordSize, int timeInterval) : base(secret, passwordSize)
        {
            TimeInterval = timeInterval;
        }

        /// <summary>
        /// Generates a Time-Based One-Time Password for a given timestamp 
        /// (This is Unix time / number of seconds since '1970-01-01 00:00:00 UTC')
        /// </summary>
        /// <param name="timestamp">The timestamp (Unix time).</param>
        /// <returns></returns>
        public override string GeneratePassword(long timestamp)
        {
            long intervalTimestamp = timestamp / TimeInterval;
            return CalculatePassword(intervalTimestamp).ToString("D" + PasswordSize);
        }




    }
}