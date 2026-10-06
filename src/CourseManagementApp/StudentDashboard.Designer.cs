namespace CourseManagementApp
{
    partial class StudentDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button viewAvailableCoursesButton;
        private System.Windows.Forms.Button viewEnrolledCoursesButton;
        private System.Windows.Forms.Button viewGradesButton;
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
            this.viewAvailableCoursesButton = new System.Windows.Forms.Button();
            this.viewEnrolledCoursesButton = new System.Windows.Forms.Button();
            this.viewGradesButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Title Label
            this.titleLabel.Text = "Student Dashboard";
            this.titleLabel.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.titleLabel.Location = new System.Drawing.Point(300, 30);
            this.titleLabel.Size = new System.Drawing.Size(250, 30);

            // View Available Courses Button
            this.viewAvailableCoursesButton.Text = "View Available Courses";
            this.viewAvailableCoursesButton.Location = new System.Drawing.Point(300, 80);
            this.viewAvailableCoursesButton.Size = new System.Drawing.Size(200, 40);
            this.viewAvailableCoursesButton.Click += new System.EventHandler(this.ViewAvailableCoursesButton_Click);

            // View Enrolled Courses Button
            this.viewEnrolledCoursesButton.Text = "View Enrolled Courses";
            this.viewEnrolledCoursesButton.Location = new System.Drawing.Point(300, 130);
            this.viewEnrolledCoursesButton.Size = new System.Drawing.Size(200, 40);
            this.viewEnrolledCoursesButton.Click += new System.EventHandler(this.ViewEnrolledCoursesButton_Click);

            // View Grades Button
            this.viewGradesButton.Text = "View Grades";
            this.viewGradesButton.Location = new System.Drawing.Point(300, 180);
            this.viewGradesButton.Size = new System.Drawing.Size(200, 40);
            this.viewGradesButton.Click += new System.EventHandler(this.ViewGradesButton_Click);

            // Logout Button
            this.logoutButton.Text = "Logout";
            this.logoutButton.Location = new System.Drawing.Point(300, 230);
            this.logoutButton.Size = new System.Drawing.Size(200, 40);
            this.logoutButton.Click += new System.EventHandler(this.LogoutButton_Click);

            // Form Settings
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.viewAvailableCoursesButton);
            this.Controls.Add(this.viewEnrolledCoursesButton);
            this.Controls.Add(this.viewGradesButton);
            this.Controls.Add(this.logoutButton);
            this.Text = "Student Dashboard";
            this.ResumeLayout(false);
        }
    }
}
