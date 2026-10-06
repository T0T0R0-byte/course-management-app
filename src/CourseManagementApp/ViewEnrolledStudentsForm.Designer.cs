namespace CourseManagementApp
{
    partial class ViewEnrolledStudentsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.ComboBox coursesComboBox;
        private System.Windows.Forms.Label selectCourseLabel;
        private System.Windows.Forms.DataGridView studentsGridView;
        private System.Windows.Forms.Button closeButton;

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
            this.selectCourseLabel = new System.Windows.Forms.Label();
            this.coursesComboBox = new System.Windows.Forms.ComboBox();
            this.studentsGridView = new System.Windows.Forms.DataGridView();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Title Label
            this.titleLabel.Text = "Enrolled Students";
            this.titleLabel.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.titleLabel.Location = new System.Drawing.Point(300, 20);
            this.titleLabel.Size = new System.Drawing.Size(250, 30);

            // Select Course Label
            this.selectCourseLabel.Text = "Select Course:";
            this.selectCourseLabel.Location = new System.Drawing.Point(50, 70);
            this.selectCourseLabel.Size = new System.Drawing.Size(100, 25);

            // Courses ComboBox
            this.coursesComboBox.Location = new System.Drawing.Point(150, 70);
            this.coursesComboBox.Size = new System.Drawing.Size(250, 25);
            this.coursesComboBox.SelectedIndexChanged += new System.EventHandler(this.CoursesComboBox_SelectedIndexChanged);

            // Students GridView
            this.studentsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.studentsGridView.Location = new System.Drawing.Point(50, 120);
            this.studentsGridView.Size = new System.Drawing.Size(700, 250);
            this.studentsGridView.ReadOnly = true;
            this.studentsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.studentsGridView.Columns.Add("StudentID", "Student ID");
            this.studentsGridView.Columns.Add("FirstName", "First Name");
            this.studentsGridView.Columns.Add("LastName", "Last Name");
            this.studentsGridView.Columns.Add("Email", "Email");
            this.studentsGridView.Columns.Add("CourseTitle", "Course");

            // Close Button
            this.closeButton.Text = "Close";
            this.closeButton.Location = new System.Drawing.Point(350, 390);
            this.closeButton.Size = new System.Drawing.Size(120, 40);
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);

            // Form Settings
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.selectCourseLabel);
            this.Controls.Add(this.coursesComboBox);
            this.Controls.Add(this.studentsGridView);
            this.Controls.Add(this.closeButton);
            this.Text = "View Enrolled Students";
            this.ResumeLayout(false);
        }
    }
}
