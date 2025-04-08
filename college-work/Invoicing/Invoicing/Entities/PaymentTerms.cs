namespace Invoicing.Entities
{
    public class PaymentTerms
    {
        public int PaymentTermsId { get; set; }

        public string Description { get; set; } = null!;

        public int DueDays { get; set; }

        // Navigation property for all invoices that have these payment terms
        public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    }
}
