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

        public async Task<Customer> FindCustomerById(long customerId)
        {
            try
            {
                return await _onlineAuctionDbContext.Customers.FindAsync(customerId);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<IEnumerable<Customer>> ListAllCustomers()
        {
            try
            {
                var result = _onlineAuctionDbContext.Customers.
                OrderByDescending(x => x.CustomerId).Take(10).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Customer> Register(Customer customer)
        {
            try
            {
                var result = await _onlineAuctionDbContext.Customers.AddAsync(customer);
                await _onlineAuctionDbContext.SaveChangesAsync();
                return customer;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Customer> UpdateCustomer(RegisterCustomerViewModel model)
        {
            var customer = await _onlineAuctionDbContext.Customers.FindAsync(model.CustomerId);
            try
            {

                customer.Username = model.Username;
                customer.Password = model.Password;
                customer.Phone = model.Phone;
                customer.IsDeleted = model.IsDeleted;
                customer.Address = model.Address;
                customer.Email = model.Email;
                customer.IsDeleted = model.IsDeleted;
                

                _onlineAuctionDbContext.Customers.Update(customer);
                await _onlineAuctionDbContext.SaveChangesAsync();
                return customer;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
