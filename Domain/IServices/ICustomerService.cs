using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.IServices
{
    public interface ICustomerService
    {
        public IEnumerable<CustomerVM> getAllCustomers();
        public CustomerVM getCustomerByID(long ID);
        public bool deleteCustomerByID(long ID);
        public bool addCustomer(CustomerVM customer);
    }
}
