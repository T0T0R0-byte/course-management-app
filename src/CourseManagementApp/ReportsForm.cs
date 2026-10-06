using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CourseManagementApp
{
    public partial class ReportsForm : Form
    {
        private ReportManager reportManager;

        public ReportsForm()
        {
            InitializeComponent();
            reportManager = new ReportManager();
        }

        // ✅ Load Enrollment Report
        private void EnrollmentReportButton_Click(object sender, EventArgs e)
        {
            reportGridView.Columns.Clear();
            reportGridView.Rows.Clear();
            reportGridView.Columns.Add("Course", "Course Title");
            reportGridView.Columns.Add("Enrollments", "Total Enrollments");

            List<Tuple<string, int>> enrollments = reportManager.GetEnrollmentReport();
            foreach (var entry in enrollments)
            {
                reportGridView.Rows.Add(entry.Item1, entry.Item2);
            }
        }

        // ✅ Load Course Completion Rate Report
        private void CompletionRateButton_Click(object sender, EventArgs e)
        {
            reportGridView.Columns.Clear();
            reportGridView.Rows.Clear();
            reportGridView.Columns.Add("Course", "Course Title");
            reportGridView.Columns.Add("CompletionRate", "Completion Rate (%)");

            List<Tuple<string, double>> completionRates = reportManager.GetCompletionRateReport();
            foreach (var entry in completionRates)
            {
                reportGridView.Rows.Add(entry.Item1, entry.Item2);
            }
        }

        // ✅ Load Student Performance Report
        private void PerformanceReportButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(studentIdTextBox.Text))
            {
                MessageBox.Show("Please enter a Student ID.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(studentIdTextBox.Text, out int studentId))
            {
                MessageBox.Show("Invalid Student ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            reportGridView.Columns.Clear();
            reportGridView.Rows.Clear();
            reportGridView.Columns.Add("Course", "Course Title");
            reportGridView.Columns.Add("Assignment", "Assignment Title");
            reportGridView.Columns.Add("Grade", "Grade");

            List<Tuple<string, string, double?>> grades = reportManager.GetStudentPerformanceReport(studentId);
            foreach (var entry in grades)
            {
                string gradeDisplay = entry.Item3.HasValue ? entry.Item3.ToString() : "Not Graded";
                reportGridView.Rows.Add(entry.Item1, entry.Item2, gradeDisplay);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
