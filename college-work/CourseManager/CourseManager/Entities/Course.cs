using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManager.Entities
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Instructor { get; set; }

        [Required]
        public DateOnly StartDate { get; set; }

        [Required]
        [RegularExpression(@"^\d[A-Z]\d{2}$", ErrorMessage="The room number must be in the format: a single digit, a single capital letter, and 2 digits, e.g. 3G15, 1C07")]
        public string RoomNumber { get; set; }

        // Navigation property
        public List<Student> Students { get; set; }
    }
}
