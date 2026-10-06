using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace CourseManagementApp
{
    internal class ReportManager
    {
        private readonly DatabaseHelper _dbHelper;

        public ReportManager()
        {
            _dbHelper = new DatabaseHelper();
        }

        public List<Tuple<string, int>> GetEnrollmentReport()
        {
            List<Tuple<string, int>> report = new List<Tuple<string, int>>();

            string query = @"
                SELECT C.Title, COUNT(E.EnrollmentID) AS TotalEnrollments
                FROM Courses C
                LEFT JOIN Enrollments E ON C.CourseID = E.CourseID
                GROUP BY C.Title";

            DataTable result = _dbHelper.ExecuteQuery(query);

            foreach (DataRow row in result.Rows)
            {
                report.Add(new Tuple<string, int>(
                    row["Title"].ToString(),
                    Convert.ToInt32(row["TotalEnrollments"])
                ));
            }

            return report;
        }

        public List<Tuple<string, double>> GetCompletionRateReport()
        {
            List<Tuple<string, double>> report = new List<Tuple<string, double>>();

            string query = @"
                SELECT C.Title, 
                    (COUNT(CASE WHEN E.Status = 'Completed' THEN 1 END) * 100.0 / COUNT(E.EnrollmentID)) AS CompletionRate
                FROM Courses C
                LEFT JOIN Enrollments E ON C.CourseID = E.CourseID
                GROUP BY C.Title";

            DataTable result = _dbHelper.ExecuteQuery(query);

            foreach (DataRow row in result.Rows)
            {
                double completionRate = row["CompletionRate"] == DBNull.Value ? 0.0 : Convert.ToDouble(row["CompletionRate"]);
                report.Add(new Tuple<string, double>(row["Title"].ToString(), completionRate));
            }

            return report;
        }

        public List<Tuple<string, string, double?>> GetStudentPerformanceReport(int studentId)
        {
            List<Tuple<string, string, double?>> report = new List<Tuple<string, string, double?>>();

            string query = @"
                SELECT C.Title AS CourseTitle, A.Title AS AssignmentTitle, S.Grade
                FROM Submissions S
                INNER JOIN Assignments A ON S.AssignmentID = A.AssignmentID
                INNER JOIN Courses C ON A.CourseID = C.CourseID
                WHERE S.StudentID = @StudentID";

            MySqlParameter[] parameters = {
                new MySqlParameter("@StudentID", studentId)
            };

            DataTable result = _dbHelper.ExecuteQuery(query, parameters);

            foreach (DataRow row in result.Rows)
            {
                double? grade = row["Grade"] == DBNull.Value ? null : (double?)Convert.ToDouble(row["Grade"]);
                report.Add(new Tuple<string, string, double?>(row["CourseTitle"].ToString(), row["AssignmentTitle"].ToString(), grade));
            }

            return report;
        }
    }
}
