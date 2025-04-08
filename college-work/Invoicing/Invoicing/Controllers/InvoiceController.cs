using Microsoft.AspNetCore.Mvc;
using Invoicing.Models;
using Invoicing.Entities;
using Invoicing.Services;

namespace Invoicing.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService _invoiceService;
        private readonly ICustomerService _customerService;

        public InvoiceController(IInvoiceService invoiceService, ICustomerService customerService)
        {
            _invoiceService = invoiceService;
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            var invoices = _invoiceService.GetAllInvoices();
            return View(invoices);
        }

        [Route("Invoice/CustomerInvoice/{customerId}")]
        public IActionResult CustomerInvoice(int customerId)
        {
            var invoices = _invoiceService.GetInvoicesByCustomer(customerId);
            var lineItems = _invoiceService.GetAllLineItemsByInvoice(invoices.First().InvoiceId);

            var customer = _customerService.GetCustomerByID(customerId);

            var viewModel = new InvoiceDetailViewModel
            {
                Customer = customer,
                Invoices = invoices,
                NewInvoice = new Invoice(),
                InvoiceLineItems = lineItems,
                NewInvoiceLineItem = new InvoiceLineItem()
            };
            
            return View(viewModel);
        }

        [Route("Invoice/LineItems/{invoiceId}")]
        public IActionResult LineItems(InvoiceDetailViewModel viewModel, int invoiceId)
        {
            var lineItems = _invoiceService.GetAllLineItemsByInvoice(invoiceId);
            viewModel.InvoiceLineItems = lineItems;
            return RedirectToAction("CustomerInvoice", viewModel);
        }
    }
}
