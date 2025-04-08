using Invoicing.Entities;

namespace Invoicing.Services
{
    public interface ICustomerService
    {
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void SoftDeleteCustomer(int customerId);
        void UndoSoftDelete(int customerId);
        Customer GetCustomerByID(int customerId);
        IEnumerable<Customer> GetAllCustomers();
        IEnumerable<string> GetCustomerGroups();
    }
}
