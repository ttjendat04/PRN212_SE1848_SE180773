using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Repositories;

namespace Services
{
    public class CustomerService : ICustomerRepository
    {
        ICustomerRepository ICustomerService;

        public CustomerService()
        {

            ICustomerService = new CustomerRepository();
        }

        public void GenerateSampleDataset()
        {
            ICustomerService.GenerateSampleDataset();
        }

       

        public List<Customer> GetCustomers()
        {
            return ICustomerService.GetCustomers();
        }
    }
    
   }

