using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomerApp.CustomerApp.Controllers;
using CustomerApp.DTO;
using System.Web.Mvc;
using CustomerApp.Repository;

namespace CustomerApp.Tests
{
    [TestClass]
    public class CustomerControllerTest
    {
        [TestMethod]
        public void CreateActionReturnsCreateView()
        {
            var customerController = new CustomerController(GetMockService());

            var result = customerController.Create() as ViewResult;
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
        public void TestCustomerCreation()
        {
            var customerController = new CustomerController(GetMockService());

            Customer customer = new Customer();
            customer.Email = "test@test.com";
            customer.FirstName = "Myfirstname";
            customer.LastName = "Mylastname";

            var result = customerController.Create(customer) as ViewResult;
            Assert.AreEqual("Customer Record Created", result.ViewBag.Message);
        }


        private ICustomerService GetMockService()
        {
            return new MockServices.MockCustomerService();
        }
    }
}
