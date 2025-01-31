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
    
    public partial class Dashboard : Form
    {
        private string connectionString = (@"Data Source=VISHWA_SAMPATH\SQLEXPRESS;Initial Catalog=SarasaviLibraryDatabase;Integrated Security=True");

        public Dashboard()
        {
            InitializeComponent();
            DisplayBookRegistrationData();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }
        private void DisplayBookRegistrationData()
        {
            // Query to select all data from BookRegistration table
            string query = "SELECT * FROM BookRegistration";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    // Create a DataTable to hold the results
                    DataTable dataTable = new DataTable();

                    // Load the data from the query into the DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);

                    // Bind the DataTable to the DataGridView
                    dataGridView1.DataSource = dataTable;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
