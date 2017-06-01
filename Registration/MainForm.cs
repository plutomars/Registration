using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Registration
{
    
    public partial class MainForm : Form
    {

        const string connString = "Server=localhost;Database=testdb;Uid=tester;Pwd=test";
        private MySqlConnection mysqlConn;
        BaseWindow bs = new BaseWindow();


        public MainForm()
        {
            InitializeComponent();
        }

        //private void init() {
        //    mysqlConn = new MySqlConnection(connString);
        //    if (mysqlConn.State == ConnectionState.Open) return;
        //    mysqlConn.Open();
        //}

        private bool validateData() {
            if (string.IsNullOrEmpty(txtUserName.Text)) return false;
            if (string.IsNullOrEmpty(txtPwd.Text)) return false;
            return true;
        }

        private bool login(string account,string password) {
            string cmdTxt = "SELECT COUNT(*) FROM testdb.account_info WHERE account =@account AND password =@password";
            using (MySqlConnection conn = new MySqlConnection(connString)) {
                MySqlCommand cmd = new MySqlCommand(cmdTxt,conn);
                cmd.Parameters.Add("@account", MySqlDbType.VarChar);
                cmd.Parameters.Add("@password", MySqlDbType.VarChar);

                string shaPwd = Utility.generateSHA(password);

                cmd.Parameters["@account"].Value = account;
                cmd.Parameters["@password"].Value = shaPwd;

                try
                {
                    conn.Open();
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    return (result > 0) ? true : false;
                }
                catch (Exception e) {
                    MessageBox.Show(e.Message);
                }
            }
            return false;
        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Registeration rs = new Registeration(this);
            this.Hide();
            rs.Show(this);
            //this.Close();
        }
    }
}
