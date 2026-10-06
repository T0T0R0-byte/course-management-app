using System;
using System.Windows.Forms;

namespace CourseManagementApp
{
    public partial class RegisterForm : Form
    {
        private UserManager userManager;

        public RegisterForm()
        {
            InitializeComponent();
            userManager = new UserManager();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            string firstName = firstNameBox.Text;
            string lastName = lastNameBox.Text;
            string email = emailBox.Text;
            string password = passwordBox.Text;

            // Register as a Student by default
            bool isRegistered = userManager.AddUser(firstName, lastName, email, password, "Student");

            if (isRegistered)
            {
                MessageBox.Show("Registration Successful! You can now log in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Registration Failed. Email might be already taken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
