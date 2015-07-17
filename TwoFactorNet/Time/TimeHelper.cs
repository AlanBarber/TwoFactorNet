using System;

namespace TwoFactorNet.Time
{
    public class TimeHelper
    {
        /// <summary>
        /// Gets the next cycle time.
        /// </summary>
        /// <returns></returns>
        public static DateTime GetNextCycleTimeUtc()
        {
            return GetNextCycleTimeUtc(DateTime.UtcNow, 30);
        }

        /// <summary>
        /// Gets the next cycle time.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <param name="timeInterval">The time interval.</param>
        /// <returns></returns>
        public static DateTime GetNextCycleTimeUtc(DateTime dateTime, int timeInterval)
        {
            // DateTime.Now.AddSeconds(-DateTime.Now.Second).AddSeconds(DateTime.Now.Second < 30 ? 30 : 60);
            long unixTime = UnixTime.GetUnixTime(dateTime);
            long intervalTimestamp = unixTime / timeInterval;
            intervalTimestamp++;
            return UnixTime.GetDateTime(intervalTimestamp * timeInterval);
        }
    }
}