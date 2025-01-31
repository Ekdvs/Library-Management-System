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
    public partial class InquiryProcess : Form
    {
        private string connectionString = (@"Data Source=VISHWA_SAMPATH\SQLEXPRESS;Initial Catalog=SarasaviLibraryDatabase;Integrated Security=True");

        public InquiryProcess()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedStatus = comboBox1.SelectedItem.ToString();

            // Query to fetch data based on selected borrowing status
            string query = "SELECT BookID, Title, BorrowingStatus, NumOfCopies FROM BookRegistration WHERE BorrowingStatus = @BorrowingStatus";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BorrowingStatus", selectedStatus);

                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Bind data to DataGridView
                    dataGridView1.DataSource = dataTable;
                }
            }
        }

        private void InquiryProcess_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
