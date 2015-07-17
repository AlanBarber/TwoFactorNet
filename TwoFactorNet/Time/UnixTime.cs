using System;

namespace TwoFactorNet.Time
{
    /// <summary>
    /// UnixTime or POSIX Time is a measure of the number of seconds 
    /// that have elapsed since January 1st, 1970 at Midnight.
    /// </summary>
    public class UnixTime
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Gets the current unix time.
        /// </summary>
        /// <returns></returns>
        public static long GetUnixTime()
        {
            return GetUnixTime(DateTime.UtcNow);
        }

        /// <summary>
        /// Gets the unix time for a specific DateTime.
        /// </summary>
        /// <param name="dateTime">The date time you want converted.</param>
        /// <returns></returns>
        public static long GetUnixTime(DateTime dateTime)
        {
            return (long)(dateTime - Epoch).TotalSeconds;
        }

        /// <summary>
        /// Gets the UTC DateTime for a specific UnixTime value.
        /// </summary>
        /// <param name="unixTime">The UnixTime.</param>
        /// <returns></returns>
        public static DateTime GetDateTime(long unixTime)
        {
            return Epoch.AddSeconds(unixTime).ToUniversalTime();
        }
    }
}
