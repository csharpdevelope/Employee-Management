using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_Management
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text == "" ||txtPassword.Text=="")
            {
                MessageBox.Show("Enter Login or Password");
            }
            else if (txtLogin.Text == "Admin"&&txtPassword.Text == "Admin123")
            {
                Home home = new Home();
                home.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Incorrect Login or Password");
            }
        }
 
        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            txtLogin.Text = "";
            txtPassword.Text = "";
        }
    }
}
