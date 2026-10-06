using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace CourseManagementApp
{
    internal class InstructorManager
    {
        private readonly DatabaseHelper _dbHelper;

        public InstructorManager()
        {
            _dbHelper = new DatabaseHelper();
        }

        public List<Course> GetCoursesByInstructor(int instructorId)
        {
            List<Course> courses = new List<Course>();
            string query = "SELECT * FROM Courses WHERE InstructorID = @InstructorID";
            MySqlParameter[] parameters = {
                new MySqlParameter("@InstructorID", instructorId)
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

        public List<Tuple<int, string, string, string, string>> GetEnrolledStudents(int instructorId)
        {
            List<Tuple<int, string, string, string, string>> students = new List<Tuple<int, string, string, string, string>>();

            string query = @"
                SELECT E.EnrollmentID, U.UserID, U.FirstName, U.LastName, U.Email, C.Title
                FROM Enrollments E
                INNER JOIN Courses C ON E.CourseID = C.CourseID
                INNER JOIN Users U ON E.StudentID = U.UserID
                WHERE C.InstructorID = @InstructorID AND E.Status = 'Approved'";

            MySqlParameter[] parameters = {
                new MySqlParameter("@InstructorID", instructorId)
            };

            DataTable result = _dbHelper.ExecuteQuery(query, parameters);

            foreach (DataRow row in result.Rows)
            {
                students.Add(new Tuple<int, string, string, string, string>(
                    Convert.ToInt32(row["UserID"]),
                    row["FirstName"].ToString(),
                    row["LastName"].ToString(),
                    row["Email"].ToString(),
                    row["Title"].ToString()
                ));
            }

            return students;
        }

        public bool AssignGrade(int studentId, int assignmentId, decimal grade)
        {
            if (grade < 0 || grade > 100)
                throw new ArgumentException("Grade must be between 0 and 100.");

            string query = "UPDATE Submissions SET Grade = @Grade WHERE StudentID = @StudentID AND AssignmentID = @AssignmentID";
            MySqlParameter[] parameters = {
                new MySqlParameter("@StudentID", studentId),
                new MySqlParameter("@AssignmentID", assignmentId),
                new MySqlParameter("@Grade", grade)
            };

            return _dbHelper.ExecuteNonQuery(query, parameters) > 0;
        }
    }
}
