namespace CourseManagementApp
{
    partial class AddAssignmentForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.ComboBox coursesComboBox;
        private System.Windows.Forms.Label courseLabel;
        private System.Windows.Forms.Label assignmentTitleLabel;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label dueDateLabel;
        private System.Windows.Forms.DateTimePicker dueDatePicker;
        private System.Windows.Forms.Button addAssignmentButton;
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
            this.courseLabel = new System.Windows.Forms.Label();
            this.coursesComboBox = new System.Windows.Forms.ComboBox();
            this.assignmentTitleLabel = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.dueDateLabel = new System.Windows.Forms.Label();
            this.dueDatePicker = new System.Windows.Forms.DateTimePicker();
            this.addAssignmentButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // Title Label
            this.titleLabel.Text = "Add Assignment";
            this.titleLabel.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.titleLabel.Location = new System.Drawing.Point(300, 20);
            this.titleLabel.Size = new System.Drawing.Size(200, 30);

            // Course Label & ComboBox
            this.courseLabel.Text = "Select Course:";
            this.courseLabel.Location = new System.Drawing.Point(50, 70);
            this.courseLabel.Size = new System.Drawing.Size(120, 25);

            this.coursesComboBox.Location = new System.Drawing.Point(180, 70);
            this.coursesComboBox.Size = new System.Drawing.Size(250, 25);

            // Assignment Title
            this.assignmentTitleLabel.Text = "Assignment Title:";
            this.assignmentTitleLabel.Location = new System.Drawing.Point(50, 110);
            this.assignmentTitleLabel.Size = new System.Drawing.Size(120, 25);

            this.titleTextBox.Location = new System.Drawing.Point(180, 110);
            this.titleTextBox.Size = new System.Drawing.Size(250, 25);

            // Description
            this.descriptionLabel.Text = "Description:";
            this.descriptionLabel.Location = new System.Drawing.Point(50, 150);
            this.descriptionLabel.Size = new System.Drawing.Size(120, 25);

            this.descriptionTextBox.Location = new System.Drawing.Point(180, 150);
            this.descriptionTextBox.Size = new System.Drawing.Size(250, 25);

            // Due Date
            this.dueDateLabel.Text = "Due Date:";
            this.dueDateLabel.Location = new System.Drawing.Point(50, 190);
            this.dueDateLabel.Size = new System.Drawing.Size(120, 25);

            this.dueDatePicker.Location = new System.Drawing.Point(180, 190);
            this.dueDatePicker.Size = new System.Drawing.Size(250, 25);

            // Buttons
            this.addAssignmentButton.Text = "Add Assignment";
            this.addAssignmentButton.Location = new System.Drawing.Point(180, 230);
            this.addAssignmentButton.Size = new System.Drawing.Size(120, 40);
            this.addAssignmentButton.Click += new System.EventHandler(this.AddAssignmentButton_Click);

            this.closeButton.Text = "Close";
            this.closeButton.Location = new System.Drawing.Point(320, 230);
            this.closeButton.Size = new System.Drawing.Size(120, 40);
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);

            // ✅ Add Controls to the Form
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.courseLabel);
            this.Controls.Add(this.coursesComboBox);
            this.Controls.Add(this.assignmentTitleLabel);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.dueDateLabel);
            this.Controls.Add(this.dueDatePicker);
            this.Controls.Add(this.addAssignmentButton);
            this.Controls.Add(this.closeButton);

            // Form Settings
            this.ClientSize = new System.Drawing.Size(500, 350);
            this.Text = "Add Assignment";
            this.ResumeLayout(false);
        }
    }
}
