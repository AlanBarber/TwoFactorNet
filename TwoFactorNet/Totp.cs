using System;
using TwoFactorNet.Time;

namespace TwoFactorNet
{
    /// <summary>
    /// Implementation of Time-Based One-Time Password (RFC 6238)
    /// </summary>
    public class Totp : Otp
    {
        public int TimeInterval { get; set; }
        
        public Totp()
        {
            TimeInterval = 30;
        }
        
        public Totp(byte[] secretKey, int passwordSize) : base(secretKey, passwordSize)
        {
            TimeInterval = 30;
        }        

        public Totp(byte[] secretKey, int passwordSize, int timeInterval) : base(secretKey, passwordSize)
        {
            TimeInterval = timeInterval;
        }

        /// <summary>
        /// Generates a Time-Based One-Time Password for the current time
        /// </summary>
        /// <returns></returns>
        public string GeneratePassword()
        {
            long currentUnixTime = UnixTime.GetUnixTime();
            return GeneratePassword(currentUnixTime);
        }

        /// <summary>
        /// Generates a Time-Based One-Time Password for a given DateTime
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public string GeneratePassword(DateTime dateTime)
        {
            long givenUnixTime = UnixTime.GetUnixTime(dateTime);
            return GeneratePassword(givenUnixTime);
        }

        /// <summary>
        /// Generates a Time-Based One-Time Password for a given time counter 
        /// (This is Unix time / number of seconds since '1970-01-01 00:00:00 UTC')
        /// </summary>
        /// <param name="timeCounter">The timestamp (Unix time).</param>
        /// <returns></returns>
        public override string GeneratePassword(long timeCounter)
        {
            long intervalTimeCounter = timeCounter / TimeInterval;
            return CalculatePassword(intervalTimeCounter).ToString("D" + PasswordSize);
        }
    }
}