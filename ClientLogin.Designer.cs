namespace DM_Main
{
    partial class ClientLogin
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
            this.lmsgcred = new System.Windows.Forms.Label();
            this.gbLogin = new System.Windows.Forms.GroupBox();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lusername = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.lpassword = new System.Windows.Forms.Label();
            this.tbpassword = new System.Windows.Forms.TextBox();
            this.loginPicture = new System.Windows.Forms.PictureBox();
            this.gbLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loginPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // lmsgcred
            // 
            this.lmsgcred.AutoSize = true;
            this.lmsgcred.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lmsgcred.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lmsgcred.Location = new System.Drawing.Point(20, 26);
            this.lmsgcred.Name = "lmsgcred";
            this.lmsgcred.Size = new System.Drawing.Size(32, 15);
            this.lmsgcred.TabIndex = 6;
            this.lmsgcred.Text = "label";
            this.lmsgcred.Visible = false;
            // 
            // gbLogin
            // 
            this.gbLogin.Controls.Add(this.tbUsername);
            this.gbLogin.Controls.Add(this.lmsgcred);
            this.gbLogin.Controls.Add(this.btnLogin);
            this.gbLogin.Controls.Add(this.lusername);
            this.gbLogin.Controls.Add(this.btnExit);
            this.gbLogin.Controls.Add(this.lpassword);
            this.gbLogin.Controls.Add(this.tbpassword);
            this.gbLogin.Location = new System.Drawing.Point(174, 50);
            this.gbLogin.Name = "gbLogin";
            this.gbLogin.Size = new System.Drawing.Size(298, 204);
            this.gbLogin.TabIndex = 9;
            this.gbLogin.TabStop = false;
            this.gbLogin.Text = "Login";
            // 
            // tbUsername
            // 
            this.tbUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUsername.Location = new System.Drawing.Point(101, 64);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.ShortcutsEnabled = false;
            this.tbUsername.Size = new System.Drawing.Size(168, 23);
            this.tbUsername.TabIndex = 0;
            this.tbUsername.Text = "User Name";
            this.tbUsername.Enter += new System.EventHandler(this.tbUsername_Enter);
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(174, 153);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lusername
            // 
            this.lusername.AutoSize = true;
            this.lusername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lusername.Location = new System.Drawing.Point(20, 67);
            this.lusername.Name = "lusername";
            this.lusername.Size = new System.Drawing.Size(71, 15);
            this.lusername.TabIndex = 5;
            this.lusername.Text = "USER NAME";
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(61, 153);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lpassword
            // 
            this.lpassword.AutoSize = true;
            this.lpassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lpassword.Location = new System.Drawing.Point(20, 105);
            this.lpassword.Name = "lpassword";
            this.lpassword.Size = new System.Drawing.Size(69, 15);
            this.lpassword.TabIndex = 4;
            this.lpassword.Text = "PASSWORD";
            // 
            // tbpassword
            // 
            this.tbpassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbpassword.Location = new System.Drawing.Point(101, 102);
            this.tbpassword.Name = "tbpassword";
            this.tbpassword.PasswordChar = '*';
            this.tbpassword.Size = new System.Drawing.Size(168, 23);
            this.tbpassword.TabIndex = 1;
            this.tbpassword.UseSystemPasswordChar = true;
            this.tbpassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbpassword_KeyDown);
            // 
            // loginPicture
            // 
            this.loginPicture.ErrorImage = null;
            this.loginPicture.Image = global::DM_Main.Properties.Resources.loginkeys;
            this.loginPicture.InitialImage = global::DM_Main.Properties.Resources.loginkeys;
            this.loginPicture.Location = new System.Drawing.Point(24, 50);
            this.loginPicture.Name = "loginPicture";
            this.loginPicture.Size = new System.Drawing.Size(144, 204);
            this.loginPicture.TabIndex = 10;
            this.loginPicture.TabStop = false;
            // 
            // ClientLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 287);
            this.Controls.Add(this.loginPicture);
            this.Controls.Add(this.gbLogin);
            this.Name = "ClientLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClientLogin";
            this.gbLogin.ResumeLayout(false);
            this.gbLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loginPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lmsgcred;
        private System.Windows.Forms.GroupBox gbLogin;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lusername;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lpassword;
        private System.Windows.Forms.TextBox tbpassword;
        private System.Windows.Forms.PictureBox loginPicture;
    }
}