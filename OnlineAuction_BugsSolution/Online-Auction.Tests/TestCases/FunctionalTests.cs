using Online_Auction.BusinessLayer.Interfaces;
using Online_Auction.BusinessLayer.Services;
using Online_Auction.BusinessLayer.Services.Repository;
using Online_Auction.BusinessLayer;
using Online_Auction.Entities;
using Online_Auction.TestCases;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Online_Auction.BusinessLayer.ViewModels;
using Online_Auction.DataLayer;

namespace Online_Auction.Tests.TestCases
{
    public class FunctionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly OnlineAuctionDbContext _ngoContext;

        private readonly IProductServices _productServices;
        private readonly ICustomerServices _customerServices;

        public readonly Mock<IProductRepository> productservice = new Mock<IProductRepository>();
        public readonly Mock<ICustomerRepository> customerservice = new Mock<ICustomerRepository>();

        private readonly Product _product;
        private readonly Customer _customer;

        private readonly RegisterProductViewModel _registerProductViewModel;
        private readonly RegisterCustomerViewModel _registerCustomerViewModel;

        private static string type = "Functional";

        public FunctionalTests(ITestOutputHelper output)
        {
            _productServices = new ProductServices(productservice.Object);
            _customerServices = new CustomerServices(customerservice.Object);

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
                Username = "Donor1",
                Password = "Pass123",
                Email = "Donor1@gmail.com",
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
        }

        #region RegionProduct
        /// <summary>
        /// Test to register new Product for Online Auction System
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Register_Product()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                productservice.Setup(repos => repos.Register(_product)).ReturnsAsync(_product);
                var result = await _productServices.Register(_product);
                //Assertion
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
        /// Using the below test method Update Product by using Product Id.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Update_Product()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var _updateProduct = new RegisterProductViewModel()
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
            //Act
            try
            {
                productservice.Setup(repos => repos.UpdateProduct(_updateProduct)).ReturnsAsync(_product);
                var result = await _productServices.UpdateProduct(_updateProduct);
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
        /// Test to list all Products 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ListAll_Products()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                productservice.Setup(repos => repos.ListAllProducts());
                var result = await _productServices.ListAllProducts();
                //Assertion
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
        /// Test to find Product by Product Id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_FindProductById()
        {
            //Arrange
            var res = false;
            int productId = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                productservice.Setup(repos => repos.FindProductById(productId)).ReturnsAsync(_product); ;
                var result = await _productServices.FindProductById(productId);
                //Assertion
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
        /// Test to find Product by Category Id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_FindProductByCategoryId()
        {
            //Arrange
            var res = false;
            int categoryId = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                productservice.Setup(repos => repos.FindProductById(categoryId)).ReturnsAsync(_product); ;
                var result = await _productServices.FindProductById(categoryId);
                //Assertion
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
        #endregion 

        #region RegionCustomer
        [Fact]
        public async Task<bool> Testfor_Register_Customer()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                customerservice.Setup(repos => repos.Register(_customer)).ReturnsAsync(_customer); ;
                var result = await _customerServices.Register(_customer);
                //Assertion
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

        [Fact]
        public async Task<bool> Testfor_Update_Customer()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var _updateCustomer = new RegisterCustomerViewModel()
            {
                CustomerId = 8,
                Username = "Donor1",
                Password = "Pass123",
                Email = "Donor1@gmail.com",
                Address = "Pune,Maharashtra",
                Phone = "9435231423",
                IsDeleted = false,
            };
            //Act
            try
            {
                customerservice.Setup(repos => repos.UpdateCustomer(_updateCustomer)).ReturnsAsync(_customer);
                var result = await _customerServices.UpdateCustomer(_updateCustomer);
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

        [Fact]
        public async Task<bool> Testfor_ListAll_Customers()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                customerservice.Setup(repos => repos.ListAllCustomers());
                var result = await _customerServices.ListAllCustomers();
                //Assertion
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

        [Fact]
        public async Task<bool> Testfor_FindCustomerById()
        {
            //Arrange
            var res = false;
            int customerId = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                customerservice.Setup(repos => repos.FindCustomerById(customerId)).ReturnsAsync(_customer);
                var result = await _customerServices.FindCustomerById(customerId);
                //Assertion
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
        #endregion

    }
}