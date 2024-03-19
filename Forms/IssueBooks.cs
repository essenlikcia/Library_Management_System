using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
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
    public partial class IssueBooks : Form
    {
        public IssueBooks()
        {
            InitializeComponent();
        }

        private void IssueBooks_Load(object sender, EventArgs e)
        {
            using (var dbConnection = new DbConnectionHelper())
            {
                var con = dbConnection.GetConnection();
                var sqlCommandHelper = new SqlCommandHelper(con);

                con.Open();

                var cmd = sqlCommandHelper.GetCommandWithParameters("select bName from NewBook", new Dictionary<string, object>());

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            comboBoxBooks.Items.Add(dr.GetString(i));
                        }
                    }
                }

                con.Close();
            }
        }

        int count;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtEnrollment.Text != "")
            {
                string ide = txtEnrollment.Text;
                using (var dbConnection = new DbConnectionHelper())
                {
                    var con = dbConnection.GetConnection();
                    try
                    {
                        con.Open();

                        var parameters = new Dictionary<string, object>
                        {
                            { "@enroll", ide }
                        };

                        var sqlCommandHelper = new SqlCommandHelper(con);
                        var cmd = sqlCommandHelper.GetCommandWithParameters("select * from NewStudent where enroll like @enroll", parameters);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        sqlCommandHelper = new SqlCommandHelper(con);
                        cmd = sqlCommandHelper.GetCommandWithParameters("select count(std_enroll) from IRBook where std_enroll = @enroll and book_return_date is NULL", parameters);
                        SqlDataAdapter daa = new SqlDataAdapter(cmd);
                        DataSet dss = new DataSet();
                        daa.Fill(dss);

                        count = int.Parse(dss.Tables[0].Rows[0][0].ToString());
                        if (ds.Tables[0].Rows.Count != 0)
                        {
                            txtName.Text = ds.Tables[0].Rows[0][1].ToString();
                            txtDepartment.Text = ds.Tables[0].Rows[0][3].ToString();
                            txtSemester.Text = ds.Tables[0].Rows[0][4].ToString();
                            txtContact.Text = ds.Tables[0].Rows[0][5].ToString();
                            txtEmail.Text = ds.Tables[0].Rows[0][6].ToString();
                        }
                        else
                        {
                            txtName.Clear();
                            txtDepartment.Clear();
                            txtSemester.Clear();
                            txtContact.Clear();
                            txtEmail.Clear();
                            MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        con.Close();
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception);
                        throw;
                    }
                }
            }
        }

        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                if (comboBoxBooks.SelectedIndex != -1 && count <= 2)
                {
                    string enroll = txtEnrollment.Text;
                    string sname = txtName.Text;
                    string sdep = txtDepartment.Text;
                    string sem = txtSemester.Text;
                    Int64 contact = Int64.Parse(txtContact.Text);
                    string email = txtEmail.Text;
                    string bookname = comboBoxBooks.Text;
                    string bookIssueDate = dateTimePicker.Text;

                    using (var dbConnection = new DbConnectionHelper())
                    {
                        var con = dbConnection.GetConnection();
                        var sqlCommandHelper = new SqlCommandHelper(con);

                        con.Open();

                        var parameters = new Dictionary<string, object>
                        {
                            { "@enroll", enroll },
                            { "@sname", sname },
                            { "@sdep", sdep },
                            { "@sem", sem },
                            { "@contact", contact },
                            { "@email", email },
                            { "@bookname", bookname },
                            { "@bookIssueDate", bookIssueDate }
                        };

                        sqlCommandHelper.ExecuteNonQuery("insert into IRBook(std_enroll, std_name, std_dep, std_sem, std_contact, std_email, book_name, book_issue_date) values (@enroll, @sname, @sdep, @sem, @contact, @email, @bookname, @bookIssueDate)", parameters);

                        con.Close();
                    }

                    MessageBox.Show("Book Issued Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please Select Book Name / This student can't issue more book.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Enter valid student number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtEnrollment_TextChanged(object sender, EventArgs e)
        {
            if (txtEnrollment.Text == "")
            {
                txtName.Clear();
                txtDepartment.Clear();
                txtSemester.Clear();
                txtContact.Clear();
                txtEmail.Clear();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtEnrollment.Clear(); 
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
