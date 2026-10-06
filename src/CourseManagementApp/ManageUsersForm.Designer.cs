namespace CourseManagementApp
{
    partial class ManageUsersForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.DataGridView usersGridView;
        private System.Windows.Forms.Button deleteUserButton;
        private System.Windows.Forms.Button closeButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.titleLabel = new System.Windows.Forms.Label();
            this.usersGridView = new System.Windows.Forms.DataGridView();
            this.deleteUserButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Title Label
            this.titleLabel.Text = "Manage Users";
            this.titleLabel.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.titleLabel.Location = new System.Drawing.Point(300, 20);
            this.titleLabel.Size = new System.Drawing.Size(250, 30);

            // Users GridView
            this.usersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersGridView.Location = new System.Drawing.Point(50, 70);
            this.usersGridView.Size = new System.Drawing.Size(700, 250);
            this.usersGridView.ReadOnly = true;
            this.usersGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.usersGridView.Columns.Add("UserID", "User ID");
            this.usersGridView.Columns.Add("FirstName", "First Name");
            this.usersGridView.Columns.Add("LastName", "Last Name");
            this.usersGridView.Columns.Add("Email", "Email");
            this.usersGridView.Columns.Add("Role", "Role");

            // Delete User Button
            this.deleteUserButton.Text = "Delete User";
            this.deleteUserButton.Location = new System.Drawing.Point(250, 340);
            this.deleteUserButton.Size = new System.Drawing.Size(120, 40);
            this.deleteUserButton.Click += new System.EventHandler(this.DeleteUserButton_Click);

            // Close Button
            this.closeButton.Text = "Close";
            this.closeButton.Location = new System.Drawing.Point(400, 340);
            this.closeButton.Size = new System.Drawing.Size(120, 40);
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);

            // Form Settings
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.usersGridView);
            this.Controls.Add(this.deleteUserButton);
            this.Controls.Add(this.closeButton);
            this.Text = "Manage Users";
            this.ResumeLayout(false);
        }
    }
}
