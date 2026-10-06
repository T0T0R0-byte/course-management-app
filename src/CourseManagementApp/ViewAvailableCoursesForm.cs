using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CourseManagementApp
{
    public partial class ViewAvailableCoursesForm : Form
    {
        private Student student;

        public ViewAvailableCoursesForm(Student student)
        {
            InitializeComponent();
            this.student = student;
            LoadAvailableCourses();
        }

        // ✅ Load Available Courses into DataGridView
        private void LoadAvailableCourses()
        {
            coursesGridView.Rows.Clear();
            List<Course> courses = student.GetAvailableCourses();

            foreach (var course in courses)
            {
                coursesGridView.Rows.Add(course.CourseID, course.Title, course.Description, course.Duration, course.MaxCapacity);
            }
        }

        // ✅ Enroll in Selected Course
        private void EnrollButton_Click(object sender, EventArgs e)
        {
            if (coursesGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a course to enroll in.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int courseId = Convert.ToInt32(coursesGridView.SelectedRows[0].Cells[0].Value);
            bool success = student.EnrollInCourse(courseId);

            if (success)
            {
                MessageBox.Show("Enrollment request sent! Waiting for approval.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAvailableCourses(); // Refresh list after enrollment
            }
            else
            {
                MessageBox.Show("Failed to enroll. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
