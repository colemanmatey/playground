using System.ComponentModel.DataAnnotations;

namespace BPTracker.Models
{
    public class BloodPressure
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(20, 400)]
        public int Systolic { get; set; }

        [Required]
        [Range(10, 300)]
        public int Diastolic { get; set; }
        public DateOnly Date { get; set; }

        // Foreign key
        public string PositionId { get; set; }

        // Navigation property
        public Position? Position { get; set; }
    }
}
