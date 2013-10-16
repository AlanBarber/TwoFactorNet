using System;
using System.Drawing;
using System.Windows.Forms;
using TwoFactorNet.Encoding;
using TwoFactorNet.Generator;
using TwoFactorNet.Time;
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
            // get a 16 character random string that is base32 for secret
            // then decode the base32 to the real byte array secret key
            _encodedKey = RandomKey.GetRandomEncodedKey();
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
            pbQRCode.Image = new Bitmap(barcodeWriter.Write(KeyUri.GetToptUri("TwoFactorNet", "TestUser", _encodedKey)));

            // generate code
            var totp = new Totp(_secretKey, 6, 30);
            lblCurrentVerificationCode.Text = totp.GeneratePassword(UnixTime.GetUnixTime());

            // get next cycle time
            _nextCycleTime = TimeHelper.GetNextCycleTime();

            // move progressbar to correct value
            pbCurrentVerificationCode.Value = (_nextCycleTime.Second == 0 ? 60 - DateTime.Now.Second : DateTime.Now.Second);

            // setup timer to display
            timer.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // update progress bar
            pbCurrentVerificationCode.PerformStep();

            // check time to see if we need to cycle
            if (DateTime.Now >= _nextCycleTime)
            {
                _nextCycleTime = TimeHelper.GetNextCycleTime();
                var totp = new Totp(_secretKey, 6, 30);
                lblCurrentVerificationCode.Text = totp.GeneratePassword(UnixTime.GetUnixTime());
                pbCurrentVerificationCode.Value = 0;
                
            }
        }





        private void pbQRCode_MouseHover(object sender, EventArgs e)
        {
            var tt = new ToolTip();
            tt.SetToolTip((Control)sender, KeyUri.GetToptUri("TwoFactorNet", "TestUser", _encodedKey));
        }
    }
}
