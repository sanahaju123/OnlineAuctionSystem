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
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Bids>> GetBidsByProductId(long productId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Seller>> ListAllSellers()
        {
            throw new NotImplementedException();
        }

        public async Task<Seller> Register(Seller seller)
        {
            throw new NotImplementedException();
        }

        public async Task<Seller> UpdateSeller(RegisterSellerViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
