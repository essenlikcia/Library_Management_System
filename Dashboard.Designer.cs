namespace Library_Management_System
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            contextMenuStrip1 = new ContextMenuStrip(components);
            menuStrip1 = new MenuStrip();
            booksToolStripMenuItem = new ToolStripMenuItem();
            addNewBookkToolStripMenuItem = new ToolStripMenuItem();
            viewBooksToolStripMenuItem = new ToolStripMenuItem();
            studentToolStripMenuItem = new ToolStripMenuItem();
            addStudentToolStripMenuItem = new ToolStripMenuItem();
            viewStudentToolStripMenuItem = new ToolStripMenuItem();
            issueBookToolStripMenuItem = new ToolStripMenuItem();
            returnBookToolStripMenuItem = new ToolStripMenuItem();
            completeBookDetailsToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // menuStrip1
            // 
            menuStrip1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            menuStrip1.BackColor = Color.DodgerBlue;
            menuStrip1.Dock = DockStyle.None;
            menuStrip1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            menuStrip1.Items.AddRange(new ToolStripItem[] { booksToolStripMenuItem, studentToolStripMenuItem, issueBookToolStripMenuItem, returnBookToolStripMenuItem, completeBookDetailsToolStripMenuItem, exitToolStripMenuItem });
            menuStrip1.Location = new Point(9, 216);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(855, 64);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // booksToolStripMenuItem
            // 
            booksToolStripMenuItem.BackColor = Color.DodgerBlue;
            booksToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addNewBookkToolStripMenuItem, viewBooksToolStripMenuItem });
            booksToolStripMenuItem.Image = (Image)resources.GetObject("booksToolStripMenuItem.Image");
            booksToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            booksToolStripMenuItem.Name = "booksToolStripMenuItem";
            booksToolStripMenuItem.Size = new Size(109, 60);
            booksToolStripMenuItem.Text = "Books";
            booksToolStripMenuItem.Click += booksToolStripMenuItem_Click;
            // 
            // addNewBookkToolStripMenuItem
            // 
            addNewBookkToolStripMenuItem.Image = (Image)resources.GetObject("addNewBookkToolStripMenuItem.Image");
            addNewBookkToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            addNewBookkToolStripMenuItem.Name = "addNewBookkToolStripMenuItem";
            addNewBookkToolStripMenuItem.Size = new Size(195, 42);
            addNewBookkToolStripMenuItem.Text = "Add new book";
            addNewBookkToolStripMenuItem.Click += addNewBookToolStripMenuItem_Click;
            // 
            // viewBooksToolStripMenuItem
            // 
            viewBooksToolStripMenuItem.Image = (Image)resources.GetObject("viewBooksToolStripMenuItem.Image");
            viewBooksToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            viewBooksToolStripMenuItem.Name = "viewBooksToolStripMenuItem";
            viewBooksToolStripMenuItem.Size = new Size(195, 42);
            viewBooksToolStripMenuItem.Text = "View books";
            viewBooksToolStripMenuItem.Click += viewBooksToolStripMenuItem_Click;
            // 
            // studentToolStripMenuItem
            // 
            studentToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addStudentToolStripMenuItem, viewStudentToolStripMenuItem });
            studentToolStripMenuItem.Image = (Image)resources.GetObject("studentToolStripMenuItem.Image");
            studentToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            studentToolStripMenuItem.Name = "studentToolStripMenuItem";
            studentToolStripMenuItem.Size = new Size(124, 60);
            studentToolStripMenuItem.Text = "Student ";
            // 
            // addStudentToolStripMenuItem
            // 
            addStudentToolStripMenuItem.Image = (Image)resources.GetObject("addStudentToolStripMenuItem.Image");
            addStudentToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            addStudentToolStripMenuItem.Name = "addStudentToolStripMenuItem";
            addStudentToolStripMenuItem.Size = new Size(213, 42);
            addStudentToolStripMenuItem.Text = "Add student";
            addStudentToolStripMenuItem.Click += addStudentToolStripMenuItem_Click;
            // 
            // viewStudentToolStripMenuItem
            // 
            viewStudentToolStripMenuItem.Image = (Image)resources.GetObject("viewStudentToolStripMenuItem.Image");
            viewStudentToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            viewStudentToolStripMenuItem.Name = "viewStudentToolStripMenuItem";
            viewStudentToolStripMenuItem.Size = new Size(213, 42);
            viewStudentToolStripMenuItem.Text = "View student info";
            viewStudentToolStripMenuItem.Click += ViewStudentToolStripMenuItem;
            // 
            // issueBookToolStripMenuItem
            // 
            issueBookToolStripMenuItem.Image = (Image)resources.GetObject("issueBookToolStripMenuItem.Image");
            issueBookToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            issueBookToolStripMenuItem.Name = "issueBookToolStripMenuItem";
            issueBookToolStripMenuItem.Size = new Size(145, 60);
            issueBookToolStripMenuItem.Text = "Issue books";
            issueBookToolStripMenuItem.Click += issueBookToolStripMenuItem_Click;
            // 
            // returnBookToolStripMenuItem
            // 
            returnBookToolStripMenuItem.Image = (Image)resources.GetObject("returnBookToolStripMenuItem.Image");
            returnBookToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            returnBookToolStripMenuItem.Name = "returnBookToolStripMenuItem";
            returnBookToolStripMenuItem.Size = new Size(150, 60);
            returnBookToolStripMenuItem.Text = "Return Book";
            returnBookToolStripMenuItem.Click += returnBookToolStripMenuItem_Click;
            // 
            // completeBookDetailsToolStripMenuItem
            // 
            completeBookDetailsToolStripMenuItem.Image = (Image)resources.GetObject("completeBookDetailsToolStripMenuItem.Image");
            completeBookDetailsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            completeBookDetailsToolStripMenuItem.Name = "completeBookDetailsToolStripMenuItem";
            completeBookDetailsToolStripMenuItem.Size = new Size(218, 60);
            completeBookDetailsToolStripMenuItem.Text = "Complete book details";
            completeBookDetailsToolStripMenuItem.Click += completeBookDetailsToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Image = (Image)resources.GetObject("exitToolStripMenuItem.Image");
            exitToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(101, 60);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(874, 527);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard";
            Load += Dashboard_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ContextMenuStrip contextMenuStrip1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem booksToolStripMenuItem;
        private ToolStripMenuItem addNewBookkToolStripMenuItem;
        private ToolStripMenuItem viewBooksToolStripMenuItem;
        private ToolStripMenuItem studentToolStripMenuItem;
        private ToolStripMenuItem addStudentToolStripMenuItem;
        private ToolStripMenuItem viewStudentToolStripMenuItem;
        private ToolStripMenuItem issueBookToolStripMenuItem;
        private ToolStripMenuItem returnBookToolStripMenuItem;
        private ToolStripMenuItem completeBookDetailsToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
    }
}