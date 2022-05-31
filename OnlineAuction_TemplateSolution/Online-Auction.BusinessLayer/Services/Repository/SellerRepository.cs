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
    public class SellerRepository : ISellerRepository
    {
        private readonly OnlineAuctionDbContext _onlineAuctionDbContext;
        public SellerRepository(OnlineAuctionDbContext onlineAuctionDbContext)
        {
            _onlineAuctionDbContext = onlineAuctionDbContext;
        }

        public async Task<Seller> FindSellerById(long sellerId)
        {
            try
            {
                return await _onlineAuctionDbContext.Sellers.FindAsync(sellerId);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<IEnumerable<Bids>> GetBidsByProductId(long productId)
        {
            try
            {
                var result = _onlineAuctionDbContext.Bids.
                Where(x => x.ProductId == productId).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<IEnumerable<Seller>> ListAllSellers()
        {
            try
            {
                var result = _onlineAuctionDbContext.Sellers.
                OrderByDescending(x => x.SellerId).Take(10).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Seller> Register(Seller seller)
        {
            try
            {
                var result = await _onlineAuctionDbContext.Sellers.AddAsync(seller);
                await _onlineAuctionDbContext.SaveChangesAsync();
                return seller;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Seller> UpdateSeller(RegisterSellerViewModel model)
        {
            var seller = await _onlineAuctionDbContext.Sellers.FindAsync(model.SellerId);
            try
            {

                seller.Name = model.Name;
                seller.Phone = model.Phone;
                seller.Email = model.Email;
                seller.Address = model.Address;
                seller.IsDeleted = model.IsDeleted;
                

                _onlineAuctionDbContext.Sellers.Update(seller);
                await _onlineAuctionDbContext.SaveChangesAsync();
                return seller;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
