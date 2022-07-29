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
            //Write Your Code Here
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Bids>> GetBidsByProductId(long productId)
        {
            //Write Your Code Here
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Seller>> ListAllSellers()
        {
            //Write Your Code Here
            throw new NotImplementedException();
        }

        public async Task<Seller> Register(Seller seller)
        {
            //Write Your Code Here
            throw new NotImplementedException();
        }

        public async Task<Seller> UpdateSeller(RegisterSellerViewModel model)
        {
            //Write Your Code Here
            throw new NotImplementedException();
        }
    }
}
