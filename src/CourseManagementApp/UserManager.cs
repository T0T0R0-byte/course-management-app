using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace CourseManagementApp
{
    internal class UserManager
    {
        private readonly DatabaseHelper _dbHelper;

        public UserManager()
        {
            _dbHelper = new DatabaseHelper();
        }

        public User LoginUser(string email, string password)
        {
            User user = null;
            string query = "SELECT * FROM Users WHERE Email = @Email AND Password = @Password";
            MySqlParameter[] parameters = {
                new MySqlParameter("@Email", email),
                new MySqlParameter("@Password", password)
            };

            DataTable result = _dbHelper.ExecuteQuery(query, parameters);

            if (result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0];
                int userId = Convert.ToInt32(row["UserID"]);
                string firstName = row["FirstName"].ToString();
                string lastName = row["LastName"].ToString();
                string role = row["Role"].ToString();

                switch (role)
                {
                    case "Admin":
                        user = new Admin(userId, firstName, lastName, email, password);
                        break;
                    case "Instructor":
                        user = new Instructor(userId, firstName, lastName, email, password);
                        break;
                    case "Student":
                        user = new Student(userId, firstName, lastName, email, password);
                        break;
                }
            }

            return user;
        }

        public User GetUserById(int userId)
        {
            User user = null;
            string query = "SELECT * FROM Users WHERE UserID = @UserID";
            MySqlParameter[] parameters = {
                new MySqlParameter("@UserID", userId)
            };

            DataTable result = _dbHelper.ExecuteQuery(query, parameters);

            if (result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0];
                string firstName = row["FirstName"].ToString();
                string lastName = row["LastName"].ToString();
                string email = row["Email"].ToString();
                string password = row["Password"].ToString();
                string role = row["Role"].ToString();

                switch (role)
                {
                    case "Admin":
                        user = new Admin(userId, firstName, lastName, email, password);
                        break;
                    case "Instructor":
                        user = new Instructor(userId, firstName, lastName, email, password);
                        break;
                    case "Student":
                        user = new Student(userId, firstName, lastName, email, password);
                        break;
                }
            }

            return user;
        }

        public bool AddUser(string firstName, string lastName, string email, string password, string role)
        {
            string query = "INSERT INTO Users (FirstName, LastName, Email, Password, Role) VALUES (@FirstName, @LastName, @Email, @Password, @Role)";
            MySqlParameter[] parameters = {
                new MySqlParameter("@FirstName", firstName),
                new MySqlParameter("@LastName", lastName),
                new MySqlParameter("@Email", email),
                new MySqlParameter("@Password", password),
                new MySqlParameter("@Role", role)
            };

            return _dbHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool UpdateUser(int userId, string firstName, string lastName, string email, string password, string role)
        {
            string query = "UPDATE Users SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Password = @Password, Role = @Role WHERE UserID = @UserID";
            MySqlParameter[] parameters = {
                new MySqlParameter("@UserID", userId),
                new MySqlParameter("@FirstName", firstName),
                new MySqlParameter("@LastName", lastName),
                new MySqlParameter("@Email", email),
                new MySqlParameter("@Password", password),
                new MySqlParameter("@Role", role)
            };

            return _dbHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool DeleteUser(int userId)
        {
            string query = "DELETE FROM Users WHERE UserID = @UserID";
            MySqlParameter[] parameters = {
                new MySqlParameter("@UserID", userId)
            };

            return _dbHelper.ExecuteNonQuery(query, parameters) > 0;
        }
    }
}
