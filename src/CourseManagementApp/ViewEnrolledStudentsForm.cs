using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CourseManagementApp
{
    public partial class ViewEnrolledStudentsForm : Form
    {
        private Instructor instructor;

        public ViewEnrolledStudentsForm(Instructor instructor)
        {
            InitializeComponent();
            this.instructor = instructor;
            LoadCourses();
        }

        // ✅ Step 1: Load Instructor's Courses into ComboBox
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

        // ✅ Step 2: Load Enrolled Students for Selected Course
        private void LoadEnrolledStudents(int courseId)
        {
            studentsGridView.Rows.Clear();
            List<Tuple<int, string, string, string, string>> students = instructor.GetEnrolledStudents(courseId);

            foreach (var student in students)
            {
                studentsGridView.Rows.Add(student.Item1, student.Item2, student.Item3, student.Item4, student.Item5);
            }
        }

        private void CoursesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (coursesComboBox.SelectedItem is ComboBoxItem selectedCourse)
            {
                LoadEnrolledStudents(selectedCourse.Value);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    // ✅ Helper Class for ComboBox (Stores Course ID)
    public class ComboBoxItem
    {
        public string Text { get; }
        public int Value { get; }

        public ComboBoxItem(string text, int value)
        {
            Text = text;
            Value = value;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
