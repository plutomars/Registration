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

        private bool login(string userName,string password) {
            string cmdTxt = "SELECT COUNT(*) FROM testdb.account_info WHERE user_name =@user_name AND password =@password";
            using (MySqlConnection conn = new MySqlConnection(connString)) {
                MySqlCommand cmd = new MySqlCommand(cmdTxt,conn);
                cmd.Parameters.Add("@user_name", MySqlDbType.VarChar);
                cmd.Parameters.Add("@password", MySqlDbType.VarChar);

                string shaPwd = Utility.generateSHA(password);

                cmd.Parameters["@user_name"].Value = userName;
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
    }
}
