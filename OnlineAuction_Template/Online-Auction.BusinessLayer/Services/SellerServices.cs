using Online_Auction.BusinessLayer.Interfaces;
using Online_Auction.BusinessLayer.Services.Repository;
using Online_Auction.BusinessLayer.ViewModels;
using Online_Auction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Auction.BusinessLayer.Services
{
    public class SellerServices : ISellerServices
    {
        private readonly ISellerRepository _sellerRepository;
        public SellerServices(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }

        public async Task<Seller> FindSellerById(long sellerId)
        {
            return await _sellerRepository.FindSellerById(sellerId);
        }

        public async Task<IEnumerable<Bids>> GetBidsByProductId(long productId)
        {
            return await _sellerRepository.GetBidsByProductId(productId);
        }

        public async Task<IEnumerable<Seller>> ListAllSellers()
        {
            return await _sellerRepository.ListAllSellers();
        }

        public async Task<Seller> Register(Seller seller)
        {
            return await _sellerRepository.Register(seller);
        }

        public async Task<Seller> UpdateSeller(RegisterSellerViewModel model)
        {
            return await _sellerRepository.UpdateSeller(model);
        }
    }
}
