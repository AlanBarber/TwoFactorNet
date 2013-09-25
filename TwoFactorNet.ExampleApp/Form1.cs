using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode;

namespace TwoFactorNet.ExampleApp
{
    public partial class Form1 : Form
    {
        private byte[] _secretKey;
        private string _encodedKey;
        private DateTime _nextCycleTime;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            // get a 16 character random string that is base32
            // get rnd 20 byte array
            _encodedKey = System.Text.Encoding.ASCII.GetString(GenerateRandomKey());
            _secretKey = Base32.Decode(_encodedKey);
            // display
            lblSecretKey.Text = string.Format("{0} {1} {2} {3}",
                _encodedKey.Substring(0, 4), _encodedKey.Substring(4, 4),
                _encodedKey.Substring(8, 4), _encodedKey.Substring(12, 4));
            // get qrcode
            IBarcodeWriter barcodeWriter = new BarcodeWriter
            {
                                               Format = BarcodeFormat.QR_CODE,
                                               Options = new QrCodeEncodingOptions
                                               {
                                                   Width = 250,
                                                   Height = 250,
                                                   Margin = 1
                                               }
                                           };
            pbQRCode.Image = new Bitmap(barcodeWriter.Write(GenerateQRCodeText("TwoFactorNet", "TestUser", _encodedKey)));

            // generate code
            var totp = new Totp(_secretKey, 6, 30);
            lblCurrentVerificationCode.Text = totp.GeneratePassword(GetUnixTime());

            // get next cycle time
            _nextCycleTime = GetNextCycleTime();

            // move progressbar to correct value
            pbCurrentVerificationCode.Value = (_nextCycleTime.Second == 0 ? 60 - DateTime.Now.Second : DateTime.Now.Second);

            // setup timer to display
            timer.Enabled = true;
        }

        string GenerateQRCodeText(string issuer, string accountName, string secret)
        {
            return String.Format("otpauth://totp/{0}:{1}?secret={2}&digits=6&issuer={0}", issuer, accountName, secret);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // update progress bar
            pbCurrentVerificationCode.PerformStep();

            // check time to see if we need to cycle
            if (DateTime.Now >= _nextCycleTime)
            {
                _nextCycleTime = GetNextCycleTime();
                var totp = new Totp(_secretKey, 6, 30);
                lblCurrentVerificationCode.Text = totp.GeneratePassword(GetUnixTime());
                pbCurrentVerificationCode.Value = 0;
                
            }
        }

        private byte[] GenerateRandomKey()
        {   
            var retBytes = new byte[16];
            for (int i = 0; i < retBytes.Length; i++)
            {
                retBytes[i] = GetValidBase32Byte();
            }
            return retBytes;
        }

        private byte GetValidBase32Byte()
        {
            var validBytes = System.Text.Encoding.ASCII.GetBytes("ABCDEFGHIJKLMNOPQRSTUVWXYZ234567");
            var rngByte = new byte[1];
            var rngCsp = new RNGCryptoServiceProvider();
            while (!Array.Exists(validBytes, e => e == rngByte[0]))
            {
                rngCsp.GetBytes(rngByte);    
            }
            return rngByte[0];
        }

        static DateTime GetNextCycleTime()
        {
            return DateTime.Now.AddSeconds(-DateTime.Now.Second).AddSeconds(DateTime.Now.Second < 30 ? 30 : 60);
        }

        long GetUnixTime()
        {
            return (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
        }

        private void pbQRCode_MouseHover(object sender, EventArgs e)
        {
            var tt = new ToolTip();
            tt.SetToolTip((Control)sender, GenerateQRCodeText("TwoFactorNet", "TestUser", _encodedKey));

        }
    }
}
