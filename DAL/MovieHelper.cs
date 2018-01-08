using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentalProject_MVC_Linq_To_Sql.DAL
{
    public class MovieHelper
    {
        static DataClasses1DataContext DataB = new DataClasses1DataContext(Helper.GetConnection());

        public static List<Movie> GetMovieList()
        {
            List<Movie> MoviesList = new List<Movie>();

            var resultQuery = from Movie in DataB.Movies select Movie;
            //  Query Syntax
            foreach (var item in resultQuery)
            {
                MoviesList.Add(new Movie { Id = item.Id, Name = item.Name, Category = item.Category });
            }
            return MoviesList;
        }
        public static bool AddMovie(string Name, string Category)
        {
            Movie NewMovie = new Movie();
            NewMovie.Name = Name;
            NewMovie.Category = Category;
            DataB.Movies.InsertOnSubmit(NewMovie);
            DataB.SubmitChanges();
            return true;
        }
    }
}