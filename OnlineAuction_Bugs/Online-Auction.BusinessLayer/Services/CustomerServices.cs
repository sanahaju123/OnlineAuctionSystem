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

        public async Task<Customer> FindCustomerById(long customerId)
        {
            var res= await _customerRepository.FindCustomerById(customerId);
            return res;
        }

        public async Task<IEnumerable<Customer>> ListAllCustomers()
        {
            return await _customerRepository.ListAllCustomers();
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
