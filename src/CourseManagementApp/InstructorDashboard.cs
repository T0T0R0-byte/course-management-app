using System;
using System.Windows.Forms;

namespace CourseManagementApp
{
    public partial class InstructorDashboard : Form
    {
        private Instructor instructor;

        public InstructorDashboard(Instructor instructor)
        {
            InitializeComponent();
            this.instructor = instructor;
        }

        // ✅ View My Courses
        private void ManageCoursesButton_Click(object sender, EventArgs e)
        {
            ManageCoursesForm manageCoursesForm = new ManageCoursesForm();
            manageCoursesForm.Show();
        }

        // ✅ View Enrolled Students for Courses
        private void ViewStudentsButton_Click(object sender, EventArgs e)
        {
            ViewEnrolledStudentsForm viewStudentsForm = new ViewEnrolledStudentsForm(instructor);
            viewStudentsForm.Show();
        }

        // ✅ Assign Grades to Students
        private void AssignGradesButton_Click(object sender, EventArgs e)
        {
            AssignGradesForm assignGradesForm = new AssignGradesForm(instructor);
            assignGradesForm.Show();
        }

        // ✅ Add Assignment to Courses
        private void AddAssignmentButton_Click(object sender, EventArgs e)
        {
            AddAssignmentForm addAssignmentForm = new AddAssignmentForm(instructor);
            addAssignmentForm.Show();
        }

        // ✅ Manage Enrollments
        private void ManageEnrollmentsButton_Click(object sender, EventArgs e)
        {
            ManageEnrollmentsForm manageEnrollmentsForm = new ManageEnrollmentsForm(instructor);
            manageEnrollmentsForm.Show();
        }

        // ✅ Logout
        private void LogoutButton_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }
    }
}
