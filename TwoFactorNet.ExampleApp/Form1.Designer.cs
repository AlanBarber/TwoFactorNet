﻿namespace TwoFactorNet.ExampleApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbQRCode = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblSecretKey = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.pbCurrentVerificationCode = new System.Windows.Forms.ProgressBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblCurrentVerificationCode = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbQRCode)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbQRCode
            // 
            this.pbQRCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbQRCode.Location = new System.Drawing.Point(3, 16);
            this.pbQRCode.Name = "pbQRCode";
            this.pbQRCode.Size = new System.Drawing.Size(269, 256);
            this.pbQRCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbQRCode.TabIndex = 0;
            this.pbQRCode.TabStop = false;
            this.pbQRCode.MouseHover += new System.EventHandler(this.pbQRCode_MouseHover);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pbQRCode);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 275);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "QRCode";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblSecretKey);
            this.groupBox2.Location = new System.Drawing.Point(307, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(275, 48);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Secret Key (Base32 Encoded)";
            // 
            // lblSecretKey
            // 
            this.lblSecretKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSecretKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecretKey.Location = new System.Drawing.Point(3, 16);
            this.lblSecretKey.Name = "lblSecretKey";
            this.lblSecretKey.Size = new System.Drawing.Size(269, 29);
            this.lblSecretKey.TabIndex = 0;
            this.lblSecretKey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(307, 206);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(275, 81);
            this.btnGenerate.TabIndex = 3;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // pbCurrentVerificationCode
            // 
            this.pbCurrentVerificationCode.Location = new System.Drawing.Point(6, 66);
            this.pbCurrentVerificationCode.Maximum = 30;
            this.pbCurrentVerificationCode.Name = "pbCurrentVerificationCode";
            this.pbCurrentVerificationCode.Size = new System.Drawing.Size(263, 23);
            this.pbCurrentVerificationCode.Step = 1;
            this.pbCurrentVerificationCode.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblCurrentVerificationCode);
            this.groupBox3.Controls.Add(this.pbCurrentVerificationCode);
            this.groupBox3.Location = new System.Drawing.Point(307, 84);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(275, 95);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Current Verification Code";
            // 
            // lblCurrentVerificationCode
            // 
            this.lblCurrentVerificationCode.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCurrentVerificationCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentVerificationCode.Location = new System.Drawing.Point(3, 16);
            this.lblCurrentVerificationCode.Name = "lblCurrentVerificationCode";
            this.lblCurrentVerificationCode.Size = new System.Drawing.Size(269, 47);
            this.lblCurrentVerificationCode.TabIndex = 5;
            this.lblCurrentVerificationCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 306);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "TwoFactor.Net Example App";
            ((System.ComponentModel.ISupportInitialize)(this.pbQRCode)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbQRCode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblSecretKey;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.ProgressBar pbCurrentVerificationCode;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblCurrentVerificationCode;
        private System.Windows.Forms.Timer timer;
    }
}

