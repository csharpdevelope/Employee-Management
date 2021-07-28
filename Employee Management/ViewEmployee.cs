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
    public partial class ViewEmployee : Form
    {
        public ViewEmployee()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project Csharp\Employee Management\Employee Management\MyEmployee.mdf;Integrated Security=True;Connect Timeout=30");
        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void framework()
        {
            try
            {
                conn.Open();
                string query = "select * from EmployeeTbl where EmployeeId='" + EmpIdTbl.Text + "'";
                SqlCommand comm = new SqlCommand(query, conn);
                DataTable dt = new DataTable();
                SqlDataAdapter sql = new SqlDataAdapter(comm);
                sql.Fill(dt);
                foreach(DataRow dr in dt.Rows)
                {
                    EmpId.Text = dr["EmployeeId"].ToString();
                    emadd.Text = dr["EmployeeAdd"].ToString();
                    empos.Text = dr["EmployeePos"].ToString();
                    emphone.Text = dr["EmployeePhone"].ToString();
                    emname.Text = dr["EmployeeName"].ToString();
                    emgender.Text = dr["EmployeeGender"].ToString();
                    emeducation.Text = dr["EmployeeEducation"].ToString();
                    emdob.Text = dr["EmployeDOB"].ToString();
                }
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            framework();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Home home = new Home();
            home.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if(printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("===============Employee=============="+Environment.NewLine, new Font("Open Sans", 
                18, FontStyle.Regular),Brushes.Red, new Point(200));
            e.Graphics.DrawString(EmpId.Text + Environment.NewLine, new Font("Open Sans", 18, FontStyle.Regular),
                Brushes.Red, new Point(200));
            e.Graphics.DrawString(emadd.Text + Environment.NewLine, new Font("Open Sans", 18, FontStyle.Regular),
                Brushes.Red, new Point(200));
            e.Graphics.DrawString(empos.Text + Environment.NewLine, new Font("Open Sans", 18, FontStyle.Regular),
                Brushes.Red, new Point(200));
            e.Graphics.DrawString(emphone.Text + Environment.NewLine, new Font("Open Sans", 18, FontStyle.Regular),
                Brushes.Red, new Point(200));
            e.Graphics.DrawString(emname.Text + Environment.NewLine, new Font("Open Sans", 18, FontStyle.Regular),
                Brushes.Red, new Point(200));
            e.Graphics.DrawString(emgender.Text + Environment.NewLine, new Font("Open Sans", 18, FontStyle.Regular),
                Brushes.Red, new Point(200));
            e.Graphics.DrawString(emdob.Text + Environment.NewLine, new Font("Open Sans", 18, FontStyle.Regular),
                Brushes.Red, new Point(200));
            e.Graphics.DrawString(emeducation.Text, new Font("Open Sans", 18, FontStyle.Regular),
                Brushes.Red, new Point(200));
        }
    }
}
