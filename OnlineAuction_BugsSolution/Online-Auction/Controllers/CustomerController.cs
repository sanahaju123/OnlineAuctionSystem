using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Auction.BusinessLayer.Interfaces;
using Online_Auction.BusinessLayer.ViewModels;
using Online_Auction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Auction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _customerServices;

        public CustomerController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        #region customerRegion
        /// <summary>
        /// Register a new customer
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("customers/register")]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromBody] RegisterCustomerViewModel model)
        {
            var customerExists = await _customerServices.FindCustomerById(model.CustomerId);
            if (customerExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Customer already exists!" });
            //New object and value for user
            Customer customer = new Customer()
            {

                Username = model.Username,
                Password = model.Password,
                Address = model.Address,
                Email = model.Email,
                Phone = model.Phone,
                IsDeleted = false
            };
            var result = await _customerServices.Register(customer);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Customer creation failed! Please check customer details and try again." });

            return Ok(new Response { Status = "Success", Message = "Customer created successfully!" });

        }

        /// <summary>
        /// Update a existing Customer
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("customers/update")]
        public async Task<IActionResult> UpdateCustomer([FromBody] RegisterCustomerViewModel model)
        {
            var customer = await _customerServices.FindCustomerById(model.CustomerId);
            if (customer == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Customer With Id = {model.CustomerId} cannot be found" });
            }
            else
            {
                var result = await _customerServices.UpdateCustomer(model);
                return Ok(new Response { Status = "Success", Message = "Customer Edited successfully!" });
            }
        }


        /// <summary>
        /// Delete a existing customer
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("customers/delete/{customerId}")]
        public async Task<IActionResult> DeleteCustomer(long customerId)
        {
            var customer = await _customerServices.FindCustomerById(customerId);
            if (customer == null || customer.IsDeleted == true)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Customer With Id = {customerId} cannot be found" });
            }
            else
            {
                RegisterCustomerViewModel register = new RegisterCustomerViewModel();
                register.CustomerId = customer.CustomerId;
                register.Phone = customer.Phone;
                register.Password = customer.Password;
                register.Username = customer.Username;
                register.Email = customer.Email;
                register.IsDeleted = true;
                var result = await _customerServices.UpdateCustomer(register);
                return Ok(new Response { Status = "Success", Message = "Customer deleted successfully!" });
            }
        }

        /// <summary>
        /// Get customer by Id
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("customers/get/{customerId}")]
        public async Task<IActionResult> GetCustomerById(long customerId)
        {
            var customer = await _customerServices.FindCustomerById(customerId);
            if (customer == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Customer With Id = {customerId} cannot be found" });
            }
            else
            {
                return Ok(customer);
            }
        }

        /// <summary>
        /// List All Customers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("customers/get/all")]
        public async Task<IEnumerable<Customer>> ListAllCustomers()
        {
            return await _customerServices.ListAllCustomers();
        }
        #endregion

    }
}
