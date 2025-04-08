using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace CourseManager.Entities
{
    public enum EnrolmentStatus
    {
        ConfirmationMessageNotSent,
        ConfirmationMessageSent,
        EnrollmentConfirmed,
        EnrollmentDeclined,
    }

    public enum ConfirmationResponse
    {
        Confirm,
        Decline,
    }

    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public EnrolmentStatus Status { get; set; }

        public int CourseID { get; set; }

        [ValidateNever]
        public Course Course { get; set; }
    }
}
