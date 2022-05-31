using Online_Auction.BusinessLayer.ViewModels;
using Online_Auction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Auction.BusinessLayer.Services.Repository
{
    public interface ISellerRepository
    {
        Task<Seller> Register(Seller seller);
        Task<Seller> FindSellerById(long sellerId);
        Task<Seller> UpdateSeller(RegisterSellerViewModel model);
        Task<IEnumerable<Seller>> ListAllSellers();
        Task<IEnumerable<Bids>> GetBidsByProductId(long productId);
    }
}
