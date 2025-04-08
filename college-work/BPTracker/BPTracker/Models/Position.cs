using System.ComponentModel.DataAnnotations;

namespace BPTracker.Models
{
    public class Position
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
