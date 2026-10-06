namespace CourseManagementApp
{
    partial class InstructorDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button manageCoursesButton;
        private System.Windows.Forms.Button viewStudentsButton;
        private System.Windows.Forms.Button assignGradesButton;
        private System.Windows.Forms.Button addAssignmentButton;
        private System.Windows.Forms.Button manageEnrollmentsButton;
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
            this.manageCoursesButton = new System.Windows.Forms.Button();
            this.viewStudentsButton = new System.Windows.Forms.Button();
            this.assignGradesButton = new System.Windows.Forms.Button();
            this.addAssignmentButton = new System.Windows.Forms.Button();
            this.manageEnrollmentsButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Title Label
            this.titleLabel.Text = "Instructor Dashboard";
            this.titleLabel.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.titleLabel.Location = new System.Drawing.Point(300, 30);
            this.titleLabel.Size = new System.Drawing.Size(250, 30);

            // Manage Courses Button
            this.manageCoursesButton.Text = "Manage My Courses";
            this.manageCoursesButton.Location = new System.Drawing.Point(300, 80);
            this.manageCoursesButton.Size = new System.Drawing.Size(200, 40);
            this.manageCoursesButton.Click += new System.EventHandler(this.ManageCoursesButton_Click);

            // View Enrolled Students Button
            this.viewStudentsButton.Text = "View Enrolled Students";
            this.viewStudentsButton.Location = new System.Drawing.Point(300, 130);
            this.viewStudentsButton.Size = new System.Drawing.Size(200, 40);
            this.viewStudentsButton.Click += new System.EventHandler(this.ViewStudentsButton_Click);

            // Assign Grades Button
            this.assignGradesButton.Text = "Assign Grades";
            this.assignGradesButton.Location = new System.Drawing.Point(300, 180);
            this.assignGradesButton.Size = new System.Drawing.Size(200, 40);
            this.assignGradesButton.Click += new System.EventHandler(this.AssignGradesButton_Click);

            // Add Assignment Button
            this.addAssignmentButton.Text = "Add Assignment";
            this.addAssignmentButton.Location = new System.Drawing.Point(300, 230);
            this.addAssignmentButton.Size = new System.Drawing.Size(200, 40);
            this.addAssignmentButton.Click += new System.EventHandler(this.AddAssignmentButton_Click);

            // Manage Enrollments Button
            this.manageEnrollmentsButton.Text = "Manage Enrollments";
            this.manageEnrollmentsButton.Location = new System.Drawing.Point(300, 280);
            this.manageEnrollmentsButton.Size = new System.Drawing.Size(200, 40);
            this.manageEnrollmentsButton.Click += new System.EventHandler(this.ManageEnrollmentsButton_Click);

            // Logout Button
            this.logoutButton.Text = "Logout";
            this.logoutButton.Location = new System.Drawing.Point(300, 330);
            this.logoutButton.Size = new System.Drawing.Size(200, 40);
            this.logoutButton.Click += new System.EventHandler(this.LogoutButton_Click);

            // Form Settings
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.manageCoursesButton);
            this.Controls.Add(this.viewStudentsButton);
            this.Controls.Add(this.assignGradesButton);
            this.Controls.Add(this.addAssignmentButton);
            this.Controls.Add(this.manageEnrollmentsButton);
            this.Controls.Add(this.logoutButton);
            this.Text = "Instructor Dashboard";
            this.ResumeLayout(false);
        }
    }
}
