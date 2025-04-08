using Invoicing.Data;
using Invoicing.Entities;
using Microsoft.EntityFrameworkCore;

namespace Invoicing.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly InvoicingDbContext _context;

        public InvoiceService(InvoicingDbContext context) {
            _context = context;
        }

        public void AddInvoice(Invoice invoice)
        {
            throw new NotImplementedException();
        }

        public void UpdateInvoice(Invoice invoice)
        {
            throw new NotImplementedException();
        }

        public Invoice GetInvoiceByID(int invoiceId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Invoice> GetAllInvoices()
        {
            return _context.Invoice;

        }

        public IEnumerable<Invoice> GetInvoicesByCustomer(int customerId)
        {
            var invoices = _context.Invoice.Where(i => i.CustomerId == customerId);
            return invoices;
        }

        public IEnumerable<InvoiceLineItem> GetAllLineItemsByInvoice(int invoiceId)
        {
            var lineItems = _context.InvoiceLineItem.Where(i => i.InvoiceId == invoiceId);
            return lineItems;
        }
    }
}
