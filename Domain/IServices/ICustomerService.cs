using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IServices
{
    public interface ICustomerService
    {
        public Task<IEnumerable<CustomerVM>> getAllCustomers();
        public Task<CustomerVM> getCustomerByID(long ID);
        public Task<bool> deleteCustomerByID(long ID);
        public Task<bool> addCustomer(CustomerVM customer);
        public Task<bool> updateCustomerByID(long id, CustomerVM customer);
    }
}
