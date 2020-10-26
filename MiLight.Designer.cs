namespace MiLightYL5
{
    partial class MiLight
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.btOpenSocket = new System.Windows.Forms.Button();
            this.tbIp = new System.Windows.Forms.TextBox();
            this.btPair = new System.Windows.Forms.Button();
            this.tbSessionId = new System.Windows.Forms.TextBox();
            this.btOn = new System.Windows.Forms.Button();
            this.btOff = new System.Windows.Forms.Button();
            this.tbBrightness = new System.Windows.Forms.TextBox();
            this.btSetBrightness = new System.Windows.Forms.Button();
            this.btSendCmd = new System.Windows.Forms.Button();
            this.tbCommand = new System.Windows.Forms.TextBox();
            this.tbDimSpeed = new System.Windows.Forms.TextBox();
            this.tbDimSteps = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btDim = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbStatus = new System.Windows.Forms.TextBox();
            this.btGetStatus = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbSaturation = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbRgb = new System.Windows.Forms.TextBox();
            this.btSetSaturation = new System.Windows.Forms.Button();
            this.btSetRgb = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tbColorTemp = new System.Windows.Forms.TextBox();
            this.btSetColorTemp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btOpenSocket
            // 
            this.btOpenSocket.Location = new System.Drawing.Point(119, 12);
            this.btOpenSocket.Name = "btOpenSocket";
            this.btOpenSocket.Size = new System.Drawing.Size(109, 23);
            this.btOpenSocket.TabIndex = 0;
            this.btOpenSocket.Text = "Open Socket";
            this.btOpenSocket.UseVisualStyleBackColor = true;
            this.btOpenSocket.Click += new System.EventHandler(this.btOpenSocket_Click);
            // 
            // tbIp
            // 
            this.tbIp.Location = new System.Drawing.Point(12, 14);
            this.tbIp.Name = "tbIp";
            this.tbIp.Size = new System.Drawing.Size(100, 20);
            this.tbIp.TabIndex = 1;
            this.tbIp.Text = "192.168.0.50";
            // 
            // btPair
            // 
            this.btPair.Location = new System.Drawing.Point(12, 56);
            this.btPair.Name = "btPair";
            this.btPair.Size = new System.Drawing.Size(75, 23);
            this.btPair.TabIndex = 2;
            this.btPair.Text = "Pair";
            this.btPair.UseVisualStyleBackColor = true;
            this.btPair.Click += new System.EventHandler(this.btPair_Click);
            // 
            // tbSessionId
            // 
            this.tbSessionId.Location = new System.Drawing.Point(174, 59);
            this.tbSessionId.Name = "tbSessionId";
            this.tbSessionId.ReadOnly = true;
            this.tbSessionId.Size = new System.Drawing.Size(100, 20);
            this.tbSessionId.TabIndex = 1;
            // 
            // btOn
            // 
            this.btOn.Location = new System.Drawing.Point(12, 131);
            this.btOn.Name = "btOn";
            this.btOn.Size = new System.Drawing.Size(75, 23);
            this.btOn.TabIndex = 3;
            this.btOn.Text = "On";
            this.btOn.UseVisualStyleBackColor = true;
            this.btOn.Click += new System.EventHandler(this.btOn_Click);
            // 
            // btOff
            // 
            this.btOff.Location = new System.Drawing.Point(93, 131);
            this.btOff.Name = "btOff";
            this.btOff.Size = new System.Drawing.Size(75, 23);
            this.btOff.TabIndex = 3;
            this.btOff.Text = "Off";
            this.btOff.UseVisualStyleBackColor = true;
            this.btOff.Click += new System.EventHandler(this.btOff_Click);
            // 
            // tbBrightness
            // 
            this.tbBrightness.Location = new System.Drawing.Point(111, 174);
            this.tbBrightness.Name = "tbBrightness";
            this.tbBrightness.Size = new System.Drawing.Size(35, 20);
            this.tbBrightness.TabIndex = 4;
            this.tbBrightness.Text = "100";
            // 
            // btSetBrightness
            // 
            this.btSetBrightness.Location = new System.Drawing.Point(153, 171);
            this.btSetBrightness.Name = "btSetBrightness";
            this.btSetBrightness.Size = new System.Drawing.Size(49, 23);
            this.btSetBrightness.TabIndex = 5;
            this.btSetBrightness.Text = "Set";
            this.btSetBrightness.UseVisualStyleBackColor = true;
            this.btSetBrightness.Click += new System.EventHandler(this.btSetBrightness_Click);
            // 
            // btSendCmd
            // 
            this.btSendCmd.Location = new System.Drawing.Point(305, 362);
            this.btSendCmd.Name = "btSendCmd";
            this.btSendCmd.Size = new System.Drawing.Size(75, 23);
            this.btSendCmd.TabIndex = 7;
            this.btSendCmd.Text = "send";
            this.btSendCmd.UseVisualStyleBackColor = true;
            this.btSendCmd.Click += new System.EventHandler(this.btSendCmd_Click);
            // 
            // tbCommand
            // 
            this.tbCommand.Location = new System.Drawing.Point(16, 365);
            this.tbCommand.Name = "tbCommand";
            this.tbCommand.Size = new System.Drawing.Size(283, 20);
            this.tbCommand.TabIndex = 8;
            this.tbCommand.Text = "41,00,00,80,05,01,00,00,00,80,80";
            // 
            // tbDimSpeed
            // 
            this.tbDimSpeed.Location = new System.Drawing.Point(141, 307);
            this.tbDimSpeed.Name = "tbDimSpeed";
            this.tbDimSpeed.Size = new System.Drawing.Size(37, 20);
            this.tbDimSpeed.TabIndex = 10;
            this.tbDimSpeed.Text = "2";
            // 
            // tbDimSteps
            // 
            this.tbDimSteps.Location = new System.Drawing.Point(228, 307);
            this.tbDimSteps.Name = "tbDimSteps";
            this.tbDimSteps.Size = new System.Drawing.Size(29, 20);
            this.tbDimSteps.TabIndex = 11;
            this.tbDimSteps.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Session ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Brightness (1-100)";
            // 
            // btDim
            // 
            this.btDim.Location = new System.Drawing.Point(12, 304);
            this.btDim.Name = "btDim";
            this.btDim.Size = new System.Drawing.Size(75, 23);
            this.btDim.TabIndex = 14;
            this.btDim.Text = "Dim";
            this.btDim.UseVisualStyleBackColor = true;
            this.btDim.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btDim_MouseDown);
            this.btDim.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btDim_MouseUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 310);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Speed";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(188, 310);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Steps";
            // 
            // tbStatus
            // 
            this.tbStatus.Location = new System.Drawing.Point(97, 390);
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.ReadOnly = true;
            this.tbStatus.Size = new System.Drawing.Size(485, 20);
            this.tbStatus.TabIndex = 18;
            // 
            // btGetStatus
            // 
            this.btGetStatus.Location = new System.Drawing.Point(16, 388);
            this.btGetStatus.Name = "btGetStatus";
            this.btGetStatus.Size = new System.Drawing.Size(75, 23);
            this.btGetStatus.TabIndex = 17;
            this.btGetStatus.Text = "get";
            this.btGetStatus.UseVisualStyleBackColor = true;
            this.btGetStatus.Click += new System.EventHandler(this.btGetStatus_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Saturation (0-100)";
            // 
            // tbSaturation
            // 
            this.tbSaturation.Location = new System.Drawing.Point(111, 202);
            this.tbSaturation.Name = "tbSaturation";
            this.tbSaturation.Size = new System.Drawing.Size(35, 20);
            this.tbSaturation.TabIndex = 19;
            this.tbSaturation.Text = "50";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 230);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "RGB (0-255)";
            // 
            // tbRgb
            // 
            this.tbRgb.Location = new System.Drawing.Point(111, 228);
            this.tbRgb.Name = "tbRgb";
            this.tbRgb.Size = new System.Drawing.Size(35, 20);
            this.tbRgb.TabIndex = 22;
            this.tbRgb.Text = "255";
            // 
            // btSetSaturation
            // 
            this.btSetSaturation.Location = new System.Drawing.Point(153, 199);
            this.btSetSaturation.Name = "btSetSaturation";
            this.btSetSaturation.Size = new System.Drawing.Size(49, 23);
            this.btSetSaturation.TabIndex = 5;
            this.btSetSaturation.Text = "Set";
            this.btSetSaturation.UseVisualStyleBackColor = true;
            this.btSetSaturation.Click += new System.EventHandler(this.btSetSaturation_Click);
            // 
            // btSetRgb
            // 
            this.btSetRgb.Location = new System.Drawing.Point(152, 225);
            this.btSetRgb.Name = "btSetRgb";
            this.btSetRgb.Size = new System.Drawing.Size(49, 23);
            this.btSetRgb.TabIndex = 5;
            this.btSetRgb.Text = "Set";
            this.btSetRgb.UseVisualStyleBackColor = true;
            this.btSetRgb.Click += new System.EventHandler(this.btSetRgb_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 256);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Color temp (0-36)";
            // 
            // tbColorTemp
            // 
            this.tbColorTemp.Location = new System.Drawing.Point(111, 254);
            this.tbColorTemp.Name = "tbColorTemp";
            this.tbColorTemp.Size = new System.Drawing.Size(35, 20);
            this.tbColorTemp.TabIndex = 26;
            this.tbColorTemp.Text = "18";
            // 
            // btSetColorTemp
            // 
            this.btSetColorTemp.Location = new System.Drawing.Point(152, 251);
            this.btSetColorTemp.Name = "btSetColorTemp";
            this.btSetColorTemp.Size = new System.Drawing.Size(49, 23);
            this.btSetColorTemp.TabIndex = 25;
            this.btSetColorTemp.Text = "Set";
            this.btSetColorTemp.UseVisualStyleBackColor = true;
            this.btSetColorTemp.Click += new System.EventHandler(this.btSetColorTemp_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 431);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbColorTemp);
            this.Controls.Add(this.btSetColorTemp);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbRgb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbSaturation);
            this.Controls.Add(this.tbStatus);
            this.Controls.Add(this.btGetStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btDim);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbDimSteps);
            this.Controls.Add(this.tbDimSpeed);
            this.Controls.Add(this.tbCommand);
            this.Controls.Add(this.btSendCmd);
            this.Controls.Add(this.btSetRgb);
            this.Controls.Add(this.btSetSaturation);
            this.Controls.Add(this.btSetBrightness);
            this.Controls.Add(this.tbBrightness);
            this.Controls.Add(this.btOff);
            this.Controls.Add(this.btOn);
            this.Controls.Add(this.btPair);
            this.Controls.Add(this.tbSessionId);
            this.Controls.Add(this.tbIp);
            this.Controls.Add(this.btOpenSocket);
            this.Name = "Form1";
            this.Text = "MiLight YL5 Control";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btOpenSocket;
        private System.Windows.Forms.TextBox tbIp;
        private System.Windows.Forms.Button btPair;
        private System.Windows.Forms.TextBox tbSessionId;
        private System.Windows.Forms.Button btOn;
        private System.Windows.Forms.Button btOff;
        private System.Windows.Forms.TextBox tbBrightness;
        private System.Windows.Forms.Button btSetBrightness;
        private System.Windows.Forms.Button btSendCmd;
        private System.Windows.Forms.TextBox tbCommand;
        private System.Windows.Forms.TextBox tbDimSpeed;
        private System.Windows.Forms.TextBox tbDimSteps;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btDim;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbStatus;
        private System.Windows.Forms.Button btGetStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbSaturation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbRgb;
        private System.Windows.Forms.Button btSetSaturation;
        private System.Windows.Forms.Button btSetRgb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbColorTemp;
        private System.Windows.Forms.Button btSetColorTemp;
    }
}

