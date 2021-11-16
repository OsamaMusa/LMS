using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.IRepositories
{
   public  interface ICustomerRepository
    {
        public IEnumerable<Customer> getAllCustomers();
        public Customer getCustomerByID(long ID);
        public bool deleteCustomerByID(long ID);
        public bool addCustomer(Customer customer);

    }
}
