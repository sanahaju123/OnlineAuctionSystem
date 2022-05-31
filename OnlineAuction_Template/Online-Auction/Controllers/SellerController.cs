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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// List All Sellers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("sellers/get/all")]
        public async Task<IEnumerable<Seller>> ListAllSellers()
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
