using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CourseManagementApp
{
    public partial class AddAssignmentForm : Form
    {
        private Instructor instructor;

        public AddAssignmentForm(Instructor instructor)
        {
            InitializeComponent();
            this.instructor = instructor;
            LoadCourses();
        }

        // ✅ Load Instructor's Courses
        private void LoadCourses()
        {
            List<Course> courses = instructor.GetMyCourses();
            coursesComboBox.Items.Clear();

            foreach (var course in courses)
            {
                coursesComboBox.Items.Add(new ComboBoxItem(course.Title, course.CourseID));
            }

            if (coursesComboBox.Items.Count > 0)
                coursesComboBox.SelectedIndex = 0;
        }

        // ✅ Submit New Assignment
        private void AddAssignmentButton_Click(object sender, EventArgs e)
        {
            if (coursesComboBox.SelectedItem is ComboBoxItem selectedCourse)
            {
                string title = titleTextBox.Text.Trim();
                string description = descriptionTextBox.Text.Trim();
                DateTime dueDate = dueDatePicker.Value;

                if (string.IsNullOrEmpty(title))
                {
                    MessageBox.Show("Please enter a title for the assignment.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool success = instructor.AddAssignment(selectedCourse.Value, title, description, dueDate);

                if (success)
                {
                    MessageBox.Show("Assignment added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to add assignment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
