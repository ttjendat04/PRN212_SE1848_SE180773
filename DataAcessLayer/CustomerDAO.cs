using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using System.Numerics;
using System.Xml.Linq;

namespace DataAccessLayer
{
    public class CustomerDAO
    {
        static List<Customer> customers = new List<Customer>();
        public void GenerateSampleDataset()
        {
            customers.Add(new Customer() { Id =1, Name="Obama", Phone = "0339537689", Email="obama@gmail.com" });
            customers.Add(new Customer() { Id = 1, Name = "Putin", Phone = "0337095968", Email = "putin@gmail.com" });
            customers.Add(new Customer() { Id = 1, Name = "Trump", Phone = "0333796275", Email = "trump@gmail.com" });
            customers.Add(new Customer() { Id = 1, Name = "Shinzuabe", Phone = "0916486898", Email = "shinzuabe@gmail.com" });
            customers.Add(new Customer() { Id = 1, Name = "Tap Can Binh", Phone = "01672399413", Email = "binh@gmail.com" });

        }

        public List<Customer>GetCustomers()
        {
            return customers;   
        }

    }
}
