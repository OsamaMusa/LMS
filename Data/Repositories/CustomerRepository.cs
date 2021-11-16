using Domain.Entities;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public bool addCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public bool deleteCustomerByID(long ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> getAllCustomers()
        {
            throw new NotImplementedException();
        }

        public Customer getCustomerByID(long ID)
        {
            throw new NotImplementedException();
        }
    }
}
