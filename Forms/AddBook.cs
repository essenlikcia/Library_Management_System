using Library_Management_System.Helpers;

namespace Library_Management_System
{
    public partial class AddBook : Form
    {
        public AddBook()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtBookName.Text != "" && txtAuthor.Text != "" && txtPublication.Text != "" && txtPrice.Text != "" && txtQuantity.Text != "")
            {
                string bname = txtBookName.Text;
                string bauthor = txtAuthor.Text;
                string publication = txtPublication.Text;
                string pdate = dateTimePicker1.Text;
                Double price;

                try
                {
                    price = Double.Parse(txtPrice.Text);
                }
                catch (Exception exception)
                {
                    string currError = "Please do not write currency format";
                    Console.WriteLine(currError);
                    throw;
                }
                Int64 quan = Int64.Parse(txtQuantity.Text);


                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@bname", bname },
                    { "@bauthor", bauthor },
                    { "@publication", publication },
                    { "@pdate", pdate },
                    { "@price", price },
                    { "@quan", quan }
                };

                try
                {
                    using (var dbConnection = new DbConnectionHelper())
                    {
                        var con = dbConnection.GetConnection();
                        var cmdHelper = new SqlCommandHelper(con);

                        con.Open();
                        cmdHelper.ExecuteNonQuery("insert into NewBook (bName, bAuthor, bPubl, bPDate, bPrice,bQuan) values (@bname, @bauthor, @publication, @pdate, @price, @quan)", parameters);
                        con.Close();
                    }

                    MessageBox.Show("Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBookName.Clear();
                    txtAuthor.Clear();
                    txtPublication.Clear();
                    txtPrice.Clear();
                    txtQuantity.Clear();
                }
                catch (Exception ex)
                {
                    // Log exception and handle it
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please fill every field.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
