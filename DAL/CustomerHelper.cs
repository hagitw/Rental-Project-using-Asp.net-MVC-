using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentalProject_MVC_Linq_To_Sql.DAL
{
    public class CustomerHelper
    {
        static DataClasses1DataContext DataB = new DataClasses1DataContext(Helper.GetConnection());

        public static List<Customer> GetCustomers()
        {
            // Lambda Syntax
            var resultLambda = DataB.Customers.Select(x=>x);
            List<Customer> Customers = new List<Customer>();
            foreach (var item in resultLambda)
            {
                Customers.Add(new Customer { Name = item.Name, Subscription = item.Subscription, Age = item.Age });
            }
            return Customers;
        }

        public static bool AddCustomer(Customer customer)
        {
            DataB.Customers.InsertOnSubmit(customer);
            DataB.SubmitChanges();
            return true;
        }

    }
}