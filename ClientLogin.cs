using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
namespace DM_Main
{
    public partial class ClientLogin : Form
    {
        static string strCon = null;
        public ClientLogin(string str)
        {
            strCon = str;
            InitializeComponent();
        }

        private void tbUsername_Enter(object sender, EventArgs e)
        {
            if (tbUsername.Text == "User Name")
            {
                tbUsername.Text = null;
                tbUsername.Focus();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult exitAll = MessageBox.Show("Are Sure, You want to Exit?", "Question", MessageBoxButtons.YesNo);
            if (exitAll == DialogResult.Yes)
            {
                this.Close(); // close form
                System.Windows.Forms.Application.Exit(); // close entire application
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string test = null;
            string sqlName = null;
            string password = tbpassword.Text;
            
            //string sqlName = @"Data Source=ABC-PC\SQL2005;Initial Catalog=testSQL;Integrated Security=True;";
            ConfigurationManager.RefreshSection("connectionStrings");
            
            SqlConnection sqlCon = new SqlConnection(sqlName);
            sqlCon.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ToString();
            SqlDataAdapter sqlDA = new SqlDataAdapter("SELECT count(*) as count,* From Login WHERE user_name='" + tbUsername.Text + "' and password = '" + tbpassword.Text + "' and UserType = 2 and [is_delete]= 0 GROUP BY ID,user_name,password,UserType, is_delete", sqlCon);
            DataTable sqlDt = new DataTable();
            int tableEmpty = sqlDA.Fill(sqlDt);
            if (tableEmpty > 0) // check is username and password match
            {
                if (sqlDt.Rows[0][0].ToString() == "1")
                {
                    this.Hide();
                    test = sqlDt.Rows[0][2].ToString();
                    if (test == tbUsername.Text && (sqlDt.Rows[0][4].ToString() == "2"))
                    {
                        userFirstScreen ufs = new userFirstScreen();
                        ufs.Show();
                        this.Hide();
                        MessageBox.Show("Welcome " + test + "!");
                    }
                    //MessageBox.Show("Welcome " + test + "!");

                }
            }
            else
            {
                lmsgcred.Text = "Please Check User Name And Password";
                lmsgcred.Visible = true;
                tbpassword.Text = "";
                tbUsername.Text = "";
                tbUsername.Focus();
                //MessageBox.Show("Please Check User Name And Password");
            }
        }

        
        private void tbpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {   
                btnLogin_Click(sender, e);
            }
        }

       
    }
}
