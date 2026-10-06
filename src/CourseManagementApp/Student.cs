using System;
using System.Collections.Generic;

namespace CourseManagementApp
{
    public class Student : User
    {
        private StudentManager studentManager;
        private EnrollmentManager enrollmentManager;

        public int StudentID { get; set; }

        public Student(int userId, string firstName, string lastName, string email, string password)
            : base(userId, firstName, lastName, email, password, "Student")
        {
            StudentID = userId;
            studentManager = new StudentManager();
            enrollmentManager = new EnrollmentManager();
        }

        public List<Course> GetAvailableCourses()
        {
            return studentManager.GetAvailableCourses(StudentID);
        }

        public bool EnrollInCourse(int courseId)
        {
            return enrollmentManager.EnrollStudent(StudentID, courseId);
        }

        public List<Course> GetEnrolledCourses()
        {
            return studentManager.GetEnrolledCourses(StudentID);
        }

        public bool DropCourse(int courseId)
        {
            return studentManager.DropCourse(StudentID, courseId);
        }

        public List<Tuple<string, decimal?>> GetGrades()
        {
            return studentManager.GetGrades(StudentID);
        }
    }
}
