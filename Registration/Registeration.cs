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
    public partial class Registeration : Form
    {

        const string connString = "Server=localhost;Database=testdb;Uid=tester;Pwd=test";

        public Registeration()
        {
            InitializeComponent();
        }

        private void init() {
            //MySqlConnection conn = new MySqlConnection(connString);
            //if (conn.State == ConnectionState.Open) return;
            //conn.Open();
        }



        private void saveData() {
            string account = txtUserName.Text.Trim();
            string password = Utility.generateSHA(txtPwd.Text.Trim());
            string first_name = txtFirst.Text.Trim();
            string mid_name = txtMid.Text.Trim();
            string last_name = txtLast.Text.Trim();
            int gender = rbnMan.Checked? 1 : 0;
            string birth_date = txtBirthdate.Text.Trim();
            string city = txtCity.Text.Trim();
            string state = cbxState.SelectedValue.ToString();
            string cell_phone = txtCell.Text.Trim();
            string email = txtemail.Text.Trim();
            string political_affiliation = cbxPolitical.SelectedValue.ToString();

            string cmdTxt_1 = "INSERT INTO testdb.account VALUES (@account,@password) ";
            string cmdTxt_2 = "INSERT INTO testdb.info VALUES (@account,@first_name,@mid_name,@last_name,@gender,@birth_date," +
                              "@city,@state,@cell_phone,@email,' ',@political_affiliation)";
            using (MySqlConnection conn = new MySqlConnection(connString)) {
                MySqlCommand cmd_1 = new MySqlCommand(cmdTxt_1, conn);
                cmd_1.Parameters.Add("@account", MySqlDbType.VarChar).Value = account;
                cmd_1.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;

                try
                {
                    conn.Open();
                    int result = cmd_1.ExecuteNonQuery();
                }
                catch (Exception e) {
                    MessageBox.Show(e.Message);
                }

                MySqlCommand cmd_2 = new MySqlCommand(cmdTxt_2, conn);
                cmd_2.Parameters.Add("@account", MySqlDbType.VarChar).Value = account;
                cmd_2.Parameters.Add("@first_name", MySqlDbType.VarChar).Value = first_name;
                cmd_2.Parameters.Add("@mid_name", MySqlDbType.VarChar).Value = mid_name;
                cmd_2.Parameters.Add("@last_name", MySqlDbType.VarChar).Value = last_name;
                cmd_2.Parameters.Add("@gender", MySqlDbType.Int16).Value = gender;
                cmd_2.Parameters.Add("@birth_date", MySqlDbType.VarChar).Value = birth_date;
                cmd_2.Parameters.Add("@city", MySqlDbType.VarChar).Value = city;
                cmd_2.Parameters.Add("@state", MySqlDbType.VarChar).Value = state;
                cmd_2.Parameters.Add("@cell_phone", MySqlDbType.VarChar).Value = cell_phone;
                cmd_2.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
                cmd_2.Parameters.Add("@political_affiliation", MySqlDbType.VarChar).Value = political_affiliation;

                try
                {
                    if (conn.State != ConnectionState.Open) conn.Open();
                    int result = cmd_2.ExecuteNonQuery();
                }
                catch (Exception e) {
                    MessageBox.Show(e.Message);
                }
            }
        }
    }
}
