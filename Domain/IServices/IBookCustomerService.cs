using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IServices
{
    public interface IBookCustomerService
    {
        public Task<IEnumerable<BookCustomerDetailsVM>> getAllBookCustomers();
        public Task<BookCustomerDetailsVM> getBookCustomerByID(long ID);
        public Task<BookCustomerDetailsVM> getBookCustomerBy_C_B_ID(long CID, long BID);
        public Task<bool> deleteBookCustomerByID(long ID);
        public Task<bool> addBookCustomer(BookCustomerVM customer);
       public Task<bool> updateBookCustomerByID(long id, BookCustomerVM customer);
        bool reserveBookCustomer(reserveBookCustomerVM bookCustomer);
        bool returnBookCustomerByID(long iD, returnBookCustomerVM bookCustomer);
    }
}
