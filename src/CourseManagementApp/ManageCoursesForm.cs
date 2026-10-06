using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CourseManagementApp
{
    public partial class ManageCoursesForm : Form
    {
        private AdminManager adminManager;
        private CourseManager courseManager;

        public ManageCoursesForm()
        {
            InitializeComponent();
            adminManager = new AdminManager();
            courseManager = new CourseManager();
            LoadCourses();
        }

        // ✅ Step 1: Load All Courses into DataGridView
        private void LoadCourses()
        {
            List<Course> courses = courseManager.GetAllCourses();
            coursesGridView.Rows.Clear();

            foreach (Course course in courses)
            {
                coursesGridView.Rows.Add(course.CourseID, course.Title, course.Description, course.Duration, course.MaxCapacity);
            }
        }

        // ✅ Step 2: Delete Selected Course
        private void DeleteCourseButton_Click(object sender, EventArgs e)
        {
            if (coursesGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a course to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int courseId = Convert.ToInt32(coursesGridView.SelectedRows[0].Cells[0].Value);
            string courseTitle = coursesGridView.SelectedRows[0].Cells[1].Value.ToString();

            DialogResult confirm = MessageBox.Show($"Are you sure you want to delete {courseTitle}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                bool deleted = adminManager.DeleteCourse(courseId);
                if (deleted)
                {
                    MessageBox.Show("Course deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCourses();
                }
                else
                {
                    MessageBox.Show("Failed to delete course.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
