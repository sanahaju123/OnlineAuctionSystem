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
    public class ExceptionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly OnlineAuctionDbContext _onlineAuctionContext;

        private readonly IProductServices _productServices;
        private readonly ICustomerServices _customerServices;
        private readonly ISellerServices _sellerServices;

        public readonly Mock<IProductRepository> productservice = new Mock<IProductRepository>();
        public readonly Mock<ICustomerRepository> customerservice = new Mock<ICustomerRepository>();
        public readonly Mock<ISellerRepository> sellerservice = new Mock<ISellerRepository>();

        private Product _product;
        private Customer _customer;
        private Seller _seller;

        private readonly RegisterProductViewModel _registerProductViewModel;
        private readonly RegisterCustomerViewModel _registerCustomerViewModel;
        private readonly RegisterSellerViewModel _registerSellerViewModel;

        private static string type = "Exception";

        public ExceptionalTests(ITestOutputHelper output)
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
                Email = "Donor1@gmail.com",
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
        /// Test to validate if user pass the null object while registration, return null
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_NgoRegistration()
        {
            //Arrange
            bool res = false;
            _customer = null;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                customerservice.Setup(repo => repo.Register(_customer)).ReturnsAsync(_customer = null);
                var result = await _customerServices.Register(_customer);
                if (result == null)
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
        /// Test to validate if product name must be greater then 3 charactor and less than 100 charactor
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_ProductNameMinFiveCharactor()
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
                if (result != null && result.Name.Length > 5 && result.Name.Length < 100)
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
        /// Test to validate if loan Product id must be greater then 0 charactor
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_ifInvalidProductIdIsPassed()
        {
            //Arrange
            bool res = false;
            var productId = 0;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                productservice.Setup(repo => repo.FindProductById(productId)).ReturnsAsync(_product);
                var result = await _productServices.FindProductById(productId);
                if (result != null || result.ProductId > 0)
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
        /// Test to validate if start bidding amount must be greater then 0 or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Vaidate_AmountIsValidOrNot()
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
                if (result != null)
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
        /// Test to validate if Customer Id must be greater then 0 or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Vaidate_CustomerId_IsvalidorNot()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                customerservice.Setup(repo => repo.UpdateCustomer(_registerCustomerViewModel)).ReturnsAsync(_customer);
                var result = await _customerServices.UpdateCustomer(_registerCustomerViewModel);
                if (result != null && result.CustomerId > 0)
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
