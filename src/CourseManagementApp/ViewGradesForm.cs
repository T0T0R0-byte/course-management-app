using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CourseManagementApp
{
    public partial class ViewGradesForm : Form
    {
        private Student student;

        public ViewGradesForm(Student student)
        {
            InitializeComponent();
            this.student = student;
            LoadGrades();
        }

        // ✅ Load Grades into DataGridView
        private void LoadGrades()
        {
            gradesGridView.Rows.Clear();
            List<Tuple<string, decimal?>> grades = student.GetGrades();

            foreach (var grade in grades)
            {
                string assignmentTitle = grade.Item1;
                string gradeValue = grade.Item2.HasValue ? grade.Item2.Value.ToString() : "Not Graded";
                gradesGridView.Rows.Add(assignmentTitle, gradeValue);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
