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
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;
        
        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        #region productRegion
        /// <summary>
        /// Register a new product
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("products/register")]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromBody] RegisterProductViewModel model)
        {
            //Write Your Code Here
            throw new NotImplementedException();

        }

        /// <summary>
        /// Update a existing Product
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("products/update")]
        public async Task<IActionResult> UpdateProduct([FromBody] RegisterProductViewModel model)
        {
            //Write Your Code Here
            throw new NotImplementedException();
        }


        /// <summary>
        /// Delete a existing product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("products/delete/{productId}")]
        public async Task<IActionResult> DeleteProduct(long productId)
        {
            //Write Your Code Here
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get product by Id
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("products/get/{productId}")]
        public async Task<IActionResult> GetProductById(long productId)
        {
            //Write Your Code Here
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get product by Category Id
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("products/get/by-category/{categoryId}")]
        public async Task<IActionResult> GetProductByCategoryId(long categoryId)
        {
            //Write Your Code Here
            throw new NotImplementedException();
        }


        /// <summary>
        /// Get product by Seller Id
        /// </summary>
        /// <param name="SellerId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("products/get/by-seller/{sellerId}")]
        public async Task<IActionResult> GetProductBySellerId(long sellerId)
        {
            //Write Your Code Here
            throw new NotImplementedException();
        }

        /// <summary>
        /// List All Products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("products/get/all")]
        public async Task<IEnumerable<Product>> ListAllProducts()
        {
            //Write Your Code Here
            throw new NotImplementedException();
        }
        #endregion

    }
}
