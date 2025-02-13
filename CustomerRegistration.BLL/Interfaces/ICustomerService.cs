using CustomerRegistration.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRegistration.BLL.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerResponseDto> AddCustomer(CustomerRequestDto customerRequestDto);
        Task<CustomerResponseDto> GetCustomer(Guid id);
        Task<IEnumerable<CustomerResponseDto>> GetCustomers();
        Task<CustomerResponseDto> UpdateCustomer(Guid id, CustomerRequestDto customerRequestDto);
        Task DeleteCustomer(Guid id);
    }
}
