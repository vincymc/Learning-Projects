using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomerApp.DTO;
using CustomerApp.Repository;

namespace CustomerApp.CustomerApp.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerService CustomerService { get; set; }

        public CustomerController()
        {
            CustomerService = new CustomerService();
        }


        public CustomerController(ICustomerService customerService)
        {
            CustomerService = customerService;
        }
        

        // GET : Customer/Create
        public ActionResult Create()
        {
            return View("Create");
        }


        // POST : Customer/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            string responceMessage = string.Empty;

            if (ModelState.IsValid)
            {
                try
                {
                    CustomerService.Add(customer);
                    responceMessage = "Customer Record Created";
                }
                catch (Exception ex)
                {
                    responceMessage = "Error : " + ex.Message;
                }
            }
            else
            {
                responceMessage = "Invalid Input";
            }

            ViewBag.Message = responceMessage;
            return View("Create");

        }

    }
}