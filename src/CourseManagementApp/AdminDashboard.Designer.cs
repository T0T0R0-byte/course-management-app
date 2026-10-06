namespace CourseManagementApp
{
    partial class AdminDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button manageUsersButton;
        private System.Windows.Forms.Button manageCoursesButton;
        private System.Windows.Forms.Button viewReportsButton;
        private System.Windows.Forms.Button logoutButton;

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
            this.manageUsersButton = new System.Windows.Forms.Button();
            this.manageCoursesButton = new System.Windows.Forms.Button();
            this.viewReportsButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Title Label
            this.titleLabel.Text = "Admin Dashboard";
            this.titleLabel.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.titleLabel.Location = new System.Drawing.Point(300, 30);
            this.titleLabel.Size = new System.Drawing.Size(250, 30);

            // Manage Users Button
            this.manageUsersButton.Text = "Manage Users";
            this.manageUsersButton.Location = new System.Drawing.Point(300, 100);
            this.manageUsersButton.Size = new System.Drawing.Size(200, 40);
            this.manageUsersButton.Click += new System.EventHandler(this.ManageUsersButton_Click);

            // Manage Courses Button
            this.manageCoursesButton.Text = "Manage Courses";
            this.manageCoursesButton.Location = new System.Drawing.Point(300, 160);
            this.manageCoursesButton.Size = new System.Drawing.Size(200, 40);
            this.manageCoursesButton.Click += new System.EventHandler(this.ManageCoursesButton_Click);

            // View Reports Button
            this.viewReportsButton.Text = "View Reports";
            this.viewReportsButton.Location = new System.Drawing.Point(300, 220);
            this.viewReportsButton.Size = new System.Drawing.Size(200, 40);
            this.viewReportsButton.Click += new System.EventHandler(this.ViewReportsButton_Click);

            // Logout Button
            this.logoutButton.Text = "Logout";
            this.logoutButton.Location = new System.Drawing.Point(300, 280);
            this.logoutButton.Size = new System.Drawing.Size(200, 40);
            this.logoutButton.Click += new System.EventHandler(this.LogoutButton_Click);

            // Form Settings
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.manageUsersButton);
            this.Controls.Add(this.manageCoursesButton);
            this.Controls.Add(this.viewReportsButton);
            this.Controls.Add(this.logoutButton);
            this.Text = "Admin Dashboard";
            this.ResumeLayout(false);
        }
    }
}
