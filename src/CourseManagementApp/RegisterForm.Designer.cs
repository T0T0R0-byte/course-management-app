namespace CourseManagementApp
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.TextBox firstNameBox;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.TextBox lastNameBox;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox emailBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox passwordBox;
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
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.firstNameBox = new System.Windows.Forms.TextBox();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.lastNameBox = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.emailBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.registerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Title Label
            this.titleLabel.Text = "Register for Course Management";
            this.titleLabel.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.titleLabel.Location = new System.Drawing.Point(200, 30);
            this.titleLabel.Size = new System.Drawing.Size(400, 30);

            // First Name
            this.firstNameLabel.Text = "First Name:";
            this.firstNameLabel.Location = new System.Drawing.Point(200, 80);
            this.firstNameBox.Location = new System.Drawing.Point(300, 80);
            this.firstNameBox.Size = new System.Drawing.Size(250, 25);

            // Last Name
            this.lastNameLabel.Text = "Last Name:";
            this.lastNameLabel.Location = new System.Drawing.Point(200, 120);
            this.lastNameBox.Location = new System.Drawing.Point(300, 120);
            this.lastNameBox.Size = new System.Drawing.Size(250, 25);

            // Email
            this.emailLabel.Text = "Email:";
            this.emailLabel.Location = new System.Drawing.Point(200, 160);
            this.emailBox.Location = new System.Drawing.Point(300, 160);
            this.emailBox.Size = new System.Drawing.Size(250, 25);

            // Password
            this.passwordLabel.Text = "Password:";
            this.passwordLabel.Location = new System.Drawing.Point(200, 200);
            this.passwordBox.Location = new System.Drawing.Point(300, 200);
            this.passwordBox.Size = new System.Drawing.Size(250, 25);
            this.passwordBox.PasswordChar = '*';

            // Register Button
            this.registerButton.Text = "Register";
            this.registerButton.Location = new System.Drawing.Point(300, 250);
            this.registerButton.Size = new System.Drawing.Size(150, 35);
            this.registerButton.BackColor = System.Drawing.Color.LightGreen;
            this.registerButton.Click += new System.EventHandler(this.RegisterButton_Click);

            // Form Settings
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.firstNameLabel);
            this.Controls.Add(this.firstNameBox);
            this.Controls.Add(this.lastNameLabel);
            this.Controls.Add(this.lastNameBox);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.emailBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.registerButton);
            this.Text = "Register";
            this.ResumeLayout(false);
        }
    }
}
