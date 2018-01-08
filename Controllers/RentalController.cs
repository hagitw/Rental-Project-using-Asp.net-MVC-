using RentalProject_MVC_Linq_To_Sql.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentalProject_MVC_Linq_To_Sql.Controllers
{
    public class RentalController : Controller
    {
        // GET: Rental
        public ActionResult Index()
        {
            List<Movie> Movies = RentalHelper.MoviesNotRented();
            return View(Movies);
        }
        [HttpPost]
        public ActionResult AddNewRental(string movie,string customerN)
        {

            if (!ValidValue(customerN) && !ValidValue(movie)) 
            {
                var ErrorMassage = new { ajaxactoin = false, message = "Please enter the name of the Customer and select movie" };
                return Json(ErrorMassage);
            }
            else if (!ValidValue(customerN))
            {
                var ErrorCustomerMassage = new { ajaxactoin = false, message = "Please enter the name of the Customer" };
                return Json(ErrorCustomerMassage);           
            }
            else  if (!ValidValue(movie))
            {
                var ErrorMovieMassage = new { ajaxactoin = false, message = "please select movie"};
                return Json(ErrorMovieMassage);          
            }
            Customer customer = CustomerHelper.GetCustomers().Where(x => x.Name == customerN).FirstOrDefault();
            Movie Movie = MovieHelper.GetMovieList().Where(x => x.Name == movie).FirstOrDefault();
            bool RentalSuccess = RentalHelper.AddRentals(customer, Movie);
            if (RentalSuccess)
            {
                var RentalIsSuccess = new { ajaxactoin = true, message = "The rent was made" };
                return Json(RentalIsSuccess);           
            }
            else
            {
                var Rentalfailed = new { ajaxactoin = false, message = "The rent failed" };
                return Json(Rentalfailed);             
            }
        }   
        public bool ValidValue(string name)
        {
            return !string.IsNullOrEmpty(name);
        }
    }
    //public class MyViewModel
    //{
    //    public List<Movie> movies { get; set; }
    //    public List<Customer> customers { get; set; }
    //}
}