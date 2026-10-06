using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CourseManagementApp
{
    public partial class ManageEnrollmentsForm : Form
    {
        private Instructor instructor;

        public ManageEnrollmentsForm(Instructor instructor)
        {
            InitializeComponent();
            this.instructor = instructor;
            LoadPendingEnrollments();
        }

        // ✅ Load Pending Enrollments into DataGridView
        private void LoadPendingEnrollments()
        {
            enrollmentsGridView.Rows.Clear();
            List<Tuple<int, string, string, int, string>> enrollments = instructor.GetPendingEnrollments();

            foreach (var enrollment in enrollments)
            {
                enrollmentsGridView.Rows.Add(enrollment.Item1, enrollment.Item2, enrollment.Item3, enrollment.Item4, enrollment.Item5);
            }
        }

        // ✅ Approve Selected Enrollment
        private void ApproveButton_Click(object sender, EventArgs e)
        {
            UpdateEnrollmentStatus("Approved");
        }

        // ✅ Reject Selected Enrollment
        private void RejectButton_Click(object sender, EventArgs e)
        {
            UpdateEnrollmentStatus("Rejected");
        }

        private void UpdateEnrollmentStatus(string status)
        {
            if (enrollmentsGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a student enrollment to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int enrollmentId = Convert.ToInt32(enrollmentsGridView.SelectedRows[0].Cells[0].Value);
            bool success = instructor.UpdateEnrollmentStatus(enrollmentId, status);

            if (success)
            {
                MessageBox.Show($"Enrollment {status} successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPendingEnrollments(); // Refresh list after approval/rejection
            }
            else
            {
                MessageBox.Show("Failed to update enrollment. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
