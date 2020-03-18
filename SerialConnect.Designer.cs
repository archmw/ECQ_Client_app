namespace DM_Main
{
    partial class SerialConnect
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
            this.gbSerialSettings = new System.Windows.Forms.GroupBox();
            this.cbSelectBaud = new System.Windows.Forms.ComboBox();
            this.cbSelectPort = new System.Windows.Forms.ComboBox();
            this.btnSendServiceToMaster = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.ComPort = new System.IO.Ports.SerialPort(this.components);
            this.rtSerialRx = new System.Windows.Forms.RichTextBox();
            this.gbSerialRx = new System.Windows.Forms.GroupBox();
            this.gbTxWindow = new System.Windows.Forms.GroupBox();
            this.rtSerialTx = new System.Windows.Forms.RichTextBox();
            this.gbSerialSettings.SuspendLayout();
            this.gbTxWindow.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSerialSettings
            // 
            this.gbSerialSettings.Controls.Add(this.cbSelectBaud);
            this.gbSerialSettings.Controls.Add(this.cbSelectPort);
            this.gbSerialSettings.Controls.Add(this.btnSendServiceToMaster);
            this.gbSerialSettings.Controls.Add(this.btnConnect);
            this.gbSerialSettings.Location = new System.Drawing.Point(14, 24);
            this.gbSerialSettings.Name = "gbSerialSettings";
            this.gbSerialSettings.Size = new System.Drawing.Size(421, 335);
            this.gbSerialSettings.TabIndex = 6;
            this.gbSerialSettings.TabStop = false;
            this.gbSerialSettings.Text = "Serial Port Settiings";
            // 
            // cbSelectBaud
            // 
            this.cbSelectBaud.FormattingEnabled = true;
            this.cbSelectBaud.Location = new System.Drawing.Point(239, 99);
            this.cbSelectBaud.Name = "cbSelectBaud";
            this.cbSelectBaud.Size = new System.Drawing.Size(140, 23);
            this.cbSelectBaud.TabIndex = 2;
            this.cbSelectBaud.Text = "Select BAUD";
            // 
            // cbSelectPort
            // 
            this.cbSelectPort.FormattingEnabled = true;
            this.cbSelectPort.Location = new System.Drawing.Point(58, 99);
            this.cbSelectPort.Name = "cbSelectPort";
            this.cbSelectPort.Size = new System.Drawing.Size(140, 23);
            this.cbSelectPort.TabIndex = 1;
            this.cbSelectPort.Text = "Select COM";
            // 
            // btnSendServiceToMaster
            // 
            this.btnSendServiceToMaster.Location = new System.Drawing.Point(239, 154);
            this.btnSendServiceToMaster.Name = "btnSendServiceToMaster";
            this.btnSendServiceToMaster.Size = new System.Drawing.Size(141, 64);
            this.btnSendServiceToMaster.TabIndex = 4;
            this.btnSendServiceToMaster.Text = "Send Service List To Master Display";
            this.btnSendServiceToMaster.UseVisualStyleBackColor = true;
            this.btnSendServiceToMaster.Click += new System.EventHandler(this.btnSendServiceToMaster_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(58, 154);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(141, 64);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Connect Port AND Test COMPORT";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // rtSerialRx
            // 
            this.rtSerialRx.Location = new System.Drawing.Point(453, 49);
            this.rtSerialRx.Name = "rtSerialRx";
            this.rtSerialRx.Size = new System.Drawing.Size(344, 295);
            this.rtSerialRx.TabIndex = 7;
            this.rtSerialRx.Text = "You will recieve Text Here";
            this.rtSerialRx.Enter += new System.EventHandler(this.rtSerialRx_Enter);
            // 
            // gbSerialRx
            // 
            this.gbSerialRx.Location = new System.Drawing.Point(441, 24);
            this.gbSerialRx.Name = "gbSerialRx";
            this.gbSerialRx.Size = new System.Drawing.Size(367, 335);
            this.gbSerialRx.TabIndex = 8;
            this.gbSerialRx.TabStop = false;
            this.gbSerialRx.Text = "Receive Window";
            // 
            // gbTxWindow
            // 
            this.gbTxWindow.Controls.Add(this.rtSerialTx);
            this.gbTxWindow.Location = new System.Drawing.Point(12, 365);
            this.gbTxWindow.Name = "gbTxWindow";
            this.gbTxWindow.Size = new System.Drawing.Size(796, 154);
            this.gbTxWindow.TabIndex = 9;
            this.gbTxWindow.TabStop = false;
            this.gbTxWindow.Text = "Transmit Window";
            // 
            // rtSerialTx
            // 
            this.rtSerialTx.Location = new System.Drawing.Point(17, 20);
            this.rtSerialTx.Name = "rtSerialTx";
            this.rtSerialTx.Size = new System.Drawing.Size(768, 116);
            this.rtSerialTx.TabIndex = 0;
            this.rtSerialTx.Text = "Transmited text will appear here.";
            this.rtSerialTx.Enter += new System.EventHandler(this.rtSerialTx_Enter);
            // 
            // SerialConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 548);
            this.ControlBox = false;
            this.Controls.Add(this.gbTxWindow);
            this.Controls.Add(this.rtSerialRx);
            this.Controls.Add(this.gbSerialSettings);
            this.Controls.Add(this.gbSerialRx);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimizeBox = false;
            this.Name = "SerialConnect";
            this.Text = "SerialConnect";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SerialConnect_FormClosed);
            this.gbSerialSettings.ResumeLayout(false);
            this.gbTxWindow.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSerialSettings;
        private System.Windows.Forms.ComboBox cbSelectBaud;
        private System.Windows.Forms.ComboBox cbSelectPort;
        private System.Windows.Forms.Button btnConnect;
        private System.IO.Ports.SerialPort ComPort;
        private System.Windows.Forms.Button btnSendServiceToMaster;
        private System.Windows.Forms.RichTextBox rtSerialRx;
        private System.Windows.Forms.GroupBox gbSerialRx;
        private System.Windows.Forms.GroupBox gbTxWindow;
        private System.Windows.Forms.RichTextBox rtSerialTx;

    }
}