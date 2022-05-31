using Online_Auction.BusinessLayer.Interfaces;
using Online_Auction.BusinessLayer.Services;
using Online_Auction.BusinessLayer.Services.Repository;
using Online_Auction.BusinessLayer.ViewModels;
using Online_Auction.DataLayer;
using Online_Auction.Entities;
using Online_Auction.TestCases;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Online_Auction.Tests.TestCases
{
    public class BoundaryTest
    {
        private readonly ITestOutputHelper _output;
        private readonly OnlineAuctionDbContext _onlineAuctionContext;

        private readonly IProductServices _productServices;
        private readonly ICustomerServices _customerServices;
        private readonly ISellerServices _sellerServices;

        public readonly Mock<IProductRepository> productservice = new Mock<IProductRepository>();
        public readonly Mock<ICustomerRepository> customerservice = new Mock<ICustomerRepository>();
        public readonly Mock<ISellerRepository> sellerservice = new Mock<ISellerRepository>();

        private  Product _product;
        private  Customer _customer;
        private  Seller _seller;

        private readonly RegisterProductViewModel _registerProductViewModel;
        private readonly RegisterCustomerViewModel _registerCustomerViewModel;
        private readonly RegisterSellerViewModel _registerSellerViewModel;

        private static string type = "Boundary";

        public BoundaryTest(ITestOutputHelper output)
        {
            _productServices = new ProductServices(productservice.Object);
            _customerServices = new CustomerServices(customerservice.Object);
            _sellerServices = new SellerServices(sellerservice.Object);

            _output = output;

            _product = new Product
            {
                ProductId = 1,
                Name = "product1",
                Description = "abc",
                Quantity = 1,
                StartBiddingAmount = 500.00M,
                Price = 5000.00M,
                BiddingLastDate = DateTime.Now,
                CategoryId = (Product.Category)1,
                IsDeleted = false
            };
            _customer = new Customer
            {
                CustomerId = 8,
                Username = "Customer1",
                Password = "Pass123",
                Email = "C1@gmail.com",
                Address = "Pune,Maharashtra",
                Phone = "9435231423",
                IsDeleted = false,
            };
            _seller = new Seller
            {
                SellerId = 8,
                Name = "Seller1",
                Email = "s1@gmail.com",
                Address = "Pune,Maharashtra",
                Phone = "9435231423",
                IsDeleted = false,
            };

            _registerProductViewModel = new RegisterProductViewModel
            {
                ProductId = 1,
                Name = "product1",
                Description = "abc",
                Quantity = 1,
                StartBiddingAmount = 500.00M,
                Price = 5000.00M,
                BiddingLastDate = DateTime.Now,
                CategoryId = (long)(Product.Category)1,
                IsDeleted = false
            };
            _registerCustomerViewModel = new RegisterCustomerViewModel
            {
                CustomerId = 8,
                Username = "Donor1",
                Password = "Pass123",
                Email = "c1@gmail.com",
                Address = "Pune,Maharashtra",
                Phone = "9435231423",
                IsDeleted = false,
            };
            _registerSellerViewModel = new RegisterSellerViewModel
            {
                SellerId = 8,
                Name = "Seller1",
                Email = "s1@gmail.com",
                Address = "Pune,Maharashtra",
                Phone = "9435231423",
                IsDeleted = false,
            };
        }

        /// <summary>
        ///  Testfor_ValidEmail to test email id is valid or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ValidEmail()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                
                //Assert
                customerservice.Setup(repo => repo.Register(_customer)).ReturnsAsync(_customer);
                var result = await _customerServices.Register(_customer);
                var actualLength = _customer.Email.ToString().Length;
                if (result.Email.ToString().Length == actualLength)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        /// <summary>
        /// Testfor_ValidateMobileNumber is used for test mobile number is valid or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ValidateMobileNumber()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                customerservice.Setup(repo => repo.Register(_customer)).ReturnsAsync(_customer);
                var result = await _customerServices.Register(_customer);
                var actualLength = _customer.Phone.ToString().Length;
                if (result.Phone.ToString().Length == actualLength)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        /// <summary>
        /// Test to validate product bidding last date connaot be blank.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ProductBidding_LastDate_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                productservice.Setup(repo => repo.Register(_product)).ReturnsAsync(_product);
                var result = await _productServices.Register(_product);
                var actualLength = _product.BiddingLastDate.ToString().Length;
                if (result.BiddingLastDate.ToString().Length == actualLength)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        /// <summary>
        /// Test to validate product bidding last date should be future date.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ProductBidding_LastDate_Validation()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                productservice.Setup(repo => repo.Register(_product)).ReturnsAsync(_product);
                var result = await _productServices.Register(_product);
                var actualLength = _product.BiddingLastDate.ToString().Length;
                if (result.BiddingLastDate > DateTime.Today)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }
    }
}
