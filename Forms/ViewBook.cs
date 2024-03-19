using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Library_Management_System.Helpers;

namespace Library_Management_System
{
    public partial class ViewBook : Form
    {
        public ViewBook()
        {
            InitializeComponent();
        }

        private void ViewBook_Load(object sender, EventArgs e)
        {
            var dbConnection = new DbConnectionHelper();
            var sqlCommandHelper = new SqlCommandHelper(dbConnection.GetConnection());

            SqlCommand cmd = sqlCommandHelper.GetCommandWithParameters("select * from NewBook", new Dictionary<string, object>());

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

        int bid;
        Int64 rowid;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
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

                    SqlCommand cmd = sqlCommandHelper.GetCommandWithParameters("select * from NewBook where bid = @bid", parameters);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

                    txtBName.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtAuthor.Text = ds.Tables[0].Rows[0][2].ToString();
                    txtPublication.Text = ds.Tables[0].Rows[0][3].ToString();
                    txtPDate.Text = ds.Tables[0].Rows[0][4].ToString();
                    txtPrice.Text = ds.Tables[0].Rows[0][5].ToString();
                    txtQuan.Text = ds.Tables[0].Rows[0][6].ToString();
                }
            }
            catch (Exception exception)
            {
                string gridErr = "Please select valid area(bid, bName etc.)";
                MessageBox.Show(gridErr);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //panel2.Visible=false;
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var dbConnection = new DbConnectionHelper();
            var sqlCommandHelper = new SqlCommandHelper(dbConnection.GetConnection());

            SqlCommand cmd;
            if (txtBookName.Text != "")
            {
                var parameters = new Dictionary<string, object>
                {
                    { "@bookName", txtBookName.Text + "%" }
                };

                cmd = sqlCommandHelper.GetCommandWithParameters("select * from NewBook where bName LIKE @bookName", parameters);
            }
            else
            {
                cmd = sqlCommandHelper.GetCommandWithParameters("select * from NewBook", new Dictionary<string, object>());
            }

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtBookName.Clear();
            //panel2.Visible = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be updated.", "Update", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string bname = txtBookName.Text;
                string bauthor = txtAuthor.Text;
                string publication = txtPublication.Text;
                string pdate = txtPDate.Text;
                Int64 price = Int64.Parse(txtPrice.Text);
                Int64 quantity = Int64.Parse(txtQuan.Text);

                using (var dbConnection = new DbConnectionHelper())
                {
                    var con = dbConnection.GetConnection();
                    var sqlCommandHelper = new SqlCommandHelper(con);
                    con.Open();

                    var parameters = new Dictionary<string, object>
                    {
                        { "@bname", bname },
                        { "@bauthor", bauthor },
                        { "@publication", publication },
                        { "@pdate", pdate },
                        { "@price", price },
                        { "@quantity", quantity },
                        { "@rowid", rowid }
                    };

                    sqlCommandHelper.ExecuteNonQuery(
                        "update NewBook set bName = @bname, bAuthor = @bauthor, bPubl = @publication, bPDate = @pdate, bPrice = @price, bQuan = @quantity where bid = @rowid",
                        parameters);
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

                    sqlCommandHelper.ExecuteNonQuery("delete from NewBook where bid = @rowid", parameters);
                    con.Close();
                    ViewBook_Load(this, EventArgs.Empty);
                }
            }
        }
    }
}
