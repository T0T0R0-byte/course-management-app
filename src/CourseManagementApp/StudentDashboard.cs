using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CourseManagementApp
{
    public partial class StudentDashboard : Form
    {
        private Student student;

        public StudentDashboard(Student student)
        {
            InitializeComponent();
            this.student = student;
        }

        private void ViewAvailableCoursesButton_Click(object sender, EventArgs e)
        {
            ViewAvailableCoursesForm viewAvailableCoursesForm = new ViewAvailableCoursesForm(student);
            viewAvailableCoursesForm.Show();
        }

        private void ViewEnrolledCoursesButton_Click(object sender, EventArgs e)
        {
            ViewEnrolledCoursesForm viewEnrolledCoursesForm = new ViewEnrolledCoursesForm(student);
            viewEnrolledCoursesForm.Show();
        }

        private void ViewGradesButton_Click(object sender, EventArgs e)
        {
            ViewGradesForm viewGradesForm = new ViewGradesForm(student);
            viewGradesForm.Show();
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }
    }
}
