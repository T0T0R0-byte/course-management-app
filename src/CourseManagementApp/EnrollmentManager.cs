using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace CourseManagementApp
{
    internal class EnrollmentManager
    {
        private readonly DatabaseHelper _dbHelper;

        public EnrollmentManager()
        {
            _dbHelper = new DatabaseHelper();
        }

        public bool EnrollStudent(int studentId, int courseId)
        {
            string query = "INSERT INTO Enrollments (StudentID, CourseID, Status) VALUES (@StudentID, @CourseID, 'Pending')";
            MySqlParameter[] parameters = {
                new MySqlParameter("@StudentID", studentId),
                new MySqlParameter("@CourseID", courseId)
            };

            return _dbHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public List<Tuple<int, string, string, int, string>> GetPendingEnrollments(int instructorId)
        {
            List<Tuple<int, string, string, int, string>> enrollments = new List<Tuple<int, string, string, int, string>>();
            string query = @"
                SELECT E.EnrollmentID, U.FirstName, U.LastName, C.CourseID, C.Title 
                FROM Enrollments E
                INNER JOIN Students S ON E.StudentID = S.StudentID
                INNER JOIN Users U ON S.StudentID = U.UserID
                INNER JOIN Courses C ON E.CourseID = C.CourseID
                WHERE C.InstructorID = @InstructorID AND E.Status = 'Pending'";

            MySqlParameter[] parameters = {
                new MySqlParameter("@InstructorID", instructorId)
            };

            DataTable result = _dbHelper.ExecuteQuery(query, parameters);

            foreach (DataRow row in result.Rows)
            {
                enrollments.Add(new Tuple<int, string, string, int, string>(
                    Convert.ToInt32(row["EnrollmentID"]),
                    row["FirstName"].ToString(),
                    row["LastName"].ToString(),
                    Convert.ToInt32(row["CourseID"]),
                    row["Title"].ToString()
                ));
            }

            return enrollments;
        }

        public bool UpdateEnrollmentStatus(int enrollmentId, string newStatus)
        {
            if (newStatus != "Approved" && newStatus != "Rejected")
                throw new ArgumentException("Status must be 'Approved' or 'Rejected'.");

            string query = "UPDATE Enrollments SET Status = @Status WHERE EnrollmentID = @EnrollmentID";
            MySqlParameter[] parameters = {
                new MySqlParameter("@EnrollmentID", enrollmentId),
                new MySqlParameter("@Status", newStatus)
            };

            return _dbHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public List<Enrollment> GetEnrollmentsByCourse(int courseId)
        {
            List<Enrollment> enrollments = new List<Enrollment>();
            string query = "SELECT * FROM Enrollments WHERE CourseID = @CourseID";
            MySqlParameter[] parameters = {
                new MySqlParameter("@CourseID", courseId)
            };

            DataTable result = _dbHelper.ExecuteQuery(query, parameters);

            foreach (DataRow row in result.Rows)
            {
                enrollments.Add(new Enrollment(
                    Convert.ToInt32(row["EnrollmentID"]),
                    Convert.ToInt32(row["StudentID"]),
                    Convert.ToInt32(row["CourseID"]),
                    row["Status"].ToString(),
                    Convert.ToDateTime(row["EnrollmentDate"])
                ));
            }

            return enrollments;
        }

        public List<Enrollment> GetEnrollmentsByStudent(int studentId)
        {
            List<Enrollment> enrollments = new List<Enrollment>();
            string query = "SELECT * FROM Enrollments WHERE StudentID = @StudentID";
            MySqlParameter[] parameters = {
                new MySqlParameter("@StudentID", studentId)
            };

            DataTable result = _dbHelper.ExecuteQuery(query, parameters);

            foreach (DataRow row in result.Rows)
            {
                enrollments.Add(new Enrollment(
                    Convert.ToInt32(row["EnrollmentID"]),
                    Convert.ToInt32(row["StudentID"]),
                    Convert.ToInt32(row["CourseID"]),
                    row["Status"].ToString(),
                    Convert.ToDateTime(row["EnrollmentDate"])
                ));
            }

            return enrollments;
        }

        public bool RemoveEnrollment(int enrollmentId)
        {
            string query = "DELETE FROM Enrollments WHERE EnrollmentID = @EnrollmentID";
            MySqlParameter[] parameters = {
                new MySqlParameter("@EnrollmentID", enrollmentId)
            };

            return _dbHelper.ExecuteNonQuery(query, parameters) > 0;
        }
    }
}
