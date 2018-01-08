using RentalProject_MVC_Linq_To_Sql.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentalProject_MVC_Linq_To_Sql.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            List<Customer> CustomerList = CustomerHelper.GetCustomers();
            return View(CustomerList);
        }
        public ActionResult New()
        {
            return View();
        }
        public ActionResult SaveCustomer(Customer customer)
        {
            if (ValidObject(customer))
            {
                CustomerHelper.AddCustomer(customer);
                TempData["message"] = "The Customer Add To List";
                return View("New");
            }

            return View("New");
        }
        public bool ValidObject(Customer customer)
        {
            bool vilad = true;
            if (string.IsNullOrEmpty(customer.Name))
            {
                TempData["name"] = "please fill the name field";
                vilad = false;
            }
            if (string.IsNullOrEmpty(customer.Subscription))
            {
                TempData["subscription"] = "please fill the Subscription field";
                vilad = false;
            }
            if (customer.Age.ToString().Length < 0 || string.IsNullOrEmpty(customer.Age.ToString()))
            {
                TempData["age"] = "please fill the field";
                vilad = false;
            }
            else if (customer.Age < 18)
            {
                TempData["age"] = "You are not allowed to rent a movie (you are under 18)";
                vilad = false;
            }
            return vilad;
        }
    }
}