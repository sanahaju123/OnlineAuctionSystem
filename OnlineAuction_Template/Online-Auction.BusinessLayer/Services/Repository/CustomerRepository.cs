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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly OnlineAuctionDbContext _onlineAuctionDbContext;
        public CustomerRepository(OnlineAuctionDbContext onlineAuctionDbContext)
        {
            _onlineAuctionDbContext = onlineAuctionDbContext;
        }

        public async Task<IEnumerable<Bids>> AllBidsByProductId(long productId)
        {
            //Write Your Code Here
            throw new NotImplementedException();
        }

        public async Task<Customer> FindCustomerById(long customerId)
        {
            //Write Your Code Here
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Customer>> ListAllCustomers()
        {
            //Write Your Code Here
            throw new NotImplementedException();
        }

        public async Task<Bids> PlaceBid(Bids bids)
        {
            //Write Your Code Here
            throw new NotImplementedException();
        }

        public async Task<Customer> Register(Customer customer)
        {
            //Write Your Code Here
            throw new NotImplementedException();
        }

        public async Task<Customer> UpdateCustomer(RegisterCustomerViewModel model)
        {
            //Write Your Code Here
            throw new NotImplementedException();
        }
    }
}
