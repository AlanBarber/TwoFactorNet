using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwoFactorNet.Time;
namespace TwoFactorNet.Tests
{
    [TestClass]
    public class TimeHelperTests
    {
        [TestMethod]
        public void GetNextCycleTimeUtcEpochPlus30()
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime expectedNextCycleTime = new DateTime(1970, 1, 1, 0, 0, 30, DateTimeKind.Utc);

            DateTime generatedNextCycleTime = TimeHelper.GetNextCycleTimeUtc(epoch, 30);

            Assert.AreEqual(expectedNextCycleTime, generatedNextCycleTime);
        }

        [TestMethod]
        public void GetNextCycleTimeUtcEpochPlus60()
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime expectedNextCycleTime = new DateTime(1970, 1, 1, 0, 1, 0, DateTimeKind.Utc);

            DateTime generatedNextCycleTime = TimeHelper.GetNextCycleTimeUtc(epoch, 60);

            Assert.AreEqual(expectedNextCycleTime, generatedNextCycleTime);
        }
    }
}
