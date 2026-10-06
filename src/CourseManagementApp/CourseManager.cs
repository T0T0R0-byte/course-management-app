using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace CourseManagementApp
{
    internal class CourseManager
    {
        private readonly DatabaseHelper _dbHelper;

        public CourseManager()
        {
            _dbHelper = new DatabaseHelper();
        }

        public bool AddCourse(int instructorId, string title, string description, int? duration, int? maxCapacity, string syllabus)
        {
            string query = "INSERT INTO Courses (InstructorID, Title, Description, Duration, MaxCapacity, Syllabus) VALUES (@InstructorID, @Title, @Description, @Duration, @MaxCapacity, @Syllabus)";
            MySqlParameter[] parameters = {
                new MySqlParameter("@InstructorID", instructorId),
                new MySqlParameter("@Title", title),
                new MySqlParameter("@Description", description),
                new MySqlParameter("@Duration", duration ?? (object)DBNull.Value),
                new MySqlParameter("@MaxCapacity", maxCapacity ?? (object)DBNull.Value),
                new MySqlParameter("@Syllabus", syllabus)
            };

            return _dbHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool UpdateCourse(int courseId, string title, string description, int? duration, int? maxCapacity, string syllabus)
        {
            string query = "UPDATE Courses SET Title = @Title, Description = @Description, Duration = @Duration, MaxCapacity = @MaxCapacity, Syllabus = @Syllabus WHERE CourseID = @CourseID";
            MySqlParameter[] parameters = {
                new MySqlParameter("@CourseID", courseId),
                new MySqlParameter("@Title", title),
                new MySqlParameter("@Description", description),
                new MySqlParameter("@Duration", duration ?? (object)DBNull.Value),
                new MySqlParameter("@MaxCapacity", maxCapacity ?? (object)DBNull.Value),
                new MySqlParameter("@Syllabus", syllabus)
            };

            return _dbHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool DeleteCourse(int courseId)
        {
            string query = "DELETE FROM Courses WHERE CourseID = @CourseID";
            MySqlParameter[] parameters = {
                new MySqlParameter("@CourseID", courseId)
            };

            return _dbHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public List<Course> GetAllCourses()
        {
            List<Course> courses = new List<Course>();
            string query = "SELECT * FROM Courses";
            DataTable result = _dbHelper.ExecuteQuery(query);

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

        public Course GetCourseById(int courseId)
        {
            string query = "SELECT * FROM Courses WHERE CourseID = @CourseID";
            MySqlParameter[] parameters = {
                new MySqlParameter("@CourseID", courseId)
            };

            DataTable result = _dbHelper.ExecuteQuery(query, parameters);

            if (result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0];
                return new Course(
                    Convert.ToInt32(row["CourseID"]),
                    Convert.ToInt32(row["InstructorID"]),
                    row["Title"].ToString(),
                    row["Description"].ToString(),
                    row["Duration"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["Duration"]),
                    row["MaxCapacity"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["MaxCapacity"]),
                    row["Syllabus"].ToString()
                );
            }

            return null;
        }
    }
}
