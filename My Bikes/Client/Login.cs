using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Mybikes.Bus;
using System.IO;
using Mybikes.Client;

namespace Mybikes
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private static String LoginFilePath = @"../login.txt";

        private void buttonLogin_Click(object sender, EventArgs e)

        {
            bool found = false;
            
            List<Loginpage> loginlist = new List<Loginpage>();
            IFileHandler interface_login;
            interface_login = new FileHandler();
            loginlist = interface_login.ReadFromLoginfile();
            foreach (Loginpage item in loginlist)
            {
                if (textBoxUsername.Text == item.Username && textBoxPasswd.Text == item.Password)
                {
                     found = true;
                }
              }
            if (found )
            {
                MessageBox.Show( "Login Successful");
                Form1 form1 = new Form1();
                this.Hide();
                form1.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter valid username and Password!");

            }


        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {
            bool found = false;
            IValidator interface_UserName = new Validator();
            found = interface_UserName.IsAlphabetLetters(textBoxUsername.Text);

            if (found)
            {
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            }
            else
            {
                errorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                textBoxUsername.Clear();
                textBoxUsername.Focus();
            }
        }

        private void textBoxPasswd_TextChanged(object sender, EventArgs e)
        {
            bool found = false;
            IValidator interface_Password = new Validator();
            found = interface_Password.IsDigit(textBoxPasswd.Text);

            if (found)
            {
                errorProvider2.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            }
            else
            {
                errorProvider2.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                textBoxPasswd.Clear();
                textBoxPasswd.Focus();
            }
        }



        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}


    

