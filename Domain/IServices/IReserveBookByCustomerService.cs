using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IServices
{
    public interface IReserveBookByCustomerService
    {
        public Task<IEnumerable<ReserveBookByCustomerDetailsVM>> getAllBookCustomers();
        public Task<ReserveBookByCustomerDetailsVM> getBookCustomerByID(long ID);
        public Task<ReserveBookByCustomerDetailsVM> getBookCustomerBy_C_B_ID(long CID, long BID);
        public Task<bool> deleteBookCustomerByID(long ID);
        public Task<bool> addBookCustomer(ReserveBookByCustomerVM customer);
       public Task<bool> updateBookCustomerByID(long id, ReserveBookByCustomerVM customer);
       public string reserveBookCustomer(reserveBookCustomerVM bookCustomer);
       public string returnBookCustomerByID( returnBookCustomerVM bookCustomer);
    }
}
