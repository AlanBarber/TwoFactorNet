using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TwoFactorNet.Tests
{
    [TestClass]
    public class Base32Tests
    {
        [TestMethod]
        public void EncodeHelloWorldToBase32()
        {
            string plainText = "Hello, World!";
            string encodedText = "JBSWY3DPFQQFO33SNRSCC===";

            string val = Base32.Encode(plainText) ;

            Assert.AreEqual(encodedText, val);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EncodeThrowsArgumentNullExceptionOnNullData()
        {
            Base32.Encode(null);
            Assert.Fail("Expected ArgumentNullException, no exception was thrown.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EncodeThrowsArgumentNullExceptionOnEmptyData()
        {
            Base32.Encode(String.Empty);
            Assert.Fail("Expected ArgumentNullException, no exception was thrown.");
        }

        [TestMethod]
        public void DecodeBase32ToHelloWorld()
        {
            string plainText = "Hello, World!";
            string encodedText = "JBSWY3DPFQQFO33SNRSCC===";

            string val = Base32.Decode(encodedText);

            Assert.AreEqual(plainText, val);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void DecodeThrowsArgumentNullExceptionOnNullData()
        {
            Base32.Decode(null);
            Assert.Fail("Expected ArgumentNullException, no exception was thrown.");
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void DecodeThrowsArgumentNullExceptionOnEmptyDate()
        {
            Base32.Decode(String.Empty);
            Assert.Fail("Expected ArgumentNullException, no exception was thrown.");
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void DecodeThrowsArgumentExceptionOnInvaldBase32Data()
        {
            string encodedText = "This is not encoded data!";
            Base32.Decode(encodedText);
            Assert.Fail("Expected ArgumentException, no exception was thrown.");
        }

    }
}
