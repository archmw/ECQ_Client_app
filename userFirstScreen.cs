using System;
using System.Windows.Forms;

namespace DM_Main
{
    public partial class userFirstScreen : Form
    {
        public StatusBar mainStatusBar = new StatusBar();
        public StatusBarPanel statusPanel = new StatusBarPanel();
        private MenuStrip clientMenuStrip;
        private ToolStripMenuItem serialSettingsToolStripMenuItem;
        private ToolStripMenuItem userSToolStripMenuItem;
        public StatusBarPanel datetimePanel = new StatusBarPanel();
        userMainScreen ms = new userMainScreen();
        Ticket_Design td = new Ticket_Design();
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem ticketDesignToolStripMenuItem;
        SerialConnect sc = new SerialConnect();
        public userFirstScreen()
        {
            InitializeComponent();
            //System.Diagnostics.Debug.WriteLine("Welcome, App Started");
            statusPanel.BorderStyle = StatusBarPanelBorderStyle.Sunken;
            statusPanel.Text = "Welcome!";
            statusPanel.ToolTipText = "Last Activity";
            statusPanel.AutoSize = StatusBarPanelAutoSize.Spring;
            mainStatusBar.Panels.Add(statusPanel);
            mainStatusBar.Panels.Add(datetimePanel);
            mainStatusBar.ShowPanels = true;
            Controls.Add(mainStatusBar);
        }
        
        

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(userFirstScreen));
            this.clientMenuStrip = new System.Windows.Forms.MenuStrip();
            this.serialSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ticketDesignToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // clientMenuStrip
            // 
            this.clientMenuStrip.GripMargin = new System.Windows.Forms.Padding(5);
            this.clientMenuStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.clientMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serialSettingsToolStripMenuItem,
            this.userSToolStripMenuItem,
            this.ticketDesignToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.clientMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.clientMenuStrip.Margin = new System.Windows.Forms.Padding(1);
            this.clientMenuStrip.Name = "clientMenuStrip";
            this.clientMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.clientMenuStrip.Size = new System.Drawing.Size(801, 24);
            this.clientMenuStrip.TabIndex = 1;
            this.clientMenuStrip.Text = "clientMenuStrip";
            // 
            // serialSettingsToolStripMenuItem
            // 
            this.serialSettingsToolStripMenuItem.Name = "serialSettingsToolStripMenuItem";
            this.serialSettingsToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.serialSettingsToolStripMenuItem.Text = "Serial Settings";
            this.serialSettingsToolStripMenuItem.Click += new System.EventHandler(this.serialSettingsToolStripMenuItem_Click);
            // 
            // userSToolStripMenuItem
            // 
            this.userSToolStripMenuItem.Name = "userSToolStripMenuItem";
            this.userSToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.userSToolStripMenuItem.Text = "Main Screen";
            this.userSToolStripMenuItem.Click += new System.EventHandler(this.userSToolStripMenuItem_Click);
            // 
            // ticketDesignToolStripMenuItem
            // 
            this.ticketDesignToolStripMenuItem.Name = "ticketDesignToolStripMenuItem";
            this.ticketDesignToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.ticketDesignToolStripMenuItem.Text = "Ticket Design";
            this.ticketDesignToolStripMenuItem.Click += new System.EventHandler(this.ticketDesignToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // userFirstScreen
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(801, 518);
            this.Controls.Add(this.clientMenuStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.clientMenuStrip;
            this.Name = "userFirstScreen";
            this.Tag = "";
            this.Text = "ECQ Systems";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.userFirstScreen_Load);
            this.clientMenuStrip.ResumeLayout(false);
            this.clientMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        /* on page load, use timer class to update time on screen
         */
        private void userFirstScreen_Load(object sender, EventArgs e)
        {

            ms.MdiParent = this;
            sc.MdiParent = this;
            td.MdiParent = this;
            if (clientMenuStrip.Visible == false)
                clientMenuStrip.Visible = true;
            this.sc.Show();

        }

        private void serialSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ms.Hide();
           // sc.MdiParent = this;
            this.sc.Show();
            if (this.ms.Visible == true)
            {
                this.ms.Hide();
            }
            else if (this.td.Visible == true)
            {
                this.td.Visible = false;
            }

            statusPanel.Text = ("Setup Serial from Here");
            //sc.Show();
            
            
        }

        private void userSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                clientMenuStrip.Visible = false;
                this.ms.Show();
                if (this.td.Visible == true)
                {
                    this.td.Visible = false;
                }
                else if (this.sc.Visible == true)
                {
                    this.sc.Visible = false;
                }
                
                statusPanel.Text = "User Main Screen";
            }
            catch (Exception except)
            {
                userMainScreen ms = new userMainScreen();
                ms.MdiParent = this;
                ms.logError(except);
                clientMenuStrip.Visible = false;
                this.ms.Visible = true;
                this.ms.Show();
                
                //MessageBox.Show(excep.ToString());
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult exitAll = MessageBox.Show("Are Sure, You want to Exit?", "Question", MessageBoxButtons.YesNo);
            if (exitAll == DialogResult.Yes)
            {
                this.Close(); // close form
                System.Windows.Forms.Application.Exit(); // close entire application
            }
        }

        private void ticketDesignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ms.Visible == true)
                {
                    this.ms.Visible = false;
                }
                else if (this.sc.Visible == true)
                {
                    this.sc.Visible = false;
                }
                this.td.Show();
                statusPanel.Text = "Setup Ticket Template";
            }
            catch (System.ArgumentException argExcept )
            {
                Ticket_Design td = new Ticket_Design();
                td.MdiParent = this;
                ms.logError(argExcept);
                this.td.Visible = true;
                this.td.Show();
            }
        }
    }
}
