using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TwoFactorNet.Tests
{
    /*
    Note: All test values come from "Appendix B.  Test Vectors"
    on the RFC 6238 http://tools.ietf.org/html/rfc6238#appendix-B
    We are only using the test values for SHA1 as this is the standard
    that everyone is currently using, such as the Google Authenticator.

        The test token shared secret uses the ASCII string value
        "12345678901234567890".  With Time Step X = 30, and the Unix epoch as
        the initial value to count time steps, where T0 = 0, the TOTP
        algorithm will display the following values for specified modes and
        timestamps.

        +-------------+--------------+------------------+----------+--------+
        |  Time (sec) |   UTC Time   | Value of T (hex) |   TOTP   |  Mode  |
        +-------------+--------------+------------------+----------+--------+
        |      59     |  1970-01-01  | 0000000000000001 | 94287082 |  SHA1  |
        |             |   00:00:59   |                  |          |        |
        |  1111111109 |  2005-03-18  | 00000000023523EC | 07081804 |  SHA1  |
        |             |   01:58:29   |                  |          |        |
        |  1111111111 |  2005-03-18  | 00000000023523ED | 14050471 |  SHA1  |
        |             |   01:58:31   |                  |          |        |
        |  1234567890 |  2009-02-13  | 000000000273EF07 | 89005924 |  SHA1  |
        |             |   23:31:30   |                  |          |        |
        |  2000000000 |  2033-05-18  | 0000000003F940AA | 69279037 |  SHA1  |
        |             |   03:33:20   |                  |          |        |
        | 20000000000 |  2603-10-11  | 0000000027BC86AA | 65353130 |  SHA1  |
        |             |   11:33:20   |                  |          |        |
        +-------------+--------------+------------------+----------+--------+
                                Table 1: TOTP Table
    */

    [TestClass]
    public class TotpTests
    {
        [TestMethod]
        public void GenerateTotpWithTime59()
        {
            byte[] secret = System.Text.Encoding.ASCII.GetBytes("12345678901234567890");
            int passwordSize = 8;
            int timeInterval = 30;
            string expectedTotp = "94287082";
            long unixTime = 59;

            Totp otp = new Totp(secret, passwordSize, timeInterval);
            string generatedTotp = otp.GeneratePassword(unixTime);

            Assert.AreEqual(expectedTotp, generatedTotp);
        }

        [TestMethod]
        public void GenerateTotpWithTime1111111109()
        {
            byte[] secret = System.Text.Encoding.ASCII.GetBytes("12345678901234567890");
            int passwordSize = 8;
            int timeInterval = 30;
            string expectedTotp = "07081804";
            long unixTime = 1111111109;

            Totp otp = new Totp(secret, passwordSize, timeInterval);
            string generatedTotp = otp.GeneratePassword(unixTime); 

            Assert.AreEqual(expectedTotp, generatedTotp);
        }

        [TestMethod]
        public void GenerateTotpWithTime1111111111()
        {
            byte[] secret = System.Text.Encoding.ASCII.GetBytes("12345678901234567890");
            int passwordSize = 8;
            int timeInterval = 30;
            string expectedTotp = "14050471";
            long unixTime = 1111111111;

            Totp otp = new Totp(secret, passwordSize, timeInterval);
            string generatedTotp = otp.GeneratePassword(unixTime);

            Assert.AreEqual(expectedTotp, generatedTotp);
        }

        [TestMethod]
        public void GenerateTotpWithTime1234567890()
        {
            byte[] secret = System.Text.Encoding.ASCII.GetBytes("12345678901234567890");
            int passwordSize = 8;
            int timeInterval = 30;
            string expectedTotp = "89005924";
            long unixTime = 1234567890;

            Totp otp = new Totp(secret, passwordSize, timeInterval);
            string generatedTotp = otp.GeneratePassword(unixTime);

            Assert.AreEqual(expectedTotp, generatedTotp);
        }

        [TestMethod]
        public void GenerateTotpWithTime2000000000()
        {

            byte[] secret = System.Text.Encoding.ASCII.GetBytes("12345678901234567890");
            int passwordSize = 8;
            int timeInterval = 30;
            string expectedTotp = "69279037";
            long unixTime = 2000000000;

            Totp otp = new Totp(secret, passwordSize, timeInterval);
            string generatedTotp = otp.GeneratePassword(unixTime);

            Assert.AreEqual(expectedTotp, generatedTotp);
        }

        [TestMethod]
        public void GenerateTotpWithTime20000000000()
        {

            byte[] secret = System.Text.Encoding.ASCII.GetBytes("12345678901234567890");
            int passwordSize = 8;
            int timeInterval = 30;
            string expectedTotp = "65353130";
            long unixTime = 20000000000;

            Totp otp = new Totp(secret, passwordSize, timeInterval);
            string generatedTotp = otp.GeneratePassword(unixTime);

            Assert.AreEqual(expectedTotp, generatedTotp);
        }
    }
}
