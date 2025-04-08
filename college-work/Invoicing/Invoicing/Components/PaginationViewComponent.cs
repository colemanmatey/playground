using Microsoft.AspNetCore.Mvc;
using Invoicing.Services;

namespace InvoicingApp.Components
{
    public class PaginationViewComponent : ViewComponent
    {

        private readonly ICustomerService _customerService;

        public PaginationViewComponent(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IViewComponentResult Invoke()
        {
            var groups = _customerService.GetCustomerGroups();
            return View(groups);
        }
    }
}
