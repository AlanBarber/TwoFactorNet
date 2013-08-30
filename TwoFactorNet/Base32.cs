using System;
using System.Linq;
using System.Text;

namespace TwoFactorNet
{
    /// <summary>
    /// Base32 Encoder/Decoder based upon RFC 3548/4648 
    /// This uses the following alphabet
    /// "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567"
    /// </summary>
    public static class Base32
    {
        private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";
        private const char Padding = '=';
        private const int EncodedBitSize = 5;
        private const int ByteBitSize = 8;

        /// <summary>
        /// Decodes the specified encoded data.
        /// </summary>
        /// <param name="encodedData">The encoded data.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public static byte[] Decode(string encodedData)
        {
            // Null/Empty check
            if (String.IsNullOrEmpty(encodedData))
                throw new ArgumentNullException(encodedData,"encodedData string is null or empty.");
            
            // Clean data, upper case all chars, remove whitespace and trim padding char from end
            string cleanedData = encodedData.ToUpper().Trim().TrimEnd(Padding);

            // Check for bad characters
            foreach (var c in cleanedData)
            {
                if(!Alphabet.Contains(c))
                    throw new ArgumentException("Illegal character found in encoded data string.");
            }
            // Create return buffer
            byte[] returnBuffer = new byte[(cleanedData.Length * EncodedBitSize / ByteBitSize)];

            byte activeByte = 0;
            int bitsRemaining = ByteBitSize;
            int mask = 0;
            int index = 0;

            foreach (char activeChar in cleanedData)
            {
                int encodedValue = Alphabet.IndexOf(activeChar);

                if (bitsRemaining > EncodedBitSize)
                {
                    mask = encodedValue << (bitsRemaining - EncodedBitSize);
                    activeByte = (byte) (activeByte | mask);
                    bitsRemaining -= EncodedBitSize;
                }
                else
                {
                    mask = encodedValue >> (EncodedBitSize - bitsRemaining);
                    activeByte = (byte) (activeByte | mask);
                    returnBuffer[index++] = activeByte;
                    activeByte = (byte) (encodedValue << (ByteBitSize - EncodedBitSize + bitsRemaining));
                    bitsRemaining += ByteBitSize - EncodedBitSize;
                }
            }

            return returnBuffer;
        }

        /// <summary>
        /// Encodes the specified plain data.
        /// </summary>
        /// <param name="plainData">The plain data.</param>
        /// <returns></returns>
        public static string Encode(byte[] plainData)
        {
            // Null / empty string check
            if (plainData == null)
                throw new ArgumentNullException("plainData", "plainData cannot be null or empty.");

            // Calculate the complete encoded size of the output string from the input string
            // Example assuming standard encoding size (5) and byte sizes (8)
            // 100 char input string / 5 encoding size * 8 byte size = 160 char output 
            int outputCharSize = (int) Math.Ceiling(plainData.Length/(decimal) EncodedBitSize) * ByteBitSize;
            byte[] returnBuffer = new byte[outputCharSize];

            byte activeValue = 0;
            int remainingBits = EncodedBitSize;
            int index = 0;

            // loop through each byte and encode into 5 bit 
            foreach (byte activeByte in plainData)
            {
                activeValue = (byte)(activeValue | (activeByte >> (ByteBitSize - remainingBits)));
                returnBuffer[index++] = (byte)Alphabet[activeValue];

                if (remainingBits <= ByteBitSize - EncodedBitSize)
                {
                    activeValue = (byte) (activeByte >> (ByteBitSize - EncodedBitSize - remainingBits) & 31);
                    returnBuffer[index++] = (byte)Alphabet[activeValue];
                    remainingBits += EncodedBitSize;
                }

                remainingBits -= ByteBitSize - EncodedBitSize;
                activeValue = (byte) ((activeByte << remainingBits) & 31);
            }
            
            if(index != outputCharSize)
                returnBuffer[index++] = (byte)Alphabet[activeValue];

            // Add padding char to meet RFC 4648 requirement that the encoded data is split into even 40bit blocks
            while (index < outputCharSize)
            {
                returnBuffer[index++] = (byte)Padding;
            }

            return Encoding.ASCII.GetString(returnBuffer);
        }

        
    }
}
