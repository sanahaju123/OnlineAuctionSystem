using Online_Auction.BusinessLayer.ViewModels;
using Online_Auction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Auction.BusinessLayer.Services.Repository
{
    public interface ICustomerRepository
    {
        Task<Customer> Register(Customer customer);
        Task<Customer> FindCustomerById(long customerId);
        Task<Customer> UpdateCustomer(RegisterCustomerViewModel model);
        Task<IEnumerable<Customer>> ListAllCustomers();
        Task<Bids> PlaceBid(Bids bids);
        Task<IEnumerable<Bids>> AllBidsByProductId(long productId);
    }
}
