using CustomerRegistration.API.ApiResponse;
using CustomerRegistration.BLL.DTOs;
using CustomerRegistration.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CustomerRegistration.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpPost]
        public async Task<IActionResult> AddCustomer(CustomerRequestDto customerRequestDto)
        {
            try
            {
                var customerResponseDto = await _customerService.AddCustomer(customerRequestDto);
                return Ok(new ApiResponse<CustomerResponseDto>("success", "registered successfully", customerResponseDto, HttpStatusCode.Created, ""));
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string>("failed", "", ex.Message, HttpStatusCode.InternalServerError, "error occured");
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
           
        }
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                var customers = await _customerService.GetCustomers();
                return Ok(new ApiResponse<IEnumerable<CustomerResponseDto>>("success", "customers retrieved successfully", customers, HttpStatusCode.OK, ""));


            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string>("failed", "", ex.Message, HttpStatusCode.InternalServerError, "error occured");
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(Guid id)
        {
            try
            {
                var customer = await _customerService.GetCustomer(id);
                return Ok(new ApiResponse<CustomerResponseDto>("success", "customer retrieved successfully", customer, HttpStatusCode.OK, ""));
            }
            catch (Exception ex)
            {
               var response = new ApiResponse<string>("failed", "", ex.Message, HttpStatusCode.InternalServerError, "error occured");
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(Guid id, CustomerRequestDto customerRequestDto)
        {
            try
            {
                var customer = await _customerService.UpdateCustomer(id, customerRequestDto);
                return Ok(new ApiResponse<CustomerResponseDto>("success", "customer updated successfully", customer, HttpStatusCode.OK, ""));
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string>("failed", "", ex.Message, HttpStatusCode.InternalServerError, "error occured");
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            try
            {
                await _customerService.DeleteCustomer(id);
                return Ok(new ApiResponse<string>("success", "customer deleted successfully", null, HttpStatusCode.OK, ""));
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string>("failed", "", ex.Message, HttpStatusCode.InternalServerError, "error occured");
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
        }
    }
}
