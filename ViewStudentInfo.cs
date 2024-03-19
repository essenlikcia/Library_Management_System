using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library_Management_System.Helpers;

namespace Library_Management_System
{
    public partial class ViewStudentInfo : Form
    {
        public ViewStudentInfo()
        {
            InitializeComponent();
        }

        private void txtSearchEnrollment_TextChanged(object sender, EventArgs e)
        {
            var dbConnection = new DbConnectionHelper();
            var sqlCommandHelper = new SqlCommandHelper(dbConnection.GetConnection());

            SqlCommand cmd;
            if (txtSearchEnrollment.Text != "")
            {
                var parameters = new Dictionary<string, object>
                {
                    { "@enroll", txtSearchEnrollment.Text + "%" }
                };

                cmd = sqlCommandHelper.GetCommandWithParameters("select * from NewStudent where enroll like @enroll", parameters);
            }
            else
            {
                cmd = sqlCommandHelper.GetCommandWithParameters("select * from NewStudent", new Dictionary<string, object>());
            }

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void ViewStudentInfo_Load(object sender, EventArgs e)
        {
            var dbConnection = new DbConnectionHelper();
            var sqlCommandHelper = new SqlCommandHelper(dbConnection.GetConnection());

            SqlCommand cmd = sqlCommandHelper.GetCommandWithParameters("select * from NewStudent", new Dictionary<string, object>());

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

        int bid;
        Int64 rowid;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

                var dbConnection = new DbConnectionHelper();
                var sqlCommandHelper = new SqlCommandHelper(dbConnection.GetConnection());

                var parameters = new Dictionary<string, object>
                {
                    { "@bid", bid }
                };

                SqlCommand cmd = sqlCommandHelper.GetCommandWithParameters("select * from NewStudent where stuid = @bid", parameters);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

                txtStudentName.Text = ds.Tables[0].Rows[0][1].ToString();
                txtEnrollment.Text = ds.Tables[0].Rows[0][2].ToString();
                txtDepartment.Text = ds.Tables[0].Rows[0][3].ToString();
                txtSemester.Text = ds.Tables[0].Rows[0][4].ToString();
                txtContact.Text = ds.Tables[0].Rows[0][5].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0][6].ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be updated.", "Update", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string studentname = txtStudentName.Text;
                string enrollment = txtEnrollment.Text;
                string department = txtDepartment.Text;
                string semester = txtSemester.Text;
                Int64 contact = Int64.Parse(txtContact.Text);
                string email = txtEmail.Text;

                using (var dbConnection = new DbConnectionHelper())
                {
                    var con = dbConnection.GetConnection();
                    var sqlCommandHelper = new SqlCommandHelper(con);
                    con.Open();

                    var parameters = new Dictionary<string, object>
                    {
                        { "@studentname", studentname },
                        { "@enrollment", enrollment },
                        { "@department", department },
                        { "@semester", semester },
                        { "@contact", contact },
                        { "@email", email },
                        { "@rowid", rowid }
                    };

                    sqlCommandHelper.ExecuteNonQuery(
                        "update NewStudent set sname = @studentname, enroll = @enrollment, dep = @department, sem = @semester, contact = @contact, email = @email where stuid = @rowid",
                        parameters);

                    ViewStudentInfo_Load(this, null);
                    con.Close();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be deleted.", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                using (var dbConnection = new DbConnectionHelper())
                {
                    var con = dbConnection.GetConnection();
                    var sqlCommandHelper = new SqlCommandHelper(con);
                    con.Open();

                    var parameters = new Dictionary<string, object>
                    {
                        { "@rowid", rowid }
                    };

                    sqlCommandHelper.ExecuteNonQuery("Delete from NewStudent where stuid = @rowid", parameters);

                    ViewStudentInfo_Load(this, null);
                    con.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
