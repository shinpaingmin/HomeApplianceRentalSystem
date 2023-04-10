using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeApplianceRentalSystem
{
    public partial class FrmRegistration : Form
    {
        List<UserAccounts> accounts;    //Declare a variable for list which will store an object
        UserAccounts normalUser;    //Declare variable for object
        
        public FrmRegistration()
        {
            InitializeComponent();
        }

        private void FrmRegistration_Load(object sender, EventArgs e)
        {
            accounts = new List<UserAccounts>();  //  Create a list to store user accounts
            txtConfirmPwd.Text = "";    //Clear textFields
            txtPassword.Text = "";
            txtConfirmPwd.Text = "";
        }
        //Function to add account in list
        private void addAccount (string n, string p)
        {
            normalUser = new UserAccounts(n, p);    //Initialize object using constructor method
            accounts.Add(normalUser);
            if (accounts.Contains(normalUser) == true)  // To check out whether there is object in list or not.
            {
                Console.WriteLine("There is/are " + accounts.Count + " object/s in the list");  //Checking the count of list for testing
            }
        }
        //Name validation function
        private Boolean nameValidation (string n)
        {
            Regex val = new Regex(@"^[a-zA-Z0-9]*$"); // Creating a Regular Expression object for name validation
            if (val.IsMatch(n) == false)
            {
                MessageBox.Show("Username can contain only letters and numbers. (eg. abc123)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsername.Focus();    //not to raise error
                return false;
            } else
            {
                return true;
            }          
        }
        //Password Validation
        private Boolean passwordValidation (string p)
        { 
            Regex val = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).+$"); // Creating a Regular Expression object for password validation
            if (val.IsMatch(p) == false)
            {
                MessageBox.Show("Password must contain at least one lowercase, one uppercase, a number and a special character.(eg. abcdef@123)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Focus();    //not to raise error
                return false;
            } else
            {
                return true;
            }
        }
        //Register button
        private void cmdRegister_Click(object sender, EventArgs e)
        {
            string name, password, confirmPwd;
            name = txtUsername.Text.ToString();     //assigning value from textBox to a variable
            password = txtPassword.Text.ToString();          
            confirmPwd = txtConfirmPwd.Text.ToString();
            
            //Validations for creating account
            if (name != "" && password != "" && confirmPwd != "")   //Checking null
            {
                if (name.Length > 6 && name.Length < 15)
                {
                    if (password.Length > 8 && password.Length < 16)    //Checking length
                    {
                        if (password == confirmPwd)     //Checking whether password and confirmpwd are the same
                        {
                            nameValidation(name);   // Passing the name input to function
                            passwordValidation(password);   //Passing the password input to function
                            if (nameValidation(name) == true && passwordValidation(password) == true)
                            {
                                addAccount(name, password);     //Calling addAccount function to create an account and store it
                                MessageBox.Show("UserAccount has been successfully created! Please go to Login form", "Succeeded!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtUsername.Text = "";  //Clear textFields
                                txtPassword.Text = "";
                                txtConfirmPwd.Text = "";
                            }
                        } else
                        {
                            MessageBox.Show("Passwords must be the same.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    } else
                    {
                        MessageBox.Show("The length of the password must be between 8 and 16.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                } else
                {
                    MessageBox.Show("The length of the username must be between 6 and 15.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            } else
            {
                MessageBox.Show("Username, Password, ConfirmPassword must be filled in.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        //Navigation to Login form
        private void linklblLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            FrmLogin l = new FrmLogin();    //Initialize login form object
            l.receiveData(accounts);    //Passing list to the login form using a public function
            l.ShowDialog();
        }
        //Show/Hide password
        private void chkBoxShowPwd_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxShowPwd.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;
                txtConfirmPwd.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                txtConfirmPwd.UseSystemPasswordChar= true;
            }
        } 
    }
}
