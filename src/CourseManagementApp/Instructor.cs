using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;

namespace CourseManagementApp
{
    public class Instructor : User
    {
        private CourseManager courseManager;
        private EnrollmentManager enrollmentManager;
        private InstructorManager instructorManager;
        private AssignmentManager assignmentManager;

        public Instructor(int userId, string firstName, string lastName, string email, string password)
            : base(userId, firstName, lastName, email, password, "Instructor")
        {
            courseManager = new CourseManager();
            enrollmentManager = new EnrollmentManager();
            instructorManager = new InstructorManager();
            assignmentManager = new AssignmentManager();
        }

        public List<Course> GetMyCourses()
        {
            return instructorManager.GetCoursesByInstructor(UserID);
        }

        public List<Tuple<int, string, string, string, string>> GetEnrolledStudents(int courseId)
        {
            return instructorManager.GetEnrolledStudents(UserID);
        }

        public bool AssignGrade(int studentId, int assignmentId, decimal grade)
        {
            return instructorManager.AssignGrade(studentId, assignmentId, grade);
        }

        public bool AddAssignment(int courseId, string title, string description, DateTime dueDate)
        {
            return assignmentManager.AddAssignment(courseId, title, description, dueDate);
        }

        public List<Assignment> GetAssignmentsByCourse(int courseId)
        {
            return assignmentManager.GetAssignmentsByCourse(courseId);
        }

        public List<Tuple<int, string, string, int, string>> GetPendingEnrollments()
        {
            return enrollmentManager.GetPendingEnrollments(UserID);
        }

        public bool UpdateEnrollmentStatus(int enrollmentId, string status)
        {
            return enrollmentManager.UpdateEnrollmentStatus(enrollmentId, status);
        }
    }
}
