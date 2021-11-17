using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{

   public interface ICustomerRepository 
    {
        public  Task<IEnumerable<Customer>> getAllCustomers();
        public  Task<Customer> getCustomerByID(long ID);
        public Task<bool> deleteCustomerByID(long ID);
        public Task<bool> addCustomerAsync(Customer customer);
        Task<bool> updateCustomerByID(long iD, Customer customer);
    }
}
