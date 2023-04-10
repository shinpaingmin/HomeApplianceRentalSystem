namespace HomeApplianceRentalSystem
{
    partial class FrmRegistration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegistration));
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.chkBoxShowPwd = new System.Windows.Forms.CheckBox();
            this.linklblLogin = new System.Windows.Forms.LinkLabel();
            this.txtConfirmPwd = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cmdRegister = new System.Windows.Forms.Button();
            this.lblConfirmPwd = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.pnlLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLogin
            // 
            this.pnlLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlLogin.Controls.Add(this.chkBoxShowPwd);
            this.pnlLogin.Controls.Add(this.linklblLogin);
            this.pnlLogin.Controls.Add(this.txtConfirmPwd);
            this.pnlLogin.Controls.Add(this.txtPassword);
            this.pnlLogin.Controls.Add(this.cmdRegister);
            this.pnlLogin.Controls.Add(this.lblConfirmPwd);
            this.pnlLogin.Controls.Add(this.txtUsername);
            this.pnlLogin.Controls.Add(this.lblPassword);
            this.pnlLogin.Controls.Add(this.lblUsername);
            this.pnlLogin.Controls.Add(this.lblLogin);
            this.pnlLogin.Location = new System.Drawing.Point(77, 63);
            this.pnlLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(336, 465);
            this.pnlLogin.TabIndex = 1;
            // 
            // chkBoxShowPwd
            // 
            this.chkBoxShowPwd.AutoSize = true;
            this.chkBoxShowPwd.BackColor = System.Drawing.Color.Transparent;
            this.chkBoxShowPwd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkBoxShowPwd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkBoxShowPwd.ForeColor = System.Drawing.Color.Plum;
            this.chkBoxShowPwd.Location = new System.Drawing.Point(60, 346);
            this.chkBoxShowPwd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkBoxShowPwd.Name = "chkBoxShowPwd";
            this.chkBoxShowPwd.Size = new System.Drawing.Size(122, 20);
            this.chkBoxShowPwd.TabIndex = 15;
            this.chkBoxShowPwd.Text = "Show Password";
            this.chkBoxShowPwd.UseVisualStyleBackColor = false;
            this.chkBoxShowPwd.CheckedChanged += new System.EventHandler(this.chkBoxShowPwd_CheckedChanged);
            // 
            // linklblLogin
            // 
            this.linklblLogin.AutoSize = true;
            this.linklblLogin.BackColor = System.Drawing.Color.Transparent;
            this.linklblLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklblLogin.LinkColor = System.Drawing.Color.Plum;
            this.linklblLogin.Location = new System.Drawing.Point(128, 425);
            this.linklblLogin.Name = "linklblLogin";
            this.linklblLogin.Size = new System.Drawing.Size(54, 22);
            this.linklblLogin.TabIndex = 12;
            this.linklblLogin.TabStop = true;
            this.linklblLogin.Text = "Login";
            this.linklblLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblLogin_LinkClicked);
            // 
            // txtConfirmPwd
            // 
            this.txtConfirmPwd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConfirmPwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPwd.Location = new System.Drawing.Point(60, 316);
            this.txtConfirmPwd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtConfirmPwd.Name = "txtConfirmPwd";
            this.txtConfirmPwd.Size = new System.Drawing.Size(228, 23);
            this.txtConfirmPwd.TabIndex = 9;
            this.txtConfirmPwd.UseSystemPasswordChar = true;
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(60, 228);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(228, 23);
            this.txtPassword.TabIndex = 8;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // cmdRegister
            // 
            this.cmdRegister.BackColor = System.Drawing.Color.Plum;
            this.cmdRegister.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cmdRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRegister.ForeColor = System.Drawing.Color.White;
            this.cmdRegister.Location = new System.Drawing.Point(83, 377);
            this.cmdRegister.Margin = new System.Windows.Forms.Padding(0);
            this.cmdRegister.Name = "cmdRegister";
            this.cmdRegister.Size = new System.Drawing.Size(155, 36);
            this.cmdRegister.TabIndex = 7;
            this.cmdRegister.Text = "Create Account";
            this.cmdRegister.UseVisualStyleBackColor = false;
            this.cmdRegister.Click += new System.EventHandler(this.cmdRegister_Click);
            // 
            // lblConfirmPwd
            // 
            this.lblConfirmPwd.AutoSize = true;
            this.lblConfirmPwd.BackColor = System.Drawing.Color.Transparent;
            this.lblConfirmPwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPwd.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblConfirmPwd.Location = new System.Drawing.Point(58, 276);
            this.lblConfirmPwd.Name = "lblConfirmPwd";
            this.lblConfirmPwd.Size = new System.Drawing.Size(161, 22);
            this.lblConfirmPwd.TabIndex = 5;
            this.lblConfirmPwd.Text = "Confirm Password:";
            // 
            // txtUsername
            // 
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(60, 132);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(228, 23);
            this.txtUsername.TabIndex = 3;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblPassword.Location = new System.Drawing.Point(58, 186);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(94, 22);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblUsername.Location = new System.Drawing.Point(58, 99);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(97, 22);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Username:";
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.BackColor = System.Drawing.Color.Transparent;
            this.lblLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.ForeColor = System.Drawing.Color.Plum;
            this.lblLogin.Location = new System.Drawing.Point(59, 43);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(229, 42);
            this.lblLogin.TabIndex = 0;
            this.lblLogin.Text = "Registration";
            // 
            // FrmRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(219)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(502, 573);
            this.Controls.Add(this.pnlLogin);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmRegistration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registration Form";
            this.Load += new System.EventHandler(this.FrmRegistration_Load);
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.TextBox txtConfirmPwd;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button cmdRegister;
        private System.Windows.Forms.Label lblConfirmPwd;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.LinkLabel linklblLogin;
        private System.Windows.Forms.CheckBox chkBoxShowPwd;
    }
}