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
    public class SellerController : ControllerBase
    {
        private readonly ISellerServices _sellerServices;

        public SellerController(ISellerServices sellerServices)
        {
            _sellerServices = sellerServices;
        }

        #region SellerRegion
        /// <summary>
        /// Register a new Seller
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("sellers/register")]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromBody] RegisterSellerViewModel model)
        {
            var sellerExists = await _sellerServices.FindSellerById(model.SellerId);
            if (sellerExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Seller already exists!" });
            //New object and value for user
            Seller seller = new Seller()
            {

                Name = model.Name,
                Address = model.Address,
                Email = model.Email,
                Phone = model.Phone,
                IsDeleted = false
            };
            var result = await _sellerServices.Register(seller);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Seller creation failed! Please check seller details and try again." });

            return Ok(new Response { Status = "Success", Message = "Seller created successfully!" });

        }

        /// <summary>
        /// Update a existing Seller
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("sellers/update")]
        public async Task<IActionResult> UpdateSeller([FromBody] RegisterSellerViewModel model)
        {
            var seller = await _sellerServices.FindSellerById(model.SellerId);
            if (seller == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Seller With Id = {model.SellerId} cannot be found" });
            }
            else
            {
                var result = await _sellerServices.UpdateSeller(model);
                return Ok(new Response { Status = "Success", Message = "Seller Edited successfully!" });
            }
        }


        /// <summary>
        /// Delete a existing seller
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("sellers/delete/{sellerId}")]
        public async Task<IActionResult> DeleteSeller(long sellerId)
        {
            var seller = await _sellerServices.FindSellerById(sellerId);
            if (seller == null || seller.IsDeleted == true)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Seller With Id = {sellerId} cannot be found" });
            }
            else
            {
                RegisterSellerViewModel register = new RegisterSellerViewModel();
                register.SellerId = seller.SellerId;
                register.Phone = seller.Phone;
                register.Name = seller.Name;
                register.Email = seller.Email;
                register.IsDeleted = true;
                var result = await _sellerServices.UpdateSeller(register);
                return Ok(new Response { Status = "Success", Message = "Seller deleted successfully!" });
            }
        }

        /// <summary>
        /// Get seller by Id
        /// </summary>
        /// <param name="SellerId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("sellers/get/{sellerId}")]
        public async Task<IActionResult> GetSellerById(long sellerId)
        {
            var seller = await _sellerServices.FindSellerById(sellerId);
            if (seller == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Seller With Id = {sellerId} cannot be found" });
            }
            else
            {
                return Ok(seller);
            }
        }

        /// <summary>
        /// Get bids by product Id
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("sellers/get/bids-on-product/{productId}")]
        public async Task<IActionResult> GetBidsByProductId(long productId)
        {
            var product = await _sellerServices.GetBidsByProductId(productId);
            if (product == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Bid With productId = {productId} cannot be found" });
            }
            else
            {
                return Ok(product);
            }
        }

        /// <summary>
        /// List All Sellers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("sellers/get/all")]
        public async Task<IEnumerable<Seller>> ListAllSellers()
        {
            return await _sellerServices.ListAllSellers();
        }
        #endregion

    }
}
