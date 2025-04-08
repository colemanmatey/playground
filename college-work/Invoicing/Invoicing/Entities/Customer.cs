using System.ComponentModel.DataAnnotations;

namespace Invoicing.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string? Address1 { get; set; }

        public string? Address2 { get; set; }

        [Required]
        public string? City { get; set; } = null!;

        [Required]
        [StringLength(2)]
        public string? ProvinceOrState { get; set; } = null!;

        [Required]
        [RegularExpression(@"^(?:\d{5}(-\d{4})?|\d{3}[A-Za-z]\d[A-Za-z]\d[A-Za-z]\d)$", ErrorMessage = "Invalid Zip Code")]
        public string? ZipOrPostalCode { get; set; } = null!;

        [Required]
        [RegularExpression(@"^(?:\+1\s?)?(\(?\d{3}\)?[\s\-\.]?)\d{3}[\s\-\.]?\d{4}$")]
        public string? Phone { get; set; }

        [Required]
        public string? ContactLastName { get; set; }

        [Required]
        public string? ContactFirstName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? ContactEmail { get; set; }

        public bool IsDeleted { get; set; } = false;

        // Navigation property for all invoices related to the customer
        public virtual ICollection<Invoice> Invoices { get; set; } = [];
    }
}
