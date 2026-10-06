using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementApp
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        public string Status { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public Enrollment(int enrollmentId, int studentId, int courseId, string status, DateTime enrollmentDate)
        {
            EnrollmentID = enrollmentId;
            StudentID = studentId;
            CourseID = courseId;
            Status = status;
            EnrollmentDate = enrollmentDate;
        }
    }
}
