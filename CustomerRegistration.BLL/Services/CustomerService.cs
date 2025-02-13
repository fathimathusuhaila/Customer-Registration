using CustomerRegistration.BLL.DTOs;
using CustomerRegistration.BLL.Interfaces;
using CustomerRegistration.DAL.Entities;
using CustomerRegistration.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRegistration.BLL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<CustomerResponseDto> AddCustomer(CustomerRequestDto customerRequestDto)
        {
            try
            {
                if (customerRequestDto == null)
                {
                    throw new ArgumentNullException(nameof(customerRequestDto));
                }
                var customer = new Customer
                {
                    Name = customerRequestDto.Name,
                    Email = customerRequestDto.Email,
                    Phone = customerRequestDto.Phone,
                    Address = customerRequestDto.Address,
                    CompanyName = customerRequestDto.CompanyName,
                    JobTitle = customerRequestDto.JobTitle
                };
                var addedCustomer = await _customerRepository.AddCustomer(customer);
                return new CustomerResponseDto
                {
                    Id = addedCustomer.Id,
                    Name = addedCustomer.Name,
                    Email = addedCustomer.Email,
                    Phone = addedCustomer.Phone,
                    Address = addedCustomer.Address,
                    CompanyName = addedCustomer.CompanyName,
                    JobTitle = addedCustomer.JobTitle
                };

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task DeleteCustomer(Guid id)
        {
            try
            {
                await _customerRepository.DeleteCustomer(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<CustomerResponseDto> GetCustomer(Guid id)
        {
            try
            {
                var customer = await _customerRepository.GetCustomer(id);
                if (customer == null)
                {
                    return null;
                }
                return new CustomerResponseDto
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Email = customer.Email,
                    Phone = customer.Phone,
                    Address = customer.Address,
                    CompanyName = customer.CompanyName,
                    JobTitle = customer.JobTitle
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<CustomerResponseDto>> GetCustomers()
        {
            try
            {
                var customers = await _customerRepository.GetCustomers();
                if (customers == null)
                {
                    return new List<CustomerResponseDto>();
                }
                return customers.Select(c => new CustomerResponseDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Email = c.Email,
                    Phone = c.Phone,
                    Address = c.Address,
                    CompanyName = c.CompanyName,
                    JobTitle = c.JobTitle
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CustomerResponseDto> UpdateCustomer(Guid id, CustomerRequestDto customerRequestDto)
        {
            try
            {
                var customer = await _customerRepository.GetCustomer(id);
                if (customer == null)
                {
                    return null;
                }
                customer.Name = customerRequestDto.Name;
                customer.Email = customerRequestDto.Email;
                customer.Phone = customerRequestDto.Phone;
                customer.Address = customerRequestDto.Address;
                customer.CompanyName = customerRequestDto.CompanyName;
                customer.JobTitle = customerRequestDto.JobTitle;
                var updatedCustomer = await _customerRepository.UpdateCustomer(customer);
                return new CustomerResponseDto
                {
                    Id = updatedCustomer.Id,
                    Name = updatedCustomer.Name,
                    Email = updatedCustomer.Email,
                    Phone = updatedCustomer.Phone,
                    Address = updatedCustomer.Address,
                    CompanyName = updatedCustomer.CompanyName,
                    JobTitle = updatedCustomer.JobTitle
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
