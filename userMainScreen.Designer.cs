namespace DM_Main
{
    partial class userMainScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(userMainScreen));
            this.pbTitlePicture = new System.Windows.Forms.PictureBox();
            this.lCurrentTime = new System.Windows.Forms.Label();
            this.lChooseService = new System.Windows.Forms.Label();
            this.cbChooseService = new System.Windows.Forms.ComboBox();
            this.btnGenrateTicket = new System.Windows.Forms.Button();
            this.btnReprint = new System.Windows.Forms.Button();
            this.GenerateTokenSuccMessage = new System.Windows.Forms.RichTextBox();
            this.gbSpliterVertical = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitlePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // pbTitlePicture
            // 
            this.pbTitlePicture.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.pbTitlePicture.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pbTitlePicture.ErrorImage = null;
            this.pbTitlePicture.Image = ((System.Drawing.Image)(resources.GetObject("pbTitlePicture.Image")));
            this.pbTitlePicture.InitialImage = null;
            this.pbTitlePicture.Location = new System.Drawing.Point(0, 0);
            this.pbTitlePicture.Margin = new System.Windows.Forms.Padding(0);
            this.pbTitlePicture.Name = "pbTitlePicture";
            this.pbTitlePicture.Padding = new System.Windows.Forms.Padding(12);
            this.pbTitlePicture.Size = new System.Drawing.Size(658, 145);
            this.pbTitlePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbTitlePicture.TabIndex = 2;
            this.pbTitlePicture.TabStop = false;
            // 
            // lCurrentTime
            // 
            this.lCurrentTime.AutoSize = true;
            this.lCurrentTime.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCurrentTime.Location = new System.Drawing.Point(12, 160);
            this.lCurrentTime.Margin = new System.Windows.Forms.Padding(0);
            this.lCurrentTime.Name = "lCurrentTime";
            this.lCurrentTime.Padding = new System.Windows.Forms.Padding(12);
            this.lCurrentTime.Size = new System.Drawing.Size(155, 44);
            this.lCurrentTime.TabIndex = 1;
            this.lCurrentTime.Text = "Date And Time";
            // 
            // lChooseService
            // 
            this.lChooseService.AutoSize = true;
            this.lChooseService.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lChooseService.Location = new System.Drawing.Point(13, 230);
            this.lChooseService.Name = "lChooseService";
            this.lChooseService.Size = new System.Drawing.Size(114, 18);
            this.lChooseService.TabIndex = 2;
            this.lChooseService.Text = "Choose Service";
            this.lChooseService.Visible = false;
            // 
            // cbChooseService
            // 
            this.cbChooseService.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbChooseService.FormattingEnabled = true;
            this.cbChooseService.Location = new System.Drawing.Point(203, 227);
            this.cbChooseService.Name = "cbChooseService";
            this.cbChooseService.Size = new System.Drawing.Size(249, 26);
            this.cbChooseService.TabIndex = 3;
            this.cbChooseService.Text = "Choose Service";
            this.cbChooseService.Visible = false;
            // 
            // btnGenrateTicket
            // 
            this.btnGenrateTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenrateTicket.Location = new System.Drawing.Point(16, 441);
            this.btnGenrateTicket.Name = "btnGenrateTicket";
            this.btnGenrateTicket.Size = new System.Drawing.Size(195, 68);
            this.btnGenrateTicket.TabIndex = 4;
            this.btnGenrateTicket.Text = "Generate Ticket";
            this.btnGenrateTicket.UseVisualStyleBackColor = true;
            this.btnGenrateTicket.Visible = false;
            this.btnGenrateTicket.Click += new System.EventHandler(this.btnGenrateTicket_Click);
            // 
            // btnReprint
            // 
            this.btnReprint.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnReprint.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReprint.Location = new System.Drawing.Point(257, 441);
            this.btnReprint.Name = "btnReprint";
            this.btnReprint.Size = new System.Drawing.Size(195, 68);
            this.btnReprint.TabIndex = 4;
            this.btnReprint.Text = "Print Ticket Again";
            this.btnReprint.UseVisualStyleBackColor = true;
            this.btnReprint.Visible = false;
            this.btnReprint.Click += new System.EventHandler(this.btnReprint_Click);
            // 
            // GenerateTokenSuccMessage
            // 
            this.GenerateTokenSuccMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenerateTokenSuccMessage.Location = new System.Drawing.Point(16, 560);
            this.GenerateTokenSuccMessage.Name = "GenerateTokenSuccMessage";
            this.GenerateTokenSuccMessage.Size = new System.Drawing.Size(436, 69);
            this.GenerateTokenSuccMessage.TabIndex = 6;
            this.GenerateTokenSuccMessage.Text = "";
            // 
            // gbSpliterVertical
            // 
            this.gbSpliterVertical.AutoSize = true;
            this.gbSpliterVertical.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbSpliterVertical.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gbSpliterVertical.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbSpliterVertical.Location = new System.Drawing.Point(0, 127);
            this.gbSpliterVertical.Name = "gbSpliterVertical";
            this.gbSpliterVertical.Size = new System.Drawing.Size(6, 5);
            this.gbSpliterVertical.TabIndex = 6;
            this.gbSpliterVertical.TabStop = false;
            // 
            // userMainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1084, 862);
            this.Controls.Add(this.GenerateTokenSuccMessage);
            this.Controls.Add(this.pbTitlePicture);
            this.Controls.Add(this.btnGenrateTicket);
            this.Controls.Add(this.btnReprint);
            this.Controls.Add(this.gbSpliterVertical);
            this.Controls.Add(this.lCurrentTime);
            this.Controls.Add(this.lChooseService);
            this.Controls.Add(this.cbChooseService);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.MaximizeBox = false;
            this.Name = "userMainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EQM Systems";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.userMainScreen_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.userMainScreen_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pbTitlePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbTitlePicture;
        private System.Windows.Forms.Label lCurrentTime;
        private System.Windows.Forms.Label lChooseService;
        private System.Windows.Forms.ComboBox cbChooseService;
        private System.Windows.Forms.Button btnGenrateTicket;
        private System.Windows.Forms.Button btnReprint;
        private System.Windows.Forms.RichTextBox GenerateTokenSuccMessage;
        private System.Windows.Forms.GroupBox gbSpliterVertical;
    }
}

