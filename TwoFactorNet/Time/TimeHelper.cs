using System;

namespace TwoFactorNet.Time
{
    public class TimeHelper
    {
        public static DateTime GetNextCycleTime()
        {
            return DateTime.Now.AddSeconds(-DateTime.Now.Second).AddSeconds(DateTime.Now.Second < 30 ? 30 : 60);
        }
    }
}