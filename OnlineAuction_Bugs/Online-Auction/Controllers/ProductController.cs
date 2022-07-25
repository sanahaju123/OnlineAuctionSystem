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
   // [Route("api/[controller]")]
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
            var productExists = await _productServices.FindProductById(model.ProductId);
            if (productExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "product already exists!" });
            //New object and value for user
            Product product = new Product()
            {

                Name = model.Name,
                Description = model.Description,
                BiddingLastDate = model.BiddingLastDate,
                StartBiddingAmount = model.StartBiddingAmount,
                CategoryId = (Product.Category)model.CategoryId,
                Price = model.Price,
                Quantity = model.Quantity,
                IsDeleted = false
            };
            var result = await _productServices.Register(product);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Product creation failed! Please check product details and try again." });

            return Ok(new Response { Status = "Success", Message = "Product created successfully!" });

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
            var product = await _productServices.FindProductById(model.ProductId);
            if (product == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Product With Id = {model.ProductId} cannot be found" });
            }
            else
            {
                var result = await _productServices.UpdateProduct(model);
                return Ok(new Response { Status = "Success", Message = "Product Edited successfully!" });
            }
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
            var product = await _productServices.FindProductById(productId);
            if (product == null || product.IsDeleted == true)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Product With Id = {productId} cannot be found" });
            }
            else
            {
                RegisterProductViewModel register = new RegisterProductViewModel();
                register.ProductId = product.ProductId;
                register.Name = product.Name;
                register.Description = product.Description;
                register.BiddingLastDate = product.BiddingLastDate;
                register.StartBiddingAmount = product.StartBiddingAmount;
                register.CategoryId = (long)(Product.Category)product.CategoryId;
                register.Price = product.Price;
                register.Quantity = product.Quantity;
                register.IsDeleted = true;
                var result = await _productServices.UpdateProduct(register);
                return Ok(new Response { Status = "Success", Message = "Product deleted successfully!" });
            }
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
            var product = await _productServices.FindProductById(productId);
            if (product == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Product With Id = {productId} cannot be found" });
            }
            else
            {
                return Ok(product);
            }
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
            var product = await _productServices.GetProductByCategoryId(categoryId);
            if (product == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Product With CategoryId = {categoryId} cannot be found" });
            }
            else
            {
                return Ok(product);
            }
        }

        /// <summary>
        /// List All Products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("products/get/all")]
        public async Task<IEnumerable<Product>> ListAllProducts()
        {
            return await _productServices.ListAllProducts();
        }
        #endregion

    }
}
