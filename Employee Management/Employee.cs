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
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }
        SqlConnection sqlconn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project Csharp\Employee Management\Employee Management\MyEmployee.mdf;Integrated Security=True;Connect Timeout=30");
        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void populate()
        {
            try
            {
                sqlconn.Open();
                string query = "select * from EmployeeTbl";
                SqlDataAdapter comm = new SqlDataAdapter(query, sqlconn);
                SqlCommandBuilder sd = new SqlCommandBuilder(comm);
                DataSet ds = new DataSet();
                comm.Fill(ds);
                EmpGridView.DataSource = ds.Tables[0];
                sqlconn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (EmpAddTb.Text == ""||EmpIdTbl.Text ==""||EmpNameTb.Text ==""||EmpPhone.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    sqlconn.Open();
                    string query = "insert into EmployeeTbl values('" + EmpIdTbl.Text +
                        "','" + EmpNameTb.Text + "','" + EmpAddTb.Text + "','" + EmpPos.Text + "','" + EmpDOB.Value.Date + "','"
                        + EmpPhone.Text + "','" + EmpEducation.Text + "','" + EmpGenTb.Text + "')";
                    SqlCommand sqlcomm = new SqlCommand(query, sqlconn);
                    sqlcomm.ExecuteNonQuery();
                    MessageBox.Show("Employee Successfully Added");
                    sqlconn.Close();
                    populate();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            if (EmpIdTbl.Text == "")
            {
                MessageBox.Show("Enter the Employee Id");
            }
            else
            {
                sqlconn.Open();
                string query = "delete from EmployeeTbl where EmployeeId='" + EmpIdTbl.Text + "'";
                SqlCommand com = new SqlCommand(query, sqlconn);
                com.ExecuteNonQuery();
                MessageBox.Show("Employee Deleted Successfully");
                sqlconn.Close();
                populate();
            }
        }

        private void EmpGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EmpIdTbl.Text = EmpGridView.SelectedRows[0].Cells[0].Value.ToString();
            EmpNameTb.Text = EmpGridView.SelectedRows[0].Cells[1].Value.ToString();
            EmpAddTb.Text = EmpGridView.SelectedRows[0].Cells[2].Value.ToString();
            EmpPos.SelectedItem = EmpGridView.SelectedRows[0].Cells[3].Value.ToString();
            EmpDOB.Text = EmpGridView.SelectedRows[0].Cells[4].Value.ToString();
            EmpPhone.Text = EmpGridView.SelectedRows[0].Cells[5].Value.ToString();
            EmpEducation.SelectedItem = EmpGridView.SelectedRows[0].Cells[6].Value.ToString();
            EmpGenTb.SelectedItem = EmpGridView.SelectedRows[0].Cells[7].Value.ToString();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            try
            {
                sqlconn.Open();
                string query = "update EmployeeTbl set EmployeeName='" + EmpNameTb.Text + "',EmployeeAdd='"
                    + EmpAddTb.Text + "',EmployeePos='" + EmpPos.Text + "',EmployeDOB='"
                    + EmpDOB.Value.Date + "',EmployeePhone='" + EmpPhone.Text + "',EmployeeEducation='"
                    + EmpEducation.Text + "',EmployeeGender='" + EmpGenTb.Text + "' where EmployeeId='"
                    + EmpIdTbl.Text + "'";
                SqlCommand com = new SqlCommand(query, sqlconn);
                com.ExecuteNonQuery();
                MessageBox.Show("Employee information updated successfully");
                sqlconn.Close();
                populate();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            this.Close();
            Home home = new Home();
            home.Show();
        }
    }
}
