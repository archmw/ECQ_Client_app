namespace DM_Main
{
    partial class DBPath
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
            this.lServerName = new System.Windows.Forms.Label();
            this.lDBName = new System.Windows.Forms.Label();
            this.tbDBName = new System.Windows.Forms.TextBox();
            this.tbServerName = new System.Windows.Forms.TextBox();
            this.btnSetdbOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lServerName
            // 
            this.lServerName.AutoSize = true;
            this.lServerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lServerName.Location = new System.Drawing.Point(12, 44);
            this.lServerName.Name = "lServerName";
            this.lServerName.Size = new System.Drawing.Size(180, 20);
            this.lServerName.TabIndex = 0;
            this.lServerName.Text = "Enter SQL Server Name";
            // 
            // lDBName
            // 
            this.lDBName.AutoSize = true;
            this.lDBName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDBName.Location = new System.Drawing.Point(12, 85);
            this.lDBName.Name = "lDBName";
            this.lDBName.Size = new System.Drawing.Size(121, 20);
            this.lDBName.TabIndex = 0;
            this.lDBName.Text = "Enter DB Name";
            // 
            // tbDBName
            // 
            this.tbDBName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDBName.Location = new System.Drawing.Point(207, 82);
            this.tbDBName.Name = "tbDBName";
            this.tbDBName.Size = new System.Drawing.Size(402, 26);
            this.tbDBName.TabIndex = 2;
            // 
            // tbServerName
            // 
            this.tbServerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbServerName.Location = new System.Drawing.Point(207, 41);
            this.tbServerName.Name = "tbServerName";
            this.tbServerName.Size = new System.Drawing.Size(402, 26);
            this.tbServerName.TabIndex = 1;
            // 
            // btnSetdbOK
            // 
            this.btnSetdbOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetdbOK.Location = new System.Drawing.Point(207, 172);
            this.btnSetdbOK.Name = "btnSetdbOK";
            this.btnSetdbOK.Size = new System.Drawing.Size(127, 35);
            this.btnSetdbOK.TabIndex = 3;
            this.btnSetdbOK.Text = "OK";
            this.btnSetdbOK.UseVisualStyleBackColor = true;
            this.btnSetdbOK.Click += new System.EventHandler(this.btnSetdbOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(482, 172);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(127, 35);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // DBPath
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 262);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSetdbOK);
            this.Controls.Add(this.tbServerName);
            this.Controls.Add(this.tbDBName);
            this.Controls.Add(this.lDBName);
            this.Controls.Add(this.lServerName);
            this.Name = "DBPath";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DB Path Setup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lServerName;
        private System.Windows.Forms.Label lDBName;
        private System.Windows.Forms.TextBox tbDBName;
        private System.Windows.Forms.TextBox tbServerName;
        private System.Windows.Forms.Button btnSetdbOK;
        private System.Windows.Forms.Button btnCancel;
    }
}