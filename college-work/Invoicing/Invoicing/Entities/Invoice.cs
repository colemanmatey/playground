namespace Invoicing.Entities
{
    public class Invoice
    {
        public int InvoiceId { get; set; }

        public DateTime? InvoiceDate { get; set; }

        public DateTime? InvoiceDueDate
        {
            get
            {
                return InvoiceDate?.AddDays(Convert.ToDouble(PaymentTerms?.DueDays));
            }
        }

        public double? PaymentTotal { get; set; } = 0.0;

        public DateTime? PaymentDate { get; set; }

        // FK:
        public int PaymentTermsId { get; set; }

        // FK:
        public int CustomerId { get; set; }

        // Navigation property to the customer this invoice belongs to
        public virtual Customer Customer { get; set; } = null!;

        // Navigation property for all line items related to the invoice
        public virtual ICollection<InvoiceLineItem> InvoiceLineItems { get; set; } = [];

        // Navigation property for the payment terms associated with this invoice
        public virtual PaymentTerms PaymentTerms { get; set; } = null!;
    }
}
