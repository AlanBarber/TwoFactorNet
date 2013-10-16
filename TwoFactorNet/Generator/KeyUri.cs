using System;
using System.Net;

namespace TwoFactorNet.Generator
{
    public class KeyUri
    {
        #region TOTP Key Uri

        /// <summary>
        /// Gets the TOTP URI.
        /// </summary>
        /// <param name="issuer">The issuer.</param>
        /// <param name="accountName">Name of the account.</param>
        /// <param name="secret">The Base32 encoded secret.</param>
        /// <returns></returns>
        public static string GetToptUri(string issuer, string accountName, string secret)
        {
            return GetToptUri(issuer, accountName, secret, 6, 30);
        }

        /// <summary>
        /// Gets the TOTP URI.
        /// </summary>
        /// <param name="issuer">The issuer.</param>
        /// <param name="accountName">Name of the account.</param>
        /// <param name="secret">The Base32 encoded secret.</param>
        /// <param name="digits">The number digits generated in the one time password.</param>
        /// <param name="period">The cycle period for the one time password.</param>
        /// <returns></returns>
        public static string GetToptUri(string issuer, string accountName, string secret, int digits, int period)
        {
            var urlEncodedIssuer = WebUtility.UrlEncode(issuer);
            var urlEncodedAccountName = WebUtility.UrlEncode(accountName);
            return String.Format("otpauth://totp/{0}:{1}?issuer={0}&secret={2}&digits={3}&period={4}", urlEncodedIssuer, urlEncodedAccountName, secret, digits, period);
        }

        #endregion

        #region HOTP Key Uri

        /// <summary>
        /// Gets the HOTP URI.
        /// </summary>
        /// <param name="issuer">The issuer.</param>
        /// <param name="accountName">Name of the account.</param>
        /// <param name="secret">The Base32 encoded secret.</param>
        /// <returns></returns>
        public static string GetHotpUri(string issuer, string accountName, string secret)
        {
            return GetHotpUri(issuer, accountName, secret, 6, 0);
        }


        /// <summary>
        /// Gets the HOTP URI.
        /// </summary>
        /// <param name="issuer">The issuer.</param>
        /// <param name="accountName">Name of the account.</param>
        /// <param name="secret">The Base32 encoded secret.</param>
        /// <param name="counter">The initial value of the counter.</param>
        /// <returns></returns>
        public static string GetHotpUri(string issuer, string accountName, string secret, int counter)
        {
            return GetHotpUri(issuer, accountName, secret, 6, counter);
        }

        /// <summary>
        /// Gets the HOTP URI.
        /// </summary>
        /// <param name="issuer">The issuer.</param>
        /// <param name="accountName">Name of the account.</param>
        /// <param name="secret">The Base32 encoded secret.</param>
        /// <param name="digits">The number digits generated in the one time password.</param>
        /// <param name="counter">The initial value of the counter.</param>
        /// <returns></returns>
        public static string GetHotpUri(string issuer, string accountName, string secret, int digits, int counter)
        {
            var urlEncodedIssuer = WebUtility.UrlEncode(issuer);
            var urlEncodedAccountName = WebUtility.UrlEncode(accountName);
            return String.Format("otpauth://hotp/{0}:{1}?issuer={0}&secret={2}&digits={3}&counter={4}", urlEncodedIssuer, urlEncodedAccountName, secret, digits, counter);
        }
        #endregion
    }
}
