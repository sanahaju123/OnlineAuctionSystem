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
            //Write Your Code Here
            throw new NotImplementedException();
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
            //Write Your Code Here
            throw new NotImplementedException();
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
            //Write Your Code Here
            throw new NotImplementedException();
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
            //Write Your Code Here
            throw new NotImplementedException();
        }

        /// <summary>
        /// List All Customers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("customers/get/all")]
        public async Task<IEnumerable<Customer>> ListAllCustomers()
        {
            //Write Your Code Here
            throw new NotImplementedException();
        }

        /// <summary>
        /// Place a bid on the product
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("customers/place-bid")]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> PlaceBid(Bids bids)
        {
            //Write Your Code Here
            throw new NotImplementedException();
        }

        /// <summary>
        /// Customer can get all the bids on a product after the bid ends.
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("customers/get/all-bids-on-product/{productId}")]
        public async Task<IActionResult> GetBidsByProductId(long productId)
        {
            //Write Your Code Here
            throw new NotImplementedException();
        }
        #endregion
    }
}
