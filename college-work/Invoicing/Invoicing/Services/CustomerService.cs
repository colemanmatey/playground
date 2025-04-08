using Invoicing.Entities;
using Invoicing.Data;

namespace Invoicing.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly InvoicingDbContext _context;

        public CustomerService(InvoicingDbContext context)
        {
            _context = context;
        }

        public void AddCustomer(Customer customer)
        {
            _context.Customer.Add(customer);
            _context.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Customer.Update(customer);
            _context.SaveChanges();
        }

        public void SoftDeleteCustomer(int customerId)
        {
            var customer = _context.Customer.Find(customerId);
            customer.IsDeleted = true;
            _context.Customer.Update(customer);
            _context.SaveChanges();
        }

        public void UndoSoftDelete(int customerId)
        {
            var customer = _context.Customer.Find(customerId);
            customer.IsDeleted = false;
            _context.Customer.Update(customer);
            _context.SaveChanges();
        }

        public Customer GetCustomerByID(int customerId)
        {
            return _context.Customer.Find(customerId);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _context.Customer;
        }

        public IEnumerable<string> GetCustomerGroups()
        {
            return new List<string> { "A - E", "F - K", "L - R", "S - Z" };
        }

    }
}
