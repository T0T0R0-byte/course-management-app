namespace CourseManagementApp
{
    partial class ManageEnrollmentsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.DataGridView enrollmentsGridView;
        private System.Windows.Forms.Button approveButton;
        private System.Windows.Forms.Button rejectButton;

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
            this.enrollmentsGridView = new System.Windows.Forms.DataGridView();
            this.approveButton = new System.Windows.Forms.Button();
            this.rejectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Title Label
            this.titleLabel.Text = "Manage Enrollments";
            this.titleLabel.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.titleLabel.Location = new System.Drawing.Point(300, 20);
            this.titleLabel.Size = new System.Drawing.Size(250, 30);

            // Enrollments DataGridView
            this.enrollmentsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.enrollmentsGridView.Location = new System.Drawing.Point(50, 70);
            this.enrollmentsGridView.Size = new System.Drawing.Size(700, 250);
            this.enrollmentsGridView.ReadOnly = true;
            this.enrollmentsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.enrollmentsGridView.Columns.Add("EnrollmentID", "Enrollment ID");
            this.enrollmentsGridView.Columns.Add("FirstName", "First Name");
            this.enrollmentsGridView.Columns.Add("LastName", "Last Name");
            this.enrollmentsGridView.Columns.Add("CourseID", "Course ID");
            this.enrollmentsGridView.Columns.Add("CourseTitle", "Course Title");

            // Approve Button
            this.approveButton.Text = "Approve";
            this.approveButton.Location = new System.Drawing.Point(200, 340);
            this.approveButton.Size = new System.Drawing.Size(120, 40);
            this.approveButton.Click += new System.EventHandler(this.ApproveButton_Click);

            // Reject Button
            this.rejectButton.Text = "Reject";
            this.rejectButton.Location = new System.Drawing.Point(350, 340);
            this.rejectButton.Size = new System.Drawing.Size(120, 40);
            this.rejectButton.Click += new System.EventHandler(this.RejectButton_Click);


            // Form Settings
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.enrollmentsGridView);
            this.Controls.Add(this.approveButton);
            this.Controls.Add(this.rejectButton);
            this.Text = "Manage Enrollments";
            this.ResumeLayout(false);
        }
    }
}
