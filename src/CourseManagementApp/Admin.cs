using System;
using System.Windows.Forms;

namespace CourseManagementApp
{
    public class Admin : User
    {
        private AdminManager adminManager;

        public Admin(int userId, string firstName, string lastName, string email, string password)
            : base(userId, firstName, lastName, email, password, "Admin")
        {
            adminManager = new AdminManager();
        }

        public void ManageUsers()
        {
            ManageUsersForm manageUsersForm = new ManageUsersForm();
            manageUsersForm.Show();
        }

        public void ManageCourses()
        {
            ManageCoursesForm manageCoursesForm = new ManageCoursesForm();
            manageCoursesForm.Show();
        }

        public void ViewReports()
        {
            ReportsForm reportsForm = new ReportsForm();
            reportsForm.Show();
        }

        public void Logout(Form currentForm)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            currentForm.Close();
        }
    }
}
