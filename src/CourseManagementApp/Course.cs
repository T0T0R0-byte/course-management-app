using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementApp
{
    public class Course
    {
        public int CourseID { get; set; }
        public int InstructorID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Duration { get; set; }
        public int? MaxCapacity { get; set; } 
        public string Syllabus { get; set; }

        public Course(int courseId, int instructorId, string title, string description, int? duration, int? maxCapacity, string syllabus)
        {
            CourseID = courseId;
            InstructorID = instructorId;
            Title = title;
            Description = description;
            Duration = duration;
            MaxCapacity = maxCapacity;
            Syllabus = syllabus;
        }
    }

}
