using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Employee_Management
{
    public partial class Salary : Form
    {
        public Salary()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project Csharp\Employee Management\Employee Management\MyEmployee.mdf;Integrated Security=True;Connect Timeout=30");
        private void fetcstyle()
        {
            if(EmpIdTbl.Text =="")
            {
                MessageBox.Show("Enter Employee ID");
            }
            else
            {
                try
                {
                    string query = "select * from EmployeeTbl where EmployeeId='" + EmpIdTbl.Text + "'";
                    SqlCommand comm = new SqlCommand(query, conn);
                    SqlDataAdapter da = new SqlDataAdapter(comm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        EmpNameTb.Text = dr["EmployeeName"].ToString();
                        EmpPos.Text = dr["EmployeePos"].ToString();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            fetcstyle();
        }

        private void Salary_Load(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
        private void salary()
        {
            int totals;
            if (EmpPos.Text == "Manager")
            {
                totals = 1200;
            }
            else if (EmpPos.Text == "Senior Developer")
            {
                totals = 950;
            }
            else if (EmpPos.Text == "Junior Developer")
            {
                totals = 500;
            }
            else
            {
                totals = 300;
            }
            richTextBox1.Text = "Employee Name: " + EmpNameTb.Text + Environment.NewLine
                + "Employee Position: " + EmpPos.Text + Environment.NewLine
                + "Work Days: " + Empworkday.Text + Environment.NewLine
                + "Totals Summa: " + totals * int.Parse(Empworkday.Text) + "$";
        }
        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            salary();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            if(printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("=========Employee=========", new Font("Open Sans", 18, FontStyle.Regular),
                Brushes.Red, new Point(200));
            e.Graphics.DrawString(richTextBox1.Text, new Font("Open Sans", 18, FontStyle.Regular),
                Brushes.Red, new Point(200));
        }
    }
}
