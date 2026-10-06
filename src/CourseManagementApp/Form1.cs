using System;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace CourseManagementApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI()
        {
            Button testConnectionButton = new Button();
            testConnectionButton.Text = "Test Database Connection";
            testConnectionButton.Size = new System.Drawing.Size(200, 50);
            testConnectionButton.Location = new System.Drawing.Point(300, 200);
            testConnectionButton.Click += TestDatabaseConnection;
            this.Controls.Add(testConnectionButton);
        }

        private void TestDatabaseConnection(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=CourseManagement;User ID=root;Password=;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Database Connection Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Connection Failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
