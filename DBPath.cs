using System;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Xml;

namespace DM_Main
{
    public partial class DBPath : Form
    {
        public DBPath()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSetdbOK_Click(object sender, EventArgs e)
        {
            this.Hide();
            string sname = tbServerName.Text;
            string db = tbDBName.Text;

            StringBuilder Con = new StringBuilder("Data Source=");
            Con.Append(sname);
            Con.Append(";Initial Catalog=");
            Con.Append(db);
            Con.Append(";Integrated Security=true;");
            string strCon = Con.ToString();

            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            connectionStringsSection.ConnectionStrings["con"].ConnectionString = strCon;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");

           
            string conStr = ConfigurationManager.ConnectionStrings["con"].ToString();
            if (conStr != "" || conStr != null)
            {
                 ClientLogin cl =  new ClientLogin(conStr);
                //MessageBox.Show("Constr: " + conStr);
                 cl.Show();
            }
        }
        public void updateConfigFile(string con)
        {
            //updating config file
            XmlDocument XmlDoc = new XmlDocument();
            //Loading the Config file

            XmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);


            foreach (XmlElement xElement in XmlDoc.DocumentElement)
            {
                if (xElement.Name == "connectionStrings")
                {
                    //setting the coonection string
                    xElement.FirstChild.Attributes[2].Value = con;
                }
            }
            //writing the connection string in config file
            XmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
        }

       
    }
}
