using CourseManager.Entities;

namespace CourseManager.Models
{
    public class CoursesViewModel
    {
        public List<Course> Courses { get; set; }
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
