using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwoFactorNet.Time;

namespace TwoFactorNet.Tests
{
    [TestClass]
    public class UnixTimeTests
    {
        [TestMethod]
        public void UnixTime0IsDateTimeEpoch()
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            DateTime dateTime = UnixTime.GetDateTime(0);

            Assert.AreEqual(epoch, dateTime);
        }

        [TestMethod]
        public void UnixTime1000000000IsDateTime2001_09_09T01_46_40Z()
        {
            DateTime expectedDateTime = new DateTime(2001, 9, 9, 1, 46, 40, DateTimeKind.Utc);

            DateTime dateTime = UnixTime.GetDateTime(1000000000);

            Assert.AreEqual(expectedDateTime, dateTime);
        }

        [TestMethod]
        public void UnixTime4294967295IsDateTime2106_02_07T06_28_15Z()
        {
            DateTime expectedDateTime = new DateTime(2106, 2, 7, 6, 28, 15, DateTimeKind.Utc);

            DateTime dateTime = UnixTime.GetDateTime(4294967295);

            Assert.AreEqual(expectedDateTime, dateTime);            
        }

        [TestMethod]
        public void DateTimeEpochIsUnixTime0()
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            long unixTime = UnixTime.GetUnixTime(epoch);

            Assert.AreEqual(0, unixTime);
        }

        [TestMethod]
        public void DateTime2001_09_09T01_46_40ZIsUnixTime1000000000()
        {
            DateTime dateTime = new DateTime(2001, 9, 9, 1, 46, 40, DateTimeKind.Utc);

            long unixTime = UnixTime.GetUnixTime(dateTime);

            Assert.AreEqual(1000000000, unixTime);
        }


        [TestMethod]
        public void DateTime2106_02_07T06_28_15ZIsUnixTime4294967295()
        {
            DateTime dateTime = new DateTime(2106, 2, 7, 6, 28, 15, DateTimeKind.Utc);

            long unixTime = UnixTime.GetUnixTime(dateTime);

            Assert.AreEqual(4294967295, unixTime);
        }
    }
}
