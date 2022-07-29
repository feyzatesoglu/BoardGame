using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Security.Cryptography;
using System.Xml.XPath;
using System.Data.SqlClient;


namespace BoardGame
{
    public partial class LogIn : Form
    {
        static string connectionString = BoardGame.Properties.Settings.Default.BoardgameConnectionString;
        bool found = false;
        SqlConnection sqlConnection = new SqlConnection(connectionString);

        public LogIn()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (this.txtUsername.Text == "user"&&this.txtPassword.Text=="user")
            {
                this.Visible = false;
                MainGame mainGame = new MainGame();
                mainGame.Show();
                return;
            }
            if(this.txtUsername.Text == "admin" && this.txtPassword.Text == "admin")
            {
                this.Visible = false;
                ManagerScreen manager = new ManagerScreen();
                manager.Show();
                return;
            }
            try {
                if(sqlConnection.State == ConnectionState.Closed) {
                    sqlConnection.Open();
                }

                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Users WHERE username = @username", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@username", txtUsername.Text);
                sqlCommand.CommandType = CommandType.Text;
                SqlDataReader rdr = sqlCommand.ExecuteReader();

                while (rdr.Read()) {
                    if (rdr["password"].ToString() == sha256_hash(txtPassword.Text)) {
                        if (rdr["admin"].ToString() == "0") {
                            this.Visible = false;
                            MainGame mainGame = new MainGame();
                            mainGame.Show();
                            found = true;
                        } else if (rdr["admin"].ToString() == "1") {
                            this.Visible = false;
                            ManagerScreen manager = new ManagerScreen();
                            manager.Show();
                            found = true;
                        }
                    }

                }

                rdr.Close();

            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
            
            if (found == true)
            {
               BoardGame.Properties.Settings.Default.UserName = txtUsername.Text;
               BoardGame.Properties.Settings.Default.Save();
            }
   
            if (found == false)
            {
                BoardGame.Properties.Settings.Default.UserName = "";
                BoardGame.Properties.Settings.Default.Save();
                MessageBox.Show("User information is not found. Please try again!");
            }
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtUsername.Focus();
        }
        private void LogIn_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnLogin;
            if (Properties.Settings.Default.UserName != string.Empty)
            {
                txtUsername.Text = Properties.Settings.Default.UserName;
            }
        }
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            SignUp signUp = new SignUp();
            signUp.Show();
        }
        private void LogIn_Shown(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }
        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }
        private void chckPassShown_CheckedChanged(object sender, EventArgs e)
        {
            if (chckPassShown.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }


        public static String sha256_hash(String value) {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create()) {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }
    }
}