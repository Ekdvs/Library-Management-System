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
    public partial class Loan_ReturnProcess : Form
    {
        private string connectionString = (@"Data Source=VISHWA_SAMPATH\SQLEXPRESS;Initial Catalog=SarasaviLibraryDatabase;Integrated Security=True");

        public Loan_ReturnProcess()
        {
            InitializeComponent();
            DisplayUnavailableBooks();
        }

        private void username_txt_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void submit_btn_Click(object sender, EventArgs e)
        {
            string username = username_txt.Text;
            string bookID = bookid_txt.Text;
            DateTime returnDate = dateTimePicker1.Value;
            DateTime currentDate = DateTime.Now;

            // Calculate delay in days
            int delayDays = (currentDate - returnDate).Days;

            if (delayDays > 0)
            {
                MessageBox.Show($"The book is overdue by {delayDays} days. Please return it as soon as possible.", "Return Overdue", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("The book is returned on time.", "Return On Time", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Remove the user's reservation and update book availability
            RemoveUserReservation(username);
            UpdateBookAvailability(bookID);

            // Clear input fields after processing
            username_txt.Clear();
            bookid_txt.Clear();
            dateTimePicker1.Value = DateTime.Now;
            bookid_txt.Enabled = true;  // Re-enable editing
        }

        

        private void RemoveUserReservation(string username)
        {
            string query = "DELETE FROM User_Reservation WHERE Username = @Username";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private void UpdateBookAvailability(string bookID)
        {
            // Query to update book availability
            string query = @"UPDATE BookRegistration 
                             SET NumOfCopies = NumOfCopies + 1, 
                                 BorrowingStatus = CASE 
                                   WHEN NumOfCopies + 1 > 0 THEN 'Available' 
                                   ELSE 'Not available' 
                                 END 
                             WHERE BookID = @BookID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BookID", bookID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }


        }
        private void DisplayUnavailableBooks()
        {
            string query = "SELECT * FROM BookRegistration WHERE BorrowingStatus != 'Available'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    DataTable dataTable = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);

                    dataGridView2.DataSource = dataTable;
                }
            }
        }
        private void CheckReturnDates()
        {
            DateTime currentDate = DateTime.Now;

            string query = "SELECT Username, BookID, DATEDIFF(day, ReturnDate, GETDATE()) AS DaysOverdue " +
                           "FROM User_Reservation " +
                           "WHERE ReturnDate < GETDATE()";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    DataTable dataTable = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
            }
        }

        private void find_btn_Click(object sender, EventArgs e)
        {
            CheckReturnDates();
        }

        private void Loan_ReturnProcess_Load(object sender, EventArgs e)
        {

        }

        // Display reserved books when username is entered

        private void username_txt_TextChanged_1(object sender, EventArgs e)
        {
            string username = username_txt.Text;

            // Retrieve BookID for the entered username
            string query = "SELECT BookID FROM User_Reservation WHERE Username = @Username";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        // Fill the bookid_txt with the found BookID
                        bookid_txt.Text = result.ToString();
                        bookid_txt.Enabled = false;  // Disable editing
                    }
                    else
                    {
                        // Enable editing and clear field if no BookID found
                        bookid_txt.Enabled = true;
                        bookid_txt.Clear();
                    }
                }
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
