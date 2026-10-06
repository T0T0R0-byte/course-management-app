using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace CourseManagementApp
{
    internal class AdminManager
    {
        private readonly DatabaseHelper _dbHelper;

        public AdminManager()
        {
            _dbHelper = new DatabaseHelper();
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            string query = "SELECT * FROM Users";
            DataTable result = _dbHelper.ExecuteQuery(query);

            foreach (DataRow row in result.Rows)
            {
                int userId = Convert.ToInt32(row["UserID"]);
                string firstName = row["FirstName"].ToString();
                string lastName = row["LastName"].ToString();
                string email = row["Email"].ToString();
                string password = row["Password"].ToString();
                string role = row["Role"].ToString();

                switch (role)
                {
                    case "Admin":
                        users.Add(new Admin(userId, firstName, lastName, email, password));
                        break;
                    case "Instructor":
                        users.Add(new Instructor(userId, firstName, lastName, email, password));
                        break;
                    case "Student":
                        users.Add(new Student(userId, firstName, lastName, email, password));
                        break;
                }
            }

            return users;
        }

        public bool DeleteUser(int userId)
        {
            string query = "DELETE FROM Users WHERE UserID = @UserID";
            MySqlParameter[] parameters = {
                new MySqlParameter("@UserID", userId)
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
    }
}
