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
        public Task<IEnumerable<BookCustomerDetailsVM>> getAllBookCustomers();
        public Task<BookCustomerDetailsVM> getBookCustomerByID(long ID);
        public Task<BookCustomerDetailsVM> getBookCustomerBy_C_B_ID(long CID,long BID);
        public Task<bool> deleteBookCustomerByID(long ID);
        public  Task<bool> deleteBookCustomerBy_B_C_ID(long CID, long BID);
        public Task<bool> addBookCustomerAsync(BookCustomerVM bookCustomer);
        public Task<bool> updateBookCustomerByID(long ID, BookCustomerVM customer);
        public Task<bool> reserveBookCustomer(reserveBookCustomerVM reserveBookCustomerVM);
       public  Task<bool> returnBookCustomer(returnBookCustomerVM returnBookCustomerVM);
    }
}
