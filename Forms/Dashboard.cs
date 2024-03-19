using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void ShowForm<T>() where T : Form, new()
        {
            T form = new T();
            form.Show();
        }

        private void ViewStudentToolStripMenuItem(object sender, EventArgs e)
        {
            ShowForm<ViewStudentInfo>();
        }

        private void booksToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close the program?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void addNewBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm<AddBook>();
        }

        private void viewBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm<ViewBook>();
        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm<AddStudent>();
        }

        private void issueBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm<IssueBooks>();
        }

        private void returnBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm<ReturnBook>();
        }

        private void completeBookDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm<CompleteBookDetails>();
        }
    }
}
