namespace Invoicing.Entities
{
    public class InvoiceLineItem
    {
        public int InvoiceLineItemId { get; set; }

        public double? Amount { get; set; }

        public string? Description { get; set; }

        // FK:
        public int? InvoiceId { get; set; }

        // Navigation property to the invoice this line item belongs to
        public virtual Invoice Invoice { get; set; } = null!;
    }
}
