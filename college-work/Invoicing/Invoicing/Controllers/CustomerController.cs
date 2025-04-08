using Microsoft.AspNetCore.Mvc;
using Invoicing.Entities;
using Invoicing.Services;

namespace Invoicing.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            var customers = _customerService.GetAllCustomers().Where<Customer>(c => c.IsDeleted == false);
            return View(customers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Customer());
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                // Save the customer to the database
                _customerService.AddCustomer(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        [HttpGet]
        [Route("Customer/Edit/{customerId}")]
        public IActionResult Edit(int customerId)
        {
            var customer = _customerService.GetCustomerByID(customerId);
            return View(customer);
        }

        [HttpPost]
        [Route("Customer/Edit/{customerId}")]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerService.UpdateCustomer(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }


        private void SetCustomerDeleteMessage(string message, int? customerId)
        {
            TempData["Message"] = message;
            TempData["CustomerId"] = customerId;
        }

        [HttpPost]
        [Route("Customer/SoftDelete/{customerId}")]
        public IActionResult SoftDelete(int customerId)
        {
            _customerService.SoftDeleteCustomer(customerId);
            SetCustomerDeleteMessage("Customer deleted successfully!", customerId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("Customer/UndoSoftDelete/{customerId}")]
        public IActionResult UndoSoftDelete(int customerId)
        {
            _customerService.UndoSoftDelete(customerId);
            SetCustomerDeleteMessage("Customer restored successfully!", null);
            return RedirectToAction("Index");
        }
    }
}
