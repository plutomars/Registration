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
using System.
using System.Text.RegularExpressions;

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
            cbxState.DataSource = Utility.createStatesTable();
            cbxState.DisplayMember = "fullname";
            cbxState.ValueMember = "abbreviation";

            cbxPolitical.DataSource = Utility.createPartiesTable();
            cbxPolitical.DisplayMember = "party_type";
            cbxPolitical.ValueMember = "value";
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

            string cmdTxt_1 = "INSERT INTO testdb.account_info VALUES (@account,@password) ";
            string cmdTxt_2 = "INSERT INTO testdb.info VALUES (@account,@first_name,@mid_name,@last_name,@gender,@birth_date," +
                              "@city,@state,@cell_phone,@email,@political_affiliation)";
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
                cmd_2.Parameters.Add("@birth_date", MySqlDbType.Date).Value = birth_date;
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

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            saveData();
        }

        private void Registeration_Load(object sender, EventArgs e)
        {
            init();
        }

        private bool checkIdAvailable()
        {
            string cmdTxt = "SELECT COUNT(*) FROM testdb.account_info WHERE account = @account";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                MySqlCommand cmd = new MySqlCommand(cmdTxt, conn);
                cmd.Parameters.Add("@account", MySqlDbType.VarChar).Value = txtUserName.Text.Trim();
                int result = Convert.ToInt32(cmd.ExecuteScalar());
                return result > 0 ? false : true;
            }
        }

        private bool checkPwd() {
            if (string.IsNullOrEmpty(txtPwd.Text) || string.IsNullOrEmpty(txtRePwd.Text)) return false;
            if (txtPwd.Text != txtRePwd.Text) return false;
            return true;
        }

        private bool checkGender() {
            if (!rbnMan.Checked && !rbnFemale.Checked) return false;
            return true;
        }

        private bool checkName() {
            if (string.IsNullOrEmpty(txtFirst.Text) || string.IsNullOrEmpty(txtLast.Text)) return false;
            return true;
        }

        private bool checkCity() {
            if (string.IsNullOrEmpty(txtCity.Text)) return false;
            return true;
        }

        private bool checkState() {
            if (string.IsNullOrEmpty(cbxState.SelectedText)) return false;
            return true;
        }

        private bool emailCheck()
        {
            string email = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
            return Regex.IsMatch(txtemail.Text.Trim(), email);
        }

        private bool phoneCheck()
        {
            string phone = @"^((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$";
            return Regex.IsMatch(txtCell.Text.Trim(), phone);
        }

        private bool checkPolitical() {
            if (string.IsNullOrEmpty(cbxPolitical.SelectedText)) return false;
            return true;
        }

        private bool validateData() {
            if (!checkIdAvailable()) return false;
            if (!checkPwd()) return false;
            if (!checkName()) return false;
            if (!checkGender()) return false;
            if (!checkCity()) return false;
            if (!checkState()) return false;
            if (!phoneCheck()) return false;
            if (!emailCheck()) return false;
            if (!checkPolitical()) return false;
            return true;
        }
    }
}
