namespace CourseManagementApp
{
    partial class ViewEnrolledCoursesForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.DataGridView coursesGridView;
        private System.Windows.Forms.Button dropCourseButton;
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
            this.coursesGridView = new System.Windows.Forms.DataGridView();
            this.dropCourseButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Title Label
            this.titleLabel.Text = "My Enrolled Courses";
            this.titleLabel.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.titleLabel.Location = new System.Drawing.Point(300, 20);
            this.titleLabel.Size = new System.Drawing.Size(250, 30);

            // Courses DataGridView
            this.coursesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.coursesGridView.Location = new System.Drawing.Point(50, 70);
            this.coursesGridView.Size = new System.Drawing.Size(700, 250);
            this.coursesGridView.ReadOnly = true;
            this.coursesGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.coursesGridView.Columns.Add("CourseID", "Course ID");
            this.coursesGridView.Columns.Add("Title", "Title");
            this.coursesGridView.Columns.Add("Description", "Description");
            this.coursesGridView.Columns.Add("Duration", "Duration (weeks)");
            this.coursesGridView.Columns.Add("MaxCapacity", "Max Capacity");

            // Drop Course Button
            this.dropCourseButton.Text = "Drop Course";
            this.dropCourseButton.Location = new System.Drawing.Point(250, 340);
            this.dropCourseButton.Size = new System.Drawing.Size(120, 40);
            this.dropCourseButton.Click += new System.EventHandler(this.DropCourseButton_Click);

            // Close Button
            this.closeButton.Text = "Close";
            this.closeButton.Location = new System.Drawing.Point(400, 340);
            this.closeButton.Size = new System.Drawing.Size(120, 40);
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);

            // Form Settings
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.coursesGridView);
            this.Controls.Add(this.dropCourseButton);
            this.Controls.Add(this.closeButton);
            this.Text = "View Enrolled Courses";
            this.ResumeLayout(false);
        }
    }
}
