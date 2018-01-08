using RentalProject_MVC_Linq_To_Sql.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentalProject_MVC_Linq_To_Sql.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index() //download view that show all movies
        {
            List<Movie>MovieList= MovieHelper.GetMovieList();
            return View(MovieList);
        }

        public ActionResult New()  //"download form to Create a new movie"
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveMovie(string MovieName, string Category)
        {
            if (!ValidValue(Category) && !ValidValue(MovieName))
            {
                ViewBag.ErrorMessage = "Please complete allfi fields";
                return View("New");
            }
            if (!ValidValue(MovieName))
            {
                ViewBag.ErrorMessageName = "Please complete Name field";
                return View("New");
            }
            if (!ValidValue(Category))
            {
                ViewBag.ErrorMessageCategory = "Please complete Category field";
                return View("New");
            }
            bool moviexsist = MovieHelper.GetMovieList().Exists(x => x.Name == MovieName);
            if(!moviexsist)
            {
                MovieHelper.AddMovie(MovieName, Category);
                ViewBag.ErrorMessage = "The Movie Add To List";
                return View("New");
            }
            else
            {
                ViewBag.ErrorMessage = "The Movie already exists";
                return View("New");
            }
      
        }
        public bool ValidValue(string name)
        {
            return !string.IsNullOrEmpty(name);
        }
             
    }
}