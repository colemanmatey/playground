using Invoicing.Entities;

namespace Invoicing.Services
{
    public interface IInvoiceService
    {
        void AddInvoice(Invoice invoice);
        void UpdateInvoice(Invoice invoice);
        Invoice GetInvoiceByID(int invoiceId);
        IEnumerable<Invoice> GetAllInvoices();
        IEnumerable<Invoice> GetInvoicesByCustomer(int customerId);
        IEnumerable<InvoiceLineItem> GetAllLineItemsByInvoice(int invoiceId);
    }
}
