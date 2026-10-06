using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CourseManagementApp
{
    public partial class ManageUsersForm : Form
    {
        private AdminManager adminManager;

        public ManageUsersForm()
        {
            InitializeComponent();
            adminManager = new AdminManager();
            LoadUsers();
        }

        private void LoadUsers()
        {
            List<User> users = adminManager.GetAllUsers();
            usersGridView.Rows.Clear();

            foreach (User user in users)
            {
                usersGridView.Rows.Add(user.UserID, user.FirstName, user.LastName, user.Email, user.Role);
            }
        }

        private void DeleteUserButton_Click(object sender, EventArgs e)
        {
            if (usersGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userId = Convert.ToInt32(usersGridView.SelectedRows[0].Cells[0].Value);
            string userName = usersGridView.SelectedRows[0].Cells[1].Value.ToString() + " " + usersGridView.SelectedRows[0].Cells[2].Value.ToString();

            DialogResult confirm = MessageBox.Show($"Are you sure you want to delete {userName}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                bool deleted = adminManager.DeleteUser(userId);
                if (deleted)
                {
                    MessageBox.Show("User deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUsers();
                }
                else
                {
                    MessageBox.Show("Failed to delete user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
