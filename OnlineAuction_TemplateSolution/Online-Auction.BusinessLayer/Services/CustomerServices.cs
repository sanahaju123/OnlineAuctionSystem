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
    public class CustomerServices : ICustomerServices
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerServices(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Bids>> AllBidsByProductId(long productId)
        {
            return await _customerRepository.AllBidsByProductId(productId);
        }

        public async Task<Customer> FindCustomerById(long customerId)
        {
            return await _customerRepository.FindCustomerById(customerId);
        }

        public async Task<IEnumerable<Customer>> ListAllCustomers()
        {
            return await _customerRepository.ListAllCustomers();
        }

        public async Task<Bids> PlaceBid(Bids bids)
        {
            return await _customerRepository.PlaceBid(bids);
        }

        public async Task<Customer> Register(Customer customer)
        {
            return await _customerRepository.Register(customer);
        }

        public async Task<Customer> UpdateCustomer(RegisterCustomerViewModel model)
        {
            return await _customerRepository.UpdateCustomer(model);
        }
    }
}
