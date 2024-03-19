using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
    public partial class CompleteBookDetails : Form
    {
        public CompleteBookDetails()
        {
            InitializeComponent();
        }

        private void CompleteBookDetails_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetBookData("select * from IRBook where book_return_date is null");
            dataGridView2.DataSource = GetBookData("select * from IRBook where book_return_date is not null");
        }

        private DataTable GetBookData(string query)
        {
            var dbConnection = new DbConnectionHelper();
            var sqlCommandHelper = new SqlCommandHelper(dbConnection.GetConnection());

            var cmd = sqlCommandHelper.GetCommandWithParameters(query, new Dictionary<string, object>());

            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds.Tables[0];
            }
        }
    }
}
