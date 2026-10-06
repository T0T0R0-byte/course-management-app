namespace CourseManagementApp
{
    partial class ReportsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button enrollmentReportButton;
        private System.Windows.Forms.Button completionRateButton;
        private System.Windows.Forms.Button performanceReportButton;
        private System.Windows.Forms.TextBox studentIdTextBox;
        private System.Windows.Forms.Label studentIdLabel;
        private System.Windows.Forms.DataGridView reportGridView;
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
            this.enrollmentReportButton = new System.Windows.Forms.Button();
            this.completionRateButton = new System.Windows.Forms.Button();
            this.performanceReportButton = new System.Windows.Forms.Button();
            this.studentIdTextBox = new System.Windows.Forms.TextBox();
            this.studentIdLabel = new System.Windows.Forms.Label();
            this.reportGridView = new System.Windows.Forms.DataGridView();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Title Label
            this.titleLabel.Text = "Reports";
            this.titleLabel.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.titleLabel.Location = new System.Drawing.Point(350, 20);
            this.titleLabel.Size = new System.Drawing.Size(150, 30);

            // Enrollment Report Button
            this.enrollmentReportButton.Text = "Enrollment Report";
            this.enrollmentReportButton.Location = new System.Drawing.Point(50, 70);
            this.enrollmentReportButton.Size = new System.Drawing.Size(200, 40);
            this.enrollmentReportButton.Click += new System.EventHandler(this.EnrollmentReportButton_Click);

            // Completion Rate Report Button
            this.completionRateButton.Text = "Completion Rate Report";
            this.completionRateButton.Location = new System.Drawing.Point(280, 70);
            this.completionRateButton.Size = new System.Drawing.Size(200, 40);
            this.completionRateButton.Click += new System.EventHandler(this.CompletionRateButton_Click);

            // Student Performance Report Button
            this.performanceReportButton.Text = "Performance Report";
            this.performanceReportButton.Location = new System.Drawing.Point(510, 70);
            this.performanceReportButton.Size = new System.Drawing.Size(200, 40);
            this.performanceReportButton.Click += new System.EventHandler(this.PerformanceReportButton_Click);

            // Student ID Label
            this.studentIdLabel.Text = "Student ID:";
            this.studentIdLabel.Location = new System.Drawing.Point(50, 130);
            this.studentIdLabel.Size = new System.Drawing.Size(80, 25);

            // Student ID TextBox
            this.studentIdTextBox.Location = new System.Drawing.Point(130, 130);
            this.studentIdTextBox.Size = new System.Drawing.Size(150, 25);

            // Report GridView
            this.reportGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reportGridView.Location = new System.Drawing.Point(50, 180);
            this.reportGridView.Size = new System.Drawing.Size(700, 250);
            this.reportGridView.ReadOnly = true;
            this.reportGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            // Close Button
            this.closeButton.Text = "Close";
            this.closeButton.Location = new System.Drawing.Point(350, 450);
            this.closeButton.Size = new System.Drawing.Size(120, 40);
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);

            // Form Settings
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.enrollmentReportButton);
            this.Controls.Add(this.completionRateButton);
            this.Controls.Add(this.performanceReportButton);
            this.Controls.Add(this.studentIdLabel);
            this.Controls.Add(this.studentIdTextBox);
            this.Controls.Add(this.reportGridView);
            this.Controls.Add(this.closeButton);
            this.Text = "Reports";
            this.ResumeLayout(false);
        }
    }
}
