using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentalProject_MVC_Linq_To_Sql.DAL
{
    public class RentalHelper
    {
        static DataClasses1DataContext DataB = new DataClasses1DataContext(Helper.GetConnection());

        public static List<Rental> GetRentalList()
        {
            List<Rental> RentalList = DataB.Rentals.ToList();
            return RentalList;
        }

        public static List<Movie> MoviesNotRented()
        {
            List<Rental> RentalList = DataB.Rentals.ToList();
            List<Movie> Movies = DataB.Movies.ToList();
            List<Movie> MoviesNotRented = new List<Movie>();
            foreach (var movie in Movies)
            {
                if (!RentalList.Exists(x=>x.MovieId==movie.Id))
                {
                    MoviesNotRented.Add(movie);
                }
            }
            return MoviesNotRented;   
        }
        public static bool AddRentals(Customer customer,Movie movie)
        {
            Rental NewRental = new Rental();
            NewRental.CustomerId = customer.Id;
            NewRental.MovieId = movie.Id;
            DataB.Rentals.InsertOnSubmit(NewRental);
            DataB.SubmitChanges();
            return true;

        }
    }
}