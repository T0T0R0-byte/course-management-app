using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace CourseManagementApp
{
    internal class StudentManager
    {
        private readonly DatabaseHelper _dbHelper;

        public StudentManager()
        {
            _dbHelper = new DatabaseHelper();
        }

        public List<Course> GetAvailableCourses(int studentId)
        {
            List<Course> courses = new List<Course>();
            string query = @"
                SELECT * FROM Courses 
                WHERE CourseID NOT IN 
                (SELECT CourseID FROM Enrollments WHERE StudentID = @StudentID AND Status = 'Approved')";

            MySqlParameter[] parameters = {
                new MySqlParameter("@StudentID", studentId)
            };

            DataTable result = _dbHelper.ExecuteQuery(query, parameters);

            foreach (DataRow row in result.Rows)
            {
                courses.Add(new Course(
                    Convert.ToInt32(row["CourseID"]),
                    Convert.ToInt32(row["InstructorID"]),
                    row["Title"].ToString(),
                    row["Description"].ToString(),
                    row["Duration"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["Duration"]),
                    row["MaxCapacity"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["MaxCapacity"]),
                    row["Syllabus"].ToString()
                ));
            }

            return courses;
        }

        public List<Course> GetEnrolledCourses(int studentId)
        {
            List<Course> courses = new List<Course>();
            string query = @"
                SELECT C.* FROM Courses C
                INNER JOIN Enrollments E ON C.CourseID = E.CourseID
                WHERE E.StudentID = @StudentID AND E.Status = 'Approved'";

            MySqlParameter[] parameters = {
                new MySqlParameter("@StudentID", studentId)
            };

            DataTable result = _dbHelper.ExecuteQuery(query, parameters);

            foreach (DataRow row in result.Rows)
            {
                courses.Add(new Course(
                    Convert.ToInt32(row["CourseID"]),
                    Convert.ToInt32(row["InstructorID"]),
                    row["Title"].ToString(),
                    row["Description"].ToString(),
                    row["Duration"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["Duration"]),
                    row["MaxCapacity"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["MaxCapacity"]),
                    row["Syllabus"].ToString()
                ));
            }

            return courses;
        }

        public bool DropCourse(int studentId, int courseId)
        {
            string query = "DELETE FROM Enrollments WHERE StudentID = @StudentID AND CourseID = @CourseID";
            MySqlParameter[] parameters = {
                new MySqlParameter("@StudentID", studentId),
                new MySqlParameter("@CourseID", courseId)
            };

            return _dbHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public List<Tuple<string, decimal?>> GetGrades(int studentId)
        {
            List<Tuple<string, decimal?>> grades = new List<Tuple<string, decimal?>>();

            string query = @"
                SELECT A.Title, S.Grade FROM Submissions S
                INNER JOIN Assignments A ON S.AssignmentID = A.AssignmentID
                WHERE S.StudentID = @StudentID";

            MySqlParameter[] parameters = {
                new MySqlParameter("@StudentID", studentId)
            };

            DataTable result = _dbHelper.ExecuteQuery(query, parameters);

            foreach (DataRow row in result.Rows)
            {
                decimal? grade = row["Grade"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["Grade"]);
                grades.Add(new Tuple<string, decimal?>(row["Title"].ToString(), grade));
            }

            return grades;
        }
    }
}
