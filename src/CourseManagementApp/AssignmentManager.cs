using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace CourseManagementApp
{
    internal class AssignmentManager
    {
        private readonly DatabaseHelper _dbHelper;

        public AssignmentManager()
        {
            _dbHelper = new DatabaseHelper();
        }

        // ✅ Add Assignment
        public bool AddAssignment(int courseId, string title, string description, DateTime dueDate)
        {
            string query = "INSERT INTO Assignments (CourseID, Title, Description, DueDate) VALUES (@CourseID, @Title, @Description, @DueDate)";
            MySqlParameter[] parameters = {
                new MySqlParameter("@CourseID", courseId),
                new MySqlParameter("@Title", title),
                new MySqlParameter("@Description", description),
                new MySqlParameter("@DueDate", dueDate)
            };

            return _dbHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        // ✅ Get Assignments for a Course
        public List<Assignment> GetAssignmentsByCourse(int courseId)
        {
            List<Assignment> assignments = new List<Assignment>();
            string query = "SELECT * FROM Assignments WHERE CourseID = @CourseID";
            MySqlParameter[] parameters = {
                new MySqlParameter("@CourseID", courseId)
            };

            DataTable result = _dbHelper.ExecuteQuery(query, parameters);
            foreach (DataRow row in result.Rows)
            {
                assignments.Add(new Assignment(
                    Convert.ToInt32(row["AssignmentID"]),
                    Convert.ToInt32(row["CourseID"]),
                    row["Title"].ToString(),
                    row["Description"].ToString(),
                    row["DueDate"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(row["DueDate"])
                ));
            }

            return assignments;
        }
    }
}
