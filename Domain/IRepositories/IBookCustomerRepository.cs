using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IBookCustomerRepository
    {
        public Task<IEnumerable<BookCustomer>> getAllBookCustomers();
        public Task<BookCustomer> getBookCustomerByID(long ID);
        public Task<bool> deleteBookCustomerByID(long ID);
        public Task<bool> addBookCustomerAsync(BookCustomer bookCustomer);
        public Task<bool> updateBookCustomerByID(long ID, BookCustomer customer);
    }
}
