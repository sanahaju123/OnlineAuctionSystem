using Online_Auction.BusinessLayer.ViewModels;
using Online_Auction.DataLayer;
using Online_Auction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Auction.BusinessLayer.Services.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly OnlineAuctionDbContext _onlineAuctionDbContext;
        public ProductRepository(OnlineAuctionDbContext onlineAuctionDbContext)
        {
            _onlineAuctionDbContext = onlineAuctionDbContext;
        }

        public async Task<Product> FindProductById(long productId)
        {
            try
            {
                return await _onlineAuctionDbContext.Products.FindAsync(productId);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<IEnumerable<Product>> GetProductByCategoryId(long categoryId)
        {
            try
            {
                var result = _onlineAuctionDbContext.Products.
                Where(x => x.CategoryId == (Product.Category)categoryId).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<IEnumerable<Product>> GetProductBySellerId(long sellerId)
        {
            try
            {
                var result = _onlineAuctionDbContext.Products.
                Where(x => x.SellerId == sellerId).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<IEnumerable<Product>> ListAllProducts()
        {
            try
            {
                var result = _onlineAuctionDbContext.Products.
                OrderByDescending(x => x.ProductId).Take(10).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Product> Register(Product product)
        {
            try
            {
                var result = await _onlineAuctionDbContext.Products.AddAsync(product);
                await _onlineAuctionDbContext.SaveChangesAsync();
                return product;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Product> UpdateProduct(RegisterProductViewModel model)
        {
            var product = await _onlineAuctionDbContext.Products.FindAsync(model.ProductId);
            try
            {

                product.Name = model.Name;
                product.Price = model.Price;
                product.Quantity = model.Quantity;
                product.StartBiddingAmount = model.StartBiddingAmount;
                product.Description = model.Description;
                product.BiddingLastDate = model.BiddingLastDate;
                product.IsDeleted = model.IsDeleted;
                product.CategoryId = (Product.Category)model.CategoryId;

                _onlineAuctionDbContext.Products.Update(product);
                await _onlineAuctionDbContext.SaveChangesAsync();
                return product;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
