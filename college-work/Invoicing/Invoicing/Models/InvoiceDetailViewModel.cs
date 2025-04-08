using Invoicing.Entities;

namespace Invoicing.Models
{
    public class InvoiceDetailViewModel
    {
        public IEnumerable<Invoice> Invoices { get; set; }
        public Invoice NewInvoice { get; set; }

        public IEnumerable<InvoiceLineItem> InvoiceLineItems { get; set; }
        public InvoiceLineItem NewInvoiceLineItem { get; set; }

        public Customer Customer { get; set; }

    }
}
