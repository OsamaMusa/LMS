using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IServices
{
    public interface IBookCustomerService
    {
        public Task<IEnumerable<BookCustomerVM>> getAllBookCustomers();
        public Task<BookCustomerVM> getBookCustomerByID(long ID);
        public Task<bool> deleteBookCustomerByID(long ID);
        public Task<bool> addBookCustomer(BookCustomerVM customer);
       public Task<bool> updateBookCustomerByID(long id, BookCustomerVM customer);
    }
}
