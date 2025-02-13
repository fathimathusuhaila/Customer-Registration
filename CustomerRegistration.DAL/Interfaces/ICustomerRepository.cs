using CustomerRegistration.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRegistration.DAL.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> AddCustomer(Customer customer);
        Task<Customer> GetCustomer(Guid id);
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> UpdateCustomer(Customer customer);
        Task DeleteCustomer(Guid id);

    }
}
