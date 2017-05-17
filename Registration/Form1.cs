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
    public partial class Form1 : Form
    {
        private MySqlConnection mysqlConn;
        const string connString = "Server=localhost;Database=testdb;Uid=tester;Pwd=test";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string connString = "Server=localhost;Database=testdb;Uid=tester;Pwd=test";
            mysqlConn = new MySqlConnection(connString);

            mysqlConn.Open();
            if (mysqlConn.State == ConnectionState.Open) {
                MessageBox.Show("open");
            }
            else{
                MessageBox.Show("fail");
            }
            mysqlConn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = "142857";
            string sha = Utility.generateSHA(s);
            MessageBox.Show(sha);
            MessageBox.Show(sha.Length.ToString());
            string s1 = "abcdefgh";
            sha = Utility.generateSHA(s1);
            MessageBox.Show(sha);
            MessageBox.Show(sha.Length.ToString());
        }

        private void CreateNewUser(string userName, string password) {
            string cmdText = "INSERT INTO account_info (user_name,password) VALUES (@user_name,@password)";
            using (MySqlConnection sqlConn = new MySqlConnection(connString)) {
                MySqlCommand cmd = new MySqlCommand(cmdText, sqlConn);
                cmd.Parameters.Add("@user_name", MySqlDbType.VarChar).Value =userName;
                string shaPwd = Utility.generateSHA(password);
                cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = shaPwd;

                try
                {
                    sqlConn.Open();
                    int result = cmd.ExecuteNonQuery();
                }
                catch (Exception e) {
                    MessageBox.Show(e.Message);
                }
            }
        }


        private Boolean loginValidate(string userName, string password) {
            string commandText = "SELECT COUNT(*) FROM testdb.account_info WHERE user_name =@user_name AND password =@password";
            using (MySqlConnection sqlConn = new MySqlConnection(connString)) {
                MySqlCommand cmd = new MySqlCommand(commandText, sqlConn);
                cmd.Parameters.Add("@user_name", MySqlDbType.VarChar);
                cmd.Parameters.Add("@password", MySqlDbType.VarChar);

                string shaPwd = Utility.generateSHA(password);

                cmd.Parameters["@user_name"].Value = userName;
                cmd.Parameters["@password"].Value = shaPwd;
                try
                {
                    sqlConn.Open();
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    return (result > 0) ? true : false;
                }
                catch (Exception e) {
                    MessageBox.Show(e.Message);
                }
            }
            return false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Utility.createStatesTable();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string user_name = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            Boolean result = loginValidate(user_name, password);

            if (result)
            {
                MessageBox.Show("Validate");
            }
            else {
                MessageBox.Show("Failed");
            }
        }
    }
}
