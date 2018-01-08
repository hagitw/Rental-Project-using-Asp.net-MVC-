using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentalProject_MVC_Linq_To_Sql.DAL
{
    public class Helper
    {
        public static string GetConnection()
        {
            return "Data Source=(LocalDB)\\MSSQLLocalDB;" +
                "AttachDbFilename=C:\\Users\\TC19\\Documents\\Visual Studio 2017\\Projects\\RentalProject_MVC_Linq_To_Sql\\RentalProject_MVC_Linq_To_Sql\\App_Data\\MoviesRentalDb.mdf; " +
                "Integrated Security=True";
        }
       
    }
}