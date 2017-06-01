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
using System.Text.RegularExpressions;
using System.Globalization;

namespace Registration
{
    public partial class Registeration : Form
    {

        MainForm mainform;
        const string connString = "Server=localhost;Database=testdb;Uid=tester;Pwd=test";

        public Registeration(MainForm mainForm)
        {
            InitializeComponent();
            this.mainform = mainForm;
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
            if (validateData()) {
                saveData();
                MessageBox.Show("Create a new user successful!!");
            }
            this.Close();
            mainform.Show();
        }

        private void Registeration_Load(object sender, EventArgs e)
        {
            init();
        }

        private bool checkIdAvailable()
        {
            if (string.IsNullOrEmpty(txtUserName.Text)) return false;
            string cmdTxt = "SELECT COUNT(*) FROM testdb.account_info WHERE account = @account";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                MySqlCommand cmd = new MySqlCommand(cmdTxt, conn);
                if (conn.State == ConnectionState.Closed) conn.Open();
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
            if (string.IsNullOrEmpty(cbxState.SelectedValue.ToString())) return false;
            return true;
        }

        private bool emailCheck()
        {
            string email = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
            return Regex.IsMatch(txtemail.Text.Trim(), email);
        }

        private string transformPhone() {
            string s = txtCell.Text;
            if (string.IsNullOrEmpty(s)) return "";
            if (txtCell.Text.Length > 10) {
                return String.Format("{0:###}-{1:###}-{2:####}", s.Substring(0, 3), s.Substring(4, 3), s.Substring(8, 4));
            }
            return String.Format("{0:###-###-####}", Convert.ToInt64(txtCell.Text));
        }

        private bool phoneCheck()
        {
            string phone = @"^((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$";
            txtCell.Text = transformPhone();
            return Regex.IsMatch(txtCell.Text.Trim(), phone);
        }

        private bool checkPolitical() {
            if (string.IsNullOrEmpty(cbxPolitical.SelectedValue.ToString())) return false;
            return true;
        }

        private string TransferDate(string value) {
            if (string.IsNullOrEmpty(value)) return "";
            DateTime dateTime;
            if (!DateTime.TryParse(value,  out dateTime)) return "";
            return dateTime.ToString("yyyy-MM-dd");
        }

        private bool checkDate() {
            txtBirthdate.Text = TransferDate(txtBirthdate.Text);
            if (string.IsNullOrEmpty(txtBirthdate.Text)) return false;
            return true;            
        }

        private bool validateData() {
            if (!checkIdAvailable()) return false;
            if (!checkPwd()) return false;
            if (!checkName()) return false;
            if (!checkDate()) return false;
            if (!checkGender()) return false;
            if (!checkCity()) return false;
            if (!checkState()) return false;
            if (!phoneCheck()) return false;
            if (!emailCheck()) return false;
            if (!checkPolitical()) return false;
            return true;
        }

        private void validatingData(Object sender, CancelEventArgs e) {
            if (sender is TextBox) {
                TextBox txt = (TextBox)sender;

                switch (txt.Name) {
                    case "txtUserName":
                        errorProvider1.SetError(txt, "");
                        if (!checkIdAvailable()) errorProvider1.SetError(txt, "userName unavailable please re-enter");
                        break;
                    case "txtPwd":
                        errorProvider1.SetError(txt, "");
                        if (!checkPwd()) errorProvider1.SetError(txt, "password does not match");
                        break;
                    case "txtFirst":
                        errorProvider1.SetError(txt, "");
                        if (string.IsNullOrEmpty(txt.Text)) errorProvider1.SetError(txt, "first name cannot be empty");
                        break;
                    case "txtLast":
                        errorProvider1.SetError(txt, "");
                        if (string.IsNullOrEmpty(txt.Text)) errorProvider1.SetError(txt, "last name cannot be empty");
                        break;
                    case "txtBirthdate":
                        errorProvider1.SetError(txt, "");
                        if (!checkDate()) errorProvider1.SetError(txt, "birthdate format error");
                        break;
                    case "txtCity":
                        errorProvider1.SetError(txt, "");
                        if (!checkCity()) errorProvider1.SetError(txtCity, "city cannot be empty");
                        break;
                    case "txtCell":
                        errorProvider1.SetError(txt, "");
                        if (!phoneCheck()) errorProvider1.SetError(txt, "phone's format error");
                        break;
                    case "txtemail":
                        errorProvider1.SetError(txt, "");
                        if (!emailCheck()) errorProvider1.SetError(txt, "email's format error");
                        break;
                }
            }

            if (sender is ComboBox) {
                ComboBox cbx = (ComboBox)sender;

                switch (cbx.Name) {
                    case "cbxState":
                        errorProvider1.SetError(cbx, "");
                        if (!checkState()) errorProvider1.SetError(cbx, "state cannot be empty");
                        break;
                    case "cbxPolitical":
                        errorProvider1.SetError(cbx, "");
                        if (!checkPolitical()) errorProvider1.SetError(cbx, "political affiliation cannot be empty");
                        break;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            mainform.Show();
        }

        private new void Validating(object sender, CancelEventArgs e) {
            this.validatingData(sender, e);
        }
    }
}
