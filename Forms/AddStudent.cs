using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Library_Management_System.Helpers;

namespace Library_Management_System
{
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtEnrollment.Clear();
            txtDepartment.Clear();
            txtSemester.Clear();
            txtContact.Clear();
            txtEmail.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                string enroll = txtEnrollment.Text;
                string department = txtDepartment.Text;
                string semester = txtSemester.Text;
                long mobile = Int64.Parse(txtContact.Text);
                string email = txtEmail.Text;

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@Name", name },
                    { "@Enroll", enroll },
                    { "@Dep", department },
                    { "@Sem", semester },
                    { "@Mobile", mobile },
                    { "@Email", email }
                };

                using (var dbConnection = new DbConnectionHelper())
                {
                    var con = dbConnection.GetConnection();
                    var cmdHelper = new SqlCommandHelper(con);

                    con.Open();
                    cmdHelper.ExecuteNonQuery("INSERT INTO NewStudent (sname, enroll, dep, sem, contact, email) VALUES (@Name, @Enroll, @Dep, @Sem, @Mobile, @Email)", parameters);
                    con.Close();
                }

                MessageBox.Show("Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
