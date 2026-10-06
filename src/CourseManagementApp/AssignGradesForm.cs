using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CourseManagementApp
{
    public partial class AssignGradesForm : Form
    {
        private Instructor instructor;
        private CourseManager courseManager;
        private InstructorManager instructorManager;

        public AssignGradesForm(Instructor instructor)
        {
            InitializeComponent();
            this.instructor = instructor;
            courseManager = new CourseManager();
            instructorManager = new InstructorManager();
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

        // ✅ Load Students and Assignments for Selected Course
        private void LoadStudentsAndAssignments(int courseId)
        {
            studentsGridView.Rows.Clear();
            List<Tuple<int, string, string, string, string>> students = instructor.GetEnrolledStudents(courseId);

            foreach (var student in students)
            {
                studentsGridView.Rows.Add(student.Item1, student.Item2, student.Item3, student.Item4, student.Item5);
            }

            // Load assignments from the database
            LoadAssignments(courseId);
        }

        // ✅ Load Assignments for Selected Course from Database
        private void LoadAssignments(int courseId)
        {
            assignmentsComboBox.Items.Clear();
            List<Assignment> assignments = GetAssignmentsForCourse(courseId);

            foreach (var assignment in assignments)
            {
                assignmentsComboBox.Items.Add(new ComboBoxItem(assignment.Title, assignment.AssignmentId));
            }

            if (assignmentsComboBox.Items.Count > 0)
                assignmentsComboBox.SelectedIndex = 0;
        }

        // ✅ Assign Grade to Selected Student
        private void AssignGradeButton_Click(object sender, EventArgs e)
        {
            if (studentsGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a student to assign a grade.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(gradeTextBox.Text, out decimal grade) || grade < 0 || grade > 100)
            {
                MessageBox.Show("Please enter a valid grade between 0 and 100.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int studentId = Convert.ToInt32(studentsGridView.SelectedRows[0].Cells[0].Value);
            if (assignmentsComboBox.SelectedItem is ComboBoxItem selectedAssignment)
            {
                bool success = instructor.AssignGrade(studentId, selectedAssignment.Value, grade);
                if (success)
                {
                    MessageBox.Show("Grade assigned successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to assign grade.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CoursesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (coursesComboBox.SelectedItem is ComboBoxItem selectedCourse)
            {
                LoadStudentsAndAssignments(selectedCourse.Value);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ✅ Fetch Assignments for a Course from Database
        private List<Assignment> GetAssignmentsForCourse(int courseId)
        {
            List<Assignment> assignments = new List<Assignment>();
            string query = "SELECT * FROM Assignments WHERE CourseID = @CourseID";
            MySql.Data.MySqlClient.MySqlParameter[] parameters = {
                new MySql.Data.MySqlClient.MySqlParameter("@CourseID", courseId)
            };

            var result = new DatabaseHelper().ExecuteQuery(query, parameters);
            foreach (System.Data.DataRow row in result.Rows)
            {
                assignments.Add(new Assignment(
                    Convert.ToInt32(row["AssignmentID"]),
                    Convert.ToInt32(row["CourseID"]),
                    row["Title"].ToString(),
                    row["Description"].ToString(),
                    row["DueDate"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(row["DueDate"])
                ));
            }

            return assignments;
        }
    }
}
