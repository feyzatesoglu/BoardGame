using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace BoardGame {
    public partial class Profile : Form {

        static string connectionString = BoardGame.Properties.Settings.Default.BoardgameConnectionString;
        SqlConnection sqlConnection = new SqlConnection(connectionString);

        public Profile() {
            InitializeComponent();
        }
        private void Profile_Load(object sender, EventArgs e) {
            String username = BoardGame.Properties.Settings.Default.UserName;
            this.txtboxUsername.Text = username;

            try {
                if (sqlConnection.State == ConnectionState.Closed) {
                    sqlConnection.Open();
                }

                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Users WHERE username = @username", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@username", txtboxUsername.Text);
                sqlCommand.CommandType = CommandType.Text;
                SqlDataReader rdr = sqlCommand.ExecuteReader();

                while (rdr.Read()) {
                    txtboxNameSurname.Text = rdr["name_surname"].ToString();
                    txtboxPhoneNumber.Text = rdr["phone_number"].ToString();
                    txtboxAddress.Text = rdr["address"].ToString();
                    txtboxCity.Text = rdr["city"].ToString();
                    txtboxCountry.Text = rdr["country"].ToString();
                    txtboxEmail.Text = rdr["email"].ToString();
                }

                rdr.Close();

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }


        }

        /*private void btnBack_Click(object sender, EventArgs e) {
            this.Hide();
            MainGame mainGame = new MainGame();
            mainGame.Show();
        }*/

        private void btnSave_Click(object sender, EventArgs e) {
            string hashedPassword = "";

            try {
                if (sqlConnection.State == ConnectionState.Closed) {
                    sqlConnection.Open();
                }

                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Users WHERE username = @username", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@username", txtboxUsername.Text);
                sqlCommand.CommandType = CommandType.Text;
                SqlDataReader rdr = sqlCommand.ExecuteReader();

                while (rdr.Read()) {
                    hashedPassword = rdr["password"].ToString();
                }

                rdr.Close();
                if (!sha256_hash(this.txtboxPassword.Text).Equals(hashedPassword)) {
                    MessageBox.Show("Password does not match.");
                    return;
                }

                sqlCommand = new SqlCommand("UPDATE Users SET name_surname = @name_surname,phone_number = @phone_number,address = @address,city = @city,country = @country,email = @email WHERE username = @username", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@username", txtboxUsername.Text);
                sqlCommand.Parameters.AddWithValue("@name_surname", txtboxNameSurname.Text);
                sqlCommand.Parameters.AddWithValue("@phone_number", txtboxPhoneNumber.Text);
                sqlCommand.Parameters.AddWithValue("@address", txtboxAddress.Text);
                sqlCommand.Parameters.AddWithValue("@city", txtboxCity.Text);
                sqlCommand.Parameters.AddWithValue("@country", txtboxCountry.Text);
                sqlCommand.Parameters.AddWithValue("@email", txtboxEmail.Text);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                MessageBox.Show("Successfully saved.");
                this.txtboxPassword.Text = "";
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
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
