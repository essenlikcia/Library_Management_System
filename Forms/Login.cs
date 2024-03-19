using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Library_Management_System.Helpers;

namespace Library_Management_System
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void UsernameText_MouseEnter(object sender, EventArgs e)
        {

        }
        private void UsernameText_MouseClick(object sender, MouseEventArgs e)
        {
            if (UsernameText.Text == "Username")
            {
                UsernameText.Clear();
            }
        }

        private void PasswordText_MouseClick(object sender, MouseEventArgs e)
        {
            if (PasswordText.Text == "Password")
            {
                PasswordText.Clear();
                PasswordText.PasswordChar = '*';
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var dbConnection = new DbConnectionHelper();
                var sqlCommandHelper = new SqlCommandHelper(dbConnection.GetConnection());

                var parameters = new Dictionary<string, object>
                {
                    { "@username", UsernameText.Text },
                    { "@password", PasswordText.Text }
                };

                SqlCommand cmd = sqlCommandHelper.GetCommandWithParameters(
                    "SELECT * FROM LoginTable WHERE username = @username AND pass = @password", parameters);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count != 0)
                {
                    this.Hide();
                    Dashboard dsa = new Dashboard();
                    dsa.Show();
                }
                else
                {
                    MessageBox.Show("Wrong Username or Password", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnSignUp_Click(object sender, EventArgs e)
        {
            var dbConnection = new DbConnectionHelper();
            var sqlCommandHelper = new SqlCommandHelper(dbConnection.GetConnection());

            var parameters = new Dictionary<string, object>
            {
                { "@username", UsernameText.Text },
                { "@password", PasswordText.Text }
            };

            sqlCommandHelper.ExecuteNonQuery("INSERT INTO loginTable (username, pass) VALUES (@username, @password)", parameters);

            MessageBox.Show("Sign Up Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBoxGithub_Click(object sender, EventArgs e)
        {
            var psi = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://github.com/essenlikcia",
                UseShellExecute = true
            };
            System.Diagnostics.Process.Start(psi);
        }
    }
}