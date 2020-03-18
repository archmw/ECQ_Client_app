using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using System.Configuration.Assemblies;
using System.Xml;
using System.IO;

namespace DM_Main
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new ClientLogin());
            //Application.Run(new userFirstScreen());
            if (CheckConfigFileIsPresent())
            {
                string conStr = ConfigurationManager.ConnectionStrings["con"].ToString();
                //MessageBox.Show("It exists"+ conStr);
                if (conStr == "" || conStr == null) // if db connection string is empty, get one from user
                {
                    Application.Run(new DBPath());
                }
                else
                {

                    Application.Run(new ClientLogin(conStr));//
                }

            }
        }

        public static bool CheckConfigFileIsPresent()
        {
            return File.Exists(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
        }
    }
}
