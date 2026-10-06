using System;
using System.Windows.Forms;

namespace CourseManagementApp
{
    public partial class LoginForm : Form
    {
        private UserManager userManager;

        public LoginForm()
        {
            InitializeComponent();
            userManager = new UserManager();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string email = emailBox.Text;
            string password = passwordBox.Text;
            User loggedInUser = userManager.LoginUser(email, password);

            if (loggedInUser != null)
            {
                MessageBox.Show($"Login Successful!\nWelcome, {loggedInUser.FirstName} {loggedInUser.LastName}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RedirectUser(loggedInUser);
            }
            else
            {
                MessageBox.Show("Login Failed. Invalid email or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
            this.Hide();
        }

        private void RedirectUser(User user)
        {
            if (user.Role == "Admin")
            {
                Admin admin = new Admin(user.UserID, user.FirstName, user.LastName, user.Email, user.Password);
                new AdminDashboard(admin).Show();
            }
            else if (user.Role == "Instructor")
            {
                Instructor instructor = new Instructor(user.UserID, user.FirstName, user.LastName, user.Email, user.Password);
                new InstructorDashboard(instructor).Show();
            }
            else if (user.Role == "Student")
            {
                Student student = new Student(user.UserID, user.FirstName, user.LastName, user.Email, user.Password);
                new StudentDashboard(student).Show();
            }
            this.Hide();
        }

    }
}
