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
using Library_Management_System.Helpers;

namespace Library_Management_System
{
    public partial class ReturnBook : Form
    {
        public ReturnBook()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtEnterEnrollment.Text != "")
            {
                string ide = txtEnterEnrollment.Text;
                using (var dbConnection = new DbConnectionHelper())
                {
                    var con = dbConnection.GetConnection();
                    var sqlCommandHelper = new SqlCommandHelper(con);
                    con.Open();

                    var parameters = new Dictionary<string, object>
                    {
                        { "@enroll", ide }
                    };

                    SqlCommand cmd = sqlCommandHelper.GetCommandWithParameters("select * from IRBook where std_enroll = @enroll and book_return_date IS NULL", parameters);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        MessageBox.Show("Invalid id / No book issued", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    con.Close();
                }
            }
        }
        private void ReturnBook_Load(object sender, EventArgs e)
        {
            txtEnterEnrollment.Clear();
        }

        string bname;
        string bdate;
        Int64 rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                rowid = Int64.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                bname = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                bdate = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            }
            txtBookName.Text = bname;
            txtBookIssueDate.Text = bdate;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (txtEnterEnrollment.Text != "")
            {
                string ide = txtEnterEnrollment.Text;
                using (var dbConnection = new DbConnectionHelper())
                {
                    var con = dbConnection.GetConnection();
                    var sqlCommandHelper = new SqlCommandHelper(con);
                    con.Open();

                    var parameters = new Dictionary<string, object>
                    {
                        { "@returnDate", dateTimePicker1.Text },
                        { "@enroll", txtEnterEnrollment.Text },
                        { "@rowid", rowid }
                    };

                    sqlCommandHelper.ExecuteNonQuery("update IRBook set book_return_date = @returnDate where std_enroll = @enroll and id = @rowid", parameters);

                    MessageBox.Show("Book is returned.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReturnBook_Load(this, null);

                    con.Close();
                }
            }
        }

        private void txtEnterEnrollment_TextChanged(object sender, EventArgs e)
        {
            if (txtEnterEnrollment.Text == "")
            {
                dataGridView1.DataSource = null;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtEnterEnrollment.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtEnterEnrollment.Clear(); 
        }
    }
}
