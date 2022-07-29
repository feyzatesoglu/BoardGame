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
using System.Security.Cryptography;
using System.Xml.XPath;
using System.Data.SqlClient;

namespace BoardGame
{
    public partial class SignUp : Form
    {
        static string connectionString = BoardGame.Properties.Settings.Default.BoardgameConnectionString;
        SqlConnection sqlConnection = new SqlConnection(connectionString);

        public SignUp()
        {
            InitializeComponent();
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if(this.txtUsername.Text == "" && this.txtPassword.Text == "") {
                MessageBox.Show("Username or password cannot be empty.");
                return;
            }
            if(this.txtUsername.Text == "user"|| this.txtUsername.Text == "admin")
            {
                MessageBox.Show("This account name cannot be created.");
                return;
            }

            try {
                if(sqlConnection.State == ConnectionState.Closed) {
                    sqlConnection.Open();
                }

                SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(username) FROM Users WHERE username = @username", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@username", txtUsername.Text);
                sqlCommand.CommandType = CommandType.Text;
                SqlDataReader rdr = sqlCommand.ExecuteReader();

                while (rdr.Read()) {
                    if(rdr.GetInt32(0) >= 1) {
                        MessageBox.Show("There's already such a user.");
                        rdr.Close();
                        return;
                    }
                }

                rdr.Close();

                string registery = "INSERT INTO Users (username,password,name_surname,phone_number,address,city,country,email,best_score,admin) " +
                    "values(@username, @password, @name_surname, @phone_number, @address, @city, @country, @email, @bestscore, @admin)";

                sqlCommand = new SqlCommand(registery, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@username", txtUsername.Text);
                sqlCommand.Parameters.AddWithValue("@password", sha256_hash(this.txtPassword.Text));
                sqlCommand.Parameters.AddWithValue("@name_surname", txtNameSurname.Text);
                sqlCommand.Parameters.AddWithValue("@phone_number", txtPnumber.Text);
                sqlCommand.Parameters.AddWithValue("@address", txtAddress.Text);
                sqlCommand.Parameters.AddWithValue("@city", txtCity.Text);
                sqlCommand.Parameters.AddWithValue("@country", txtCountry.Text);
                sqlCommand.Parameters.AddWithValue("@email", txtMail.Text);
                sqlCommand.Parameters.AddWithValue("@bestscore", "0");
                sqlCommand.Parameters.AddWithValue("@admin", "0");
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Signed up successfully");

            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }

            this.Visible = false;
            LogIn login = new LogIn();
            login.Show();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnSign;
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

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e) {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void btnBack_Click(object sender, EventArgs e) {
            this.Hide();
            LogIn logIn = new LogIn();
            logIn.Show();
        }
    }
}
