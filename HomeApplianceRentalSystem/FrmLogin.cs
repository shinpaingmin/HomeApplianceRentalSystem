using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeApplianceRentalSystem
{
    public partial class FrmLogin : Form
    {
        List<UserAccounts> newAccounts; //Creating a list to receive passed list from the registration form
        List<UserAccounts> adminAccounts;   //Creating a list to store admin accounts
        // Failed login attempts
        private int loginFailed = 0;
        bool foundAccount = false;
        public FrmLogin()
        {
            InitializeComponent();
        }
        // Create a Function to add admin accounts 
        private void addAccount(string name, string pass)
        {
            UserAccounts adminAcc;  //initialize object for admin account
            adminAcc = new UserAccounts(name, pass);    //Adding values from parameter
            adminAccounts.Add(adminAcc);    //Adding object to list that will store all admin accounts
        }
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            //Add adminAccounts
            adminAccounts = new List<UserAccounts>();   //Creating list to store admin accounts
            addAccount("Mike123", "Mike@123");  //full-populated object for the first admin
            addAccount("Jason222", "#Jason222");    //fully-populated object for the second admin
            Console.WriteLine("There is/are " + adminAccounts.Count + " object/s in the adminAccounts list");     //for testing
        }
        //Function to receive list from the registration form to the login form
        public void receiveData(List<UserAccounts> receiver)
        {
            //Error Handler for nullReferenceException
            try
            {
                newAccounts = receiver;         //List is received 
                Console.WriteLine("There is/are " + newAccounts.Count + " object/s in userAccounts the list");  //for testing 
            }
            catch(Exception ex)
            {
                MessageBox.Show("No account is in the list");
            }
        }
        // Show/Hide password
        private void chkBoxShowPwd_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxShowPwd.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }
        //Navigate to the registration form for those who haven't registered yet
        private void linklblRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            FrmRegistration r = new FrmRegistration();  // Initialized registration form
            r.Show();
        }
        
        private void cmdLogin_Click(object sender, EventArgs e)
        {
            String username = txtUsername.Text.ToString();
            String password = txtPassword.Text.ToString();
            if (loginFailed == 5)
            {
                MessageBox.Show("Exceeded login attempts. The application will be closed and try again later.", "Failed Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();     //When login failed exceeded 5 times, application will be closed.
            }
            
            //Check null
            if (username == "" && password == "")
            {
                MessageBox.Show("Username and Password fields must be filled in.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loginFailed += 1;
            }
            
            //Searching and validation for admin accounts
            else if (checkBox1.Checked == true)
            {   
                for (int i = 0; i < adminAccounts.Count; i++)
                {

                    if (username == adminAccounts[i].Name && password == adminAccounts[i].Password)
                    {
                        frmAdminDashboard a = new frmAdminDashboard();
                        a.ShowDialog();
                        this.Hide();
                        foundAccount= true;
                    }
                }
                if(!foundAccount)
                {
                    MessageBox.Show("No such account is found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loginFailed+= 1;
                }
            } 
            //Searching and validation for customer accounts
            else if (checkBox2.Checked == true)
            {
                try // To catch nullReferenceException, use try-catch block
                {
                    for (int i = 0; i < newAccounts.Count; i++)
                    {
                        if (username == newAccounts[i].Name && password == newAccounts[i].Password)
                        {
                            HomeApplianceRentalApp h = new HomeApplianceRentalApp();
                            h.ShowDialog();
                            this.Hide();
                            foundAccount= true;
                        }
                    }
                    if (!foundAccount)
                    {
                        MessageBox.Show("No such account is found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        loginFailed+= 1;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
            //if no checkbox is true
            if (checkBox1.Checked == false && checkBox2.Checked == false)
            {
                MessageBox.Show("Please select Admin or Normal User", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }    
    }
}
