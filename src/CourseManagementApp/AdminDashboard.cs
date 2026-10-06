using System;
using System.Windows.Forms;

namespace CourseManagementApp
{
    public partial class AdminDashboard : Form
    {
        private Admin admin;

        public AdminDashboard(Admin adminUser)
        {
            InitializeComponent();
            this.admin = adminUser;
        }

        private void ManageUsersButton_Click(object sender, EventArgs e)
        {
            admin.ManageUsers();
        }

        private void ManageCoursesButton_Click(object sender, EventArgs e)
        {
            admin.ManageCourses();
        }

        private void ViewReportsButton_Click(object sender, EventArgs e)
        {
            admin.ViewReports();
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            admin.Logout(this);
        }
    }
}
