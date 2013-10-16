using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TwoFactorNet.Tests
{
    [TestClass]
    public class KeyUriTests
    {
        [TestMethod]
        public void ToptUri()
        {
            string expectedKeyUri = @"otpauth://totp/TwoFactorNet:TestUser%40TwoFactorNet?issuer=TwoFactorNet&secret=1111222233334444&digits=6&period=30";

            string KeyUri = Generator.KeyUri.GetToptUri("TwoFactorNet", "TestUser@TwoFactorNet", "1111222233334444");

            Assert.AreEqual(expectedKeyUri, KeyUri);
        }

        [TestMethod]
        public void HotpUri()
        {
            string expectedKeyUri = @"otpauth://hotp/TwoFactorNet:TestUser%40TwoFactorNet?issuer=TwoFactorNet&secret=1111222233334444&digits=6&counter=0";

            string keyUri = Generator.KeyUri.GetHotpUri("TwoFactorNet", "TestUser@TwoFactorNet", "1111222233334444");

            Assert.AreEqual(expectedKeyUri, keyUri);
        }
    }
}