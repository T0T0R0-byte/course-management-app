using System;

namespace CourseManagementApp
{
    public class Assignment
    {
        public int AssignmentId { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }

        public Assignment(int assignmentId, int courseId, string title, string description, DateTime? dueDate)
        {
            AssignmentId = assignmentId;
            CourseId = courseId;
            Title = title;
            Description = description;
            DueDate = dueDate;
        }
    }
}
