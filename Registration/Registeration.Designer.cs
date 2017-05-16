namespace Registration
{
    partial class Registeration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbxAccount = new System.Windows.Forms.GroupBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPwd = new System.Windows.Forms.Label();
            this.lblRePwd = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtRePwd = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbxInfo = new System.Windows.Forms.GroupBox();
            this.lblFirst = new System.Windows.Forms.Label();
            this.lblMid = new System.Windows.Forms.Label();
            this.lblLast = new System.Windows.Forms.Label();
            this.txtFirst = new System.Windows.Forms.TextBox();
            this.txtMid = new System.Windows.Forms.TextBox();
            this.txtLast = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblGender = new System.Windows.Forms.Label();
            this.rbnMan = new System.Windows.Forms.RadioButton();
            this.rbnFemale = new System.Windows.Forms.RadioButton();
            this.lblBirth = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.cbxState = new System.Windows.Forms.ComboBox();
            this.lblCell = new System.Windows.Forms.Label();
            this.txtCell = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblPolitical = new System.Windows.Forms.Label();
            this.cbxPolitical = new System.Windows.Forms.ComboBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbxAccount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.gbxInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxAccount
            // 
            this.gbxAccount.Controls.Add(this.txtRePwd);
            this.gbxAccount.Controls.Add(this.txtPwd);
            this.gbxAccount.Controls.Add(this.txtUserName);
            this.gbxAccount.Controls.Add(this.lblRePwd);
            this.gbxAccount.Controls.Add(this.lblPwd);
            this.gbxAccount.Controls.Add(this.lblUserName);
            this.gbxAccount.Location = new System.Drawing.Point(12, 12);
            this.gbxAccount.Name = "gbxAccount";
            this.gbxAccount.Size = new System.Drawing.Size(393, 131);
            this.gbxAccount.TabIndex = 0;
            this.gbxAccount.TabStop = false;
            this.gbxAccount.Text = "AccountInfo";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(11, 27);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(57, 13);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "UserName";
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.Location = new System.Drawing.Point(11, 62);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(53, 13);
            this.lblPwd.TabIndex = 1;
            this.lblPwd.Text = "Password";
            // 
            // lblRePwd
            // 
            this.lblRePwd.AutoSize = true;
            this.lblRePwd.Location = new System.Drawing.Point(11, 97);
            this.lblRePwd.Name = "lblRePwd";
            this.lblRePwd.Size = new System.Drawing.Size(97, 13);
            this.lblRePwd.TabIndex = 2;
            this.lblRePwd.Text = "Re-enter Password";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(142, 19);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(227, 20);
            this.txtUserName.TabIndex = 3;
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(142, 55);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(227, 20);
            this.txtPwd.TabIndex = 4;
            // 
            // txtRePwd
            // 
            this.txtRePwd.Location = new System.Drawing.Point(142, 90);
            this.txtRePwd.Name = "txtRePwd";
            this.txtRePwd.Size = new System.Drawing.Size(227, 20);
            this.txtRePwd.TabIndex = 5;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // gbxInfo
            // 
            this.gbxInfo.Controls.Add(this.cbxPolitical);
            this.gbxInfo.Controls.Add(this.lblPolitical);
            this.gbxInfo.Controls.Add(this.textBox2);
            this.gbxInfo.Controls.Add(this.lblEmail);
            this.gbxInfo.Controls.Add(this.txtCell);
            this.gbxInfo.Controls.Add(this.lblCell);
            this.gbxInfo.Controls.Add(this.cbxState);
            this.gbxInfo.Controls.Add(this.txtCity);
            this.gbxInfo.Controls.Add(this.lblState);
            this.gbxInfo.Controls.Add(this.lblCity);
            this.gbxInfo.Controls.Add(this.textBox1);
            this.gbxInfo.Controls.Add(this.lblBirth);
            this.gbxInfo.Controls.Add(this.panel1);
            this.gbxInfo.Controls.Add(this.txtLast);
            this.gbxInfo.Controls.Add(this.txtMid);
            this.gbxInfo.Controls.Add(this.txtFirst);
            this.gbxInfo.Controls.Add(this.lblLast);
            this.gbxInfo.Controls.Add(this.lblMid);
            this.gbxInfo.Controls.Add(this.lblFirst);
            this.gbxInfo.Location = new System.Drawing.Point(12, 149);
            this.gbxInfo.Name = "gbxInfo";
            this.gbxInfo.Size = new System.Drawing.Size(393, 386);
            this.gbxInfo.TabIndex = 1;
            this.gbxInfo.TabStop = false;
            this.gbxInfo.Text = "Personal Information";
            // 
            // lblFirst
            // 
            this.lblFirst.AutoSize = true;
            this.lblFirst.Location = new System.Drawing.Point(11, 29);
            this.lblFirst.Name = "lblFirst";
            this.lblFirst.Size = new System.Drawing.Size(57, 13);
            this.lblFirst.TabIndex = 2;
            this.lblFirst.Text = "First Name";
            // 
            // lblMid
            // 
            this.lblMid.AutoSize = true;
            this.lblMid.Location = new System.Drawing.Point(11, 64);
            this.lblMid.Name = "lblMid";
            this.lblMid.Size = new System.Drawing.Size(69, 13);
            this.lblMid.TabIndex = 3;
            this.lblMid.Text = "Middle Name";
            // 
            // lblLast
            // 
            this.lblLast.AutoSize = true;
            this.lblLast.Location = new System.Drawing.Point(11, 101);
            this.lblLast.Name = "lblLast";
            this.lblLast.Size = new System.Drawing.Size(58, 13);
            this.lblLast.TabIndex = 4;
            this.lblLast.Text = "Last Name";
            // 
            // txtFirst
            // 
            this.txtFirst.Location = new System.Drawing.Point(142, 26);
            this.txtFirst.Name = "txtFirst";
            this.txtFirst.Size = new System.Drawing.Size(227, 20);
            this.txtFirst.TabIndex = 5;
            // 
            // txtMid
            // 
            this.txtMid.Location = new System.Drawing.Point(142, 61);
            this.txtMid.Name = "txtMid";
            this.txtMid.Size = new System.Drawing.Size(227, 20);
            this.txtMid.TabIndex = 6;
            // 
            // txtLast
            // 
            this.txtLast.Location = new System.Drawing.Point(142, 98);
            this.txtLast.Name = "txtLast";
            this.txtLast.Size = new System.Drawing.Size(227, 20);
            this.txtLast.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbnFemale);
            this.panel1.Controls.Add(this.rbnMan);
            this.panel1.Controls.Add(this.lblGender);
            this.panel1.Location = new System.Drawing.Point(6, 132);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 32);
            this.panel1.TabIndex = 8;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(5, 9);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(42, 13);
            this.lblGender.TabIndex = 0;
            this.lblGender.Text = "Gender";
            // 
            // rbnMan
            // 
            this.rbnMan.AutoSize = true;
            this.rbnMan.Location = new System.Drawing.Point(140, 7);
            this.rbnMan.Name = "rbnMan";
            this.rbnMan.Size = new System.Drawing.Size(46, 17);
            this.rbnMan.TabIndex = 1;
            this.rbnMan.TabStop = true;
            this.rbnMan.Text = "Man";
            this.rbnMan.UseVisualStyleBackColor = true;
            // 
            // rbnFemale
            // 
            this.rbnFemale.AutoSize = true;
            this.rbnFemale.Location = new System.Drawing.Point(293, 7);
            this.rbnFemale.Name = "rbnFemale";
            this.rbnFemale.Size = new System.Drawing.Size(59, 17);
            this.rbnFemale.TabIndex = 2;
            this.rbnFemale.TabStop = true;
            this.rbnFemale.Text = "Female";
            this.rbnFemale.UseVisualStyleBackColor = true;
            // 
            // lblBirth
            // 
            this.lblBirth.AutoSize = true;
            this.lblBirth.Location = new System.Drawing.Point(11, 178);
            this.lblBirth.Name = "lblBirth";
            this.lblBirth.Size = new System.Drawing.Size(49, 13);
            this.lblBirth.TabIndex = 9;
            this.lblBirth.Text = "Birthdate";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(142, 175);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(227, 20);
            this.textBox1.TabIndex = 10;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(11, 210);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(24, 13);
            this.lblCity.TabIndex = 11;
            this.lblCity.Text = "City";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(11, 244);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(32, 13);
            this.lblState.TabIndex = 12;
            this.lblState.Text = "State";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(142, 207);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(227, 20);
            this.txtCity.TabIndex = 13;
            // 
            // cbxState
            // 
            this.cbxState.FormattingEnabled = true;
            this.cbxState.Location = new System.Drawing.Point(142, 241);
            this.cbxState.Name = "cbxState";
            this.cbxState.Size = new System.Drawing.Size(227, 21);
            this.cbxState.TabIndex = 14;
            // 
            // lblCell
            // 
            this.lblCell.AutoSize = true;
            this.lblCell.Location = new System.Drawing.Point(11, 280);
            this.lblCell.Name = "lblCell";
            this.lblCell.Size = new System.Drawing.Size(84, 13);
            this.lblCell.TabIndex = 15;
            this.lblCell.Text = "Cell Number/Tel";
            // 
            // txtCell
            // 
            this.txtCell.Location = new System.Drawing.Point(142, 277);
            this.txtCell.Name = "txtCell";
            this.txtCell.Size = new System.Drawing.Size(227, 20);
            this.txtCell.TabIndex = 16;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(11, 314);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 17;
            this.lblEmail.Text = "Email";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(142, 311);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(227, 20);
            this.textBox2.TabIndex = 18;
            // 
            // lblPolitical
            // 
            this.lblPolitical.AutoSize = true;
            this.lblPolitical.Location = new System.Drawing.Point(11, 350);
            this.lblPolitical.Name = "lblPolitical";
            this.lblPolitical.Size = new System.Drawing.Size(88, 13);
            this.lblPolitical.TabIndex = 19;
            this.lblPolitical.Text = "Political Affiliation";
            // 
            // cbxPolitical
            // 
            this.cbxPolitical.FormattingEnabled = true;
            this.cbxPolitical.Location = new System.Drawing.Point(142, 347);
            this.cbxPolitical.Name = "cbxPolitical";
            this.cbxPolitical.Size = new System.Drawing.Size(227, 21);
            this.cbxPolitical.TabIndex = 20;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(12, 560);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(135, 23);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(270, 560);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(135, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // Registeration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 605);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.gbxInfo);
            this.Controls.Add(this.gbxAccount);
            this.Name = "Registeration";
            this.Text = "Registeration";
            this.gbxAccount.ResumeLayout(false);
            this.gbxAccount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.gbxInfo.ResumeLayout(false);
            this.gbxInfo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxAccount;
        private System.Windows.Forms.TextBox txtRePwd;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblRePwd;
        private System.Windows.Forms.Label lblPwd;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox gbxInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbnFemale;
        private System.Windows.Forms.RadioButton rbnMan;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.TextBox txtLast;
        private System.Windows.Forms.TextBox txtMid;
        private System.Windows.Forms.TextBox txtFirst;
        private System.Windows.Forms.Label lblLast;
        private System.Windows.Forms.Label lblMid;
        private System.Windows.Forms.Label lblFirst;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblBirth;
        private System.Windows.Forms.ComboBox cbxState;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.ComboBox cbxPolitical;
        private System.Windows.Forms.Label lblPolitical;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtCell;
        private System.Windows.Forms.Label lblCell;
    }
}