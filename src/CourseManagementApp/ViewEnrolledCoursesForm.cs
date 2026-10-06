using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CourseManagementApp
{
    public partial class ViewEnrolledCoursesForm : Form
    {
        private Student student;

        public ViewEnrolledCoursesForm(Student student)
        {
            InitializeComponent();
            this.student = student;
            LoadEnrolledCourses();
        }

        private void LoadEnrolledCourses()
        {
            coursesGridView.Rows.Clear();
            List<Course> courses = student.GetEnrolledCourses();

            foreach (var course in courses)
            {
                coursesGridView.Rows.Add(course.CourseID, course.Title, course.Description, course.Duration, course.MaxCapacity);
            }
        }

        private void DropCourseButton_Click(object sender, EventArgs e)
        {
            if (coursesGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a course to drop.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int courseId = Convert.ToInt32(coursesGridView.SelectedRows[0].Cells[0].Value);
            bool success = student.DropCourse(courseId);

            if (success)
            {
                MessageBox.Show("You have successfully dropped the course.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadEnrolledCourses(); // Refresh list after dropping course
            }
            else
            {
                MessageBox.Show("Failed to drop course. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
