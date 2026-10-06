namespace CourseManagementApp
{
    partial class AssignGradesForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.ComboBox coursesComboBox;
        private System.Windows.Forms.Label selectCourseLabel;
        private System.Windows.Forms.DataGridView studentsGridView;
        private System.Windows.Forms.Label selectAssignmentLabel;
        private System.Windows.Forms.ComboBox assignmentsComboBox;
        private System.Windows.Forms.Label gradeLabel;
        private System.Windows.Forms.TextBox gradeTextBox;
        private System.Windows.Forms.Button assignGradeButton;
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
            this.selectAssignmentLabel = new System.Windows.Forms.Label();
            this.assignmentsComboBox = new System.Windows.Forms.ComboBox();
            this.gradeLabel = new System.Windows.Forms.Label();
            this.gradeTextBox = new System.Windows.Forms.TextBox();
            this.assignGradeButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Title Label
            this.titleLabel.Text = "Assign Grades";
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
            this.studentsGridView.Size = new System.Drawing.Size(700, 200);
            this.studentsGridView.ReadOnly = true;
            this.studentsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.studentsGridView.Columns.Add("StudentID", "Student ID");
            this.studentsGridView.Columns.Add("FirstName", "First Name");
            this.studentsGridView.Columns.Add("LastName", "Last Name");
            this.studentsGridView.Columns.Add("Email", "Email");

            // Select Assignment Label
            this.selectAssignmentLabel.Text = "Select Assignment:";
            this.selectAssignmentLabel.Location = new System.Drawing.Point(50, 340);
            this.selectAssignmentLabel.Size = new System.Drawing.Size(120, 25);

            // Assignments ComboBox
            this.assignmentsComboBox.Location = new System.Drawing.Point(180, 340);
            this.assignmentsComboBox.Size = new System.Drawing.Size(250, 25);

            // Grade Label
            this.gradeLabel.Text = "Enter Grade:";
            this.gradeLabel.Location = new System.Drawing.Point(50, 380);
            this.gradeLabel.Size = new System.Drawing.Size(100, 25);

            // Grade TextBox
            this.gradeTextBox.Location = new System.Drawing.Point(180, 380);
            this.gradeTextBox.Size = new System.Drawing.Size(100, 25);

            // Assign Grade Button
            this.assignGradeButton.Text = "Assign Grade";
            this.assignGradeButton.Location = new System.Drawing.Point(300, 420);
            this.assignGradeButton.Size = new System.Drawing.Size(120, 40);
            this.assignGradeButton.Click += new System.EventHandler(this.AssignGradeButton_Click);

            // Close Button
            this.closeButton.Text = "Close";
            this.closeButton.Location = new System.Drawing.Point(450, 420);
            this.closeButton.Size = new System.Drawing.Size(120, 40);
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);

            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.selectCourseLabel);
            this.Controls.Add(this.coursesComboBox);
            this.Controls.Add(this.studentsGridView);
            this.Controls.Add(this.selectAssignmentLabel);
            this.Controls.Add(this.assignmentsComboBox);
            this.Controls.Add(this.gradeLabel);
            this.Controls.Add(this.gradeTextBox);
            this.Controls.Add(this.assignGradeButton);
            this.Controls.Add(this.closeButton);
            this.Text = "Assign Grades";
            this.ResumeLayout(false);
        }
    }
}
