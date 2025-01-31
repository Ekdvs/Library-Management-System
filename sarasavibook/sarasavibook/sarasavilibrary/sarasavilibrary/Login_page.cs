using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sarasavilibrary
{
    public partial class Login_page : Form
    {
        private string connectionString = (@"Data Source=VISHWA_SAMPATH\SQLEXPRESS;Initial Catalog=SarasaviLibraryDatabase;Integrated Security=True");

        public Login_page()
        {
            InitializeComponent();
        }
        


        private bool User_Login(string username, string password)
        {
            string query = "SELECT COUNT(*) FROM User_Login WHERE Username = @Username AND Password = @Password";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        connection.Open();

                        int count = (int)command.ExecuteScalar();

                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
                return false;
            }
        }


        private void login_btn_Click(object sender, EventArgs e)
        {

            string username = username_txt.Text.Trim();
            string password = password_txt.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter username and password.");
                return;
            }

            // Check if the entered username and password exist in the User_Login table
            if (User_Login(username, password))
            {
                MessageBox.Show("Login successful!");

                // Create and show the home_page form
                Home_page homePage = new Home_page();
                homePage.Show();

                // Hide the login form
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username or password is incorrect.");
            }

        }

        private void admin_btn_Click(object sender, EventArgs e)
        {
           
        }

        private void username_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void addmin_btn_Click(object sender, EventArgs e)
        {
            string username = username_txt.Text.Trim();
            string password = password_txt.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter username and password.");
                return;
            }

            // Check if the entered username and password exist in the Admin_Login table
            if (CheckAdminLogin(username, password))
            {
                MessageBox.Show("Login successful!");

                // Create and show the home_page form
                Home_page homePage = new Home_page();
                homePage.Show();

                // Hide the login form
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username or password is incorrect.");
            }
       
        }
        private bool CheckAdminLogin(string username, string password)
        {
            string query = "SELECT COUNT(*) FROM Admin_Login WHERE Username = @Username AND Password = @Password";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        connection.Open();

                        int count = (int)command.ExecuteScalar();

                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
                return false;
            }
        }
    }

}
