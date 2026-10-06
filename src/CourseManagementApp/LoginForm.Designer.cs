namespace CourseManagementApp
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox emailBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button registerButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.titleLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.emailBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.registerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Title Label
            this.titleLabel.Text = "Course Management - Login";
            this.titleLabel.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.titleLabel.Location = new System.Drawing.Point(250, 50);
            this.titleLabel.Size = new System.Drawing.Size(300, 30);

            // Email Label
            this.emailLabel.Text = "Email:";
            this.emailLabel.Location = new System.Drawing.Point(200, 120);
            this.emailLabel.Size = new System.Drawing.Size(100, 25);

            // Email TextBox
            this.emailBox.Location = new System.Drawing.Point(300, 120);
            this.emailBox.Size = new System.Drawing.Size(250, 25);

            // Password Label
            this.passwordLabel.Text = "Password:";
            this.passwordLabel.Location = new System.Drawing.Point(200, 160);
            this.passwordLabel.Size = new System.Drawing.Size(100, 25);

            // Password TextBox
            this.passwordBox.Location = new System.Drawing.Point(300, 160);
            this.passwordBox.Size = new System.Drawing.Size(250, 25);
            this.passwordBox.PasswordChar = '*';

            // Login Button
            this.loginButton.Text = "Login";
            this.loginButton.Location = new System.Drawing.Point(300, 210);
            this.loginButton.Size = new System.Drawing.Size(120, 35);
            this.loginButton.BackColor = System.Drawing.Color.LightBlue;
            this.loginButton.Click += new System.EventHandler(this.LoginButton_Click);

            // Register Button
            this.registerButton.Text = "Register";
            this.registerButton.Location = new System.Drawing.Point(430, 210);
            this.registerButton.Size = new System.Drawing.Size(120, 35);
            this.registerButton.BackColor = System.Drawing.Color.LightGreen;
            this.registerButton.Click += new System.EventHandler(this.RegisterButton_Click);

            // Form Settings
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.emailBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.registerButton);
            this.Text = "Login";
            this.ResumeLayout(false);
        }
    }
}
