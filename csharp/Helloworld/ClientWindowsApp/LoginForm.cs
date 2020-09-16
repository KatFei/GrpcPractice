using RssClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientWindowsApp
{
    public partial class LoginForm : Form
    {
        private ClientMain client;
        private String username = " ";
        private String authtoken;

        public ClientMain Client { get => client; set => client = value; }
        public string Username { get => username; private set => username = value; }
        public string Authtoken { get => authtoken; private set => authtoken = value; }

        public LoginForm(ClientMain client)
        {
            this.client = client;
            InitializeComponent();
        }

        public LoginForm()
        {
            InitializeComponent();
        }


        private void butLogin_Click(object sender, EventArgs e)
        {
            String user = tbUser.Text;
            if (user != "")
            {
                String pwd = tbPassword.Text;
                //связываемся с сервером
                if (client.Authenticate(user, pwd))
                {
                    this.DialogResult = DialogResult.OK;//возвращаем из формы ok иначе fail ;
                    this.Username = user;
                    this.Close();
                }
                else
                    MessageBox.Show("Incorrent username or password.");
            }
        }

        private void linkLblCreate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String user = tbUser.Text;
            String pwd = tbPassword.Text;
            //связываемся с сервером
            if ((user != "") && (pwd != ""))
            {
                if (client.CreateUser(user, pwd) != null)
                {
                    MessageBox.Show("User created. Click Login button to log into your account.");
                }
            }
            else
                MessageBox.Show("Empty username or password.");
        }
    }
}
