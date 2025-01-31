using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sarasavilibrary
{
    public partial class Home_page : Form
    {
        int mov;
        int movX;
        int movY;
        int movZ;
        public Home_page()
        {
            InitializeComponent();
        }
        
       

        private void dash_btn_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.TopLevel = false;
            panel2.Controls.Clear();
            panel2.Controls.Add(dashboard);
            dashboard.Dock = DockStyle.Fill;
            dashboard.Show();
        }
        private void loan_return_btn_Click_1(object sender, EventArgs e)
        {
            

        }


        private void reservation_btn_Click(object sender, EventArgs e)
        {
            
        }

        private void inquiry_btn_Click(object sender, EventArgs e)
        {
            
        }

        private void book_rej_btn_Click(object sender, EventArgs e)
        {


         

        }

        private void user_rej_btn_Click(object sender, EventArgs e)
        {

            
        }

        

       

        private void logout_btn_Click(object sender, EventArgs e)
        {
            
        }

        private void Home_page_Load_1(object sender, EventArgs e)
        {
            timer1.Start();
            time_lbl.Text = DateTime.Now.ToLongTimeString();
            date_lbl.Text = DateTime.Now.ToLongDateString();
        }
        

        private void user_rej_btn_Click_1(object sender, EventArgs e)
        {
            UserRegistration userRegistration = new UserRegistration();
            userRegistration.TopLevel = false;
            panel2.Controls.Clear();
            panel2.Controls.Add(userRegistration);
            userRegistration.Dock = DockStyle.Fill;
            userRegistration.Show();


        }

        private void logout_btn_Click_1(object sender, EventArgs e)
        {
            Login_page loginPage = new Login_page();
            loginPage.Show();
            this.Close(); // Close the current form (home page)
        }

        private void book_rej_btn_Click_1(object sender, EventArgs e)
        {
            BookRegistration bookregistration = new BookRegistration();
            bookregistration.TopLevel = false;
            panel2.Controls.Clear();
            panel2.Controls.Add(bookregistration);
            bookregistration.Dock = DockStyle.Fill;
            bookregistration.Show();
        }

        private void inquiry_btn_Click_1(object sender, EventArgs e)
        {
            InquiryProcess inquiryprocess = new InquiryProcess();
            inquiryprocess.TopLevel = false;
            panel2.Controls.Clear();
            panel2.Controls.Add(inquiryprocess);
            inquiryprocess.Dock = DockStyle.Fill;
            inquiryprocess.Show();
        }

        private void reservation_btn_Click_1(object sender, EventArgs e)
        {
            ReservationProcess reservationProcess = new ReservationProcess();
            reservationProcess.TopLevel = false;
            panel2.Controls.Clear();
            panel2.Controls.Add(reservationProcess);
            reservationProcess.Dock = DockStyle.Fill;
            reservationProcess.Show();
        }

        private void loan_return_btn_Click(object sender, EventArgs e)
        {
            Loan_ReturnProcess loan_returnprocess = new Loan_ReturnProcess();
            loan_returnprocess.TopLevel = false;
            panel2.Controls.Clear();
            panel2.Controls.Add(loan_returnprocess);
            loan_returnprocess.Dock = DockStyle.Fill;
            loan_returnprocess.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void time_lbl_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time_lbl.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }
    }
}