namespace Library_Management_System
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            UsernameText = new TextBox();
            PasswordText = new TextBox();
            btnLogin = new Button();
            btnSignUp = new Button();
            pictureBoxGithub = new PictureBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGithub).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // UsernameText
            // 
            UsernameText.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            UsernameText.Location = new Point(109, 216);
            UsernameText.Name = "UsernameText";
            UsernameText.Size = new Size(163, 23);
            UsernameText.TabIndex = 0;
            UsernameText.Text = "Username";
            UsernameText.MouseClick += UsernameText_MouseClick;
            UsernameText.TextChanged += textBox1_TextChanged;
            UsernameText.MouseEnter += UsernameText_MouseEnter;
            // 
            // PasswordText
            // 
            PasswordText.Location = new Point(109, 259);
            PasswordText.Name = "PasswordText";
            PasswordText.Size = new Size(163, 23);
            PasswordText.TabIndex = 1;
            PasswordText.Text = "Password";
            PasswordText.MouseClick += PasswordText_MouseClick;
            PasswordText.TextChanged += textBox2_TextChanged;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.ButtonHighlight;
            btnLogin.Location = new Point(152, 306);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 23);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnSignUp
            // 
            btnSignUp.Location = new Point(152, 344);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(75, 23);
            btnSignUp.TabIndex = 3;
            btnSignUp.Text = "Sign up";
            btnSignUp.UseVisualStyleBackColor = true;
            btnSignUp.Click += btnSignUp_Click;
            // 
            // pictureBoxGithub
            // 
            pictureBoxGithub.Image = (Image)resources.GetObject("pictureBoxGithub.Image");
            pictureBoxGithub.Location = new Point(308, 385);
            pictureBoxGithub.Name = "pictureBoxGithub";
            pictureBoxGithub.Size = new Size(64, 64);
            pictureBoxGithub.TabIndex = 4;
            pictureBoxGithub.TabStop = false;
            pictureBoxGithub.Click += pictureBoxGithub_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(133, 69);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(118, 132);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DodgerBlue;
            ClientSize = new Size(384, 461);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBoxGithub);
            Controls.Add(btnSignUp);
            Controls.Add(btnLogin);
            Controls.Add(PasswordText);
            Controls.Add(UsernameText);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxGithub).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox UsernameText;
        private TextBox PasswordText;
        private Button btnLogin;
        private Button btnSignUp;
        private PictureBox pictureBoxGithub;
        private PictureBox pictureBox1;
    }
}