using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Domain.IRepositories;
using Domain.IServices;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ReserveBookByCustomerService : IReserveBookByCustomerService
    {
        private readonly IReserveBookByCustomerRepository _bookCustomerRepository;
        private readonly IBookRepository _bookRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IFinanceRepository _financeRepository;
        private readonly IUserRepository _userRepository;

        public ReserveBookByCustomerService(IReserveBookByCustomerRepository bookCustomerRepository, IBookRepository bookRepository, ICustomerRepository customerRepository, IFinanceRepository financeRepository ,IUserRepository userRepository)
        {
            this._bookCustomerRepository = bookCustomerRepository;
            this._bookRepository = bookRepository;
            this._customerRepository = customerRepository;
            this._financeRepository = financeRepository;
            this._userRepository = userRepository;

        }
        public Task<bool> addBookCustomer(ReserveBookByCustomerVM bookCustomer)
        {
            return _bookCustomerRepository.addBookCustomerAsync(bookCustomer);

        }

        public Task<bool> deleteBookCustomerByID(long ID)
        {
            return _bookCustomerRepository.deleteBookCustomerByID(ID);
        }

        public Task<bool> deleteBookCustomerBy_B_C_ID(long CustomerID, long BookID)
        {
            return _bookCustomerRepository.deleteBookCustomerBy_B_C_ID(CustomerID, BookID);
        }

        public Task<IEnumerable<ReserveBookByCustomerDetailsVM>> getAllBookCustomers()
        {
            return _bookCustomerRepository.getAllBookCustomers();
        }

        public string reserveBookCustomer(reserveBookCustomerVM reserveBookCustomerVM)
        {

            if (reserveBookCustomerVM == null)
                return "NF";

            BookM bookM = _bookRepository.getBookByID(reserveBookCustomerVM.BookId).Result;
            CustomerVM customerVM = _customerRepository.getCustomerByID(reserveBookCustomerVM.CustomerId).Result;


            UserVM user = _userRepository.getUserByID(reserveBookCustomerVM.ReservedUserID).Result;
            long userId = -1;
            if (user != null)
                userId = user.roleID;
            if (userId != ((int)(UserLookups.Libarian)) + 1)
                return "AD";
                   

            if (customerVM == null)
                return "CNF";
            if (customerVM.isBlocked)
                return "BL";
             if (bookM == null)
                return "BNF";
            if (bookM.Avilable <= 0)
                return "NA";

            bookM.Avilable -= 1;

            if (_bookCustomerRepository.reserveBookCustomer(reserveBookCustomerVM).Result)
            {
                if (_bookRepository.UpdateBookAsync(bookM).Result)
                    return "R";
            }

            return "NF";

        }

        public Task<ReserveBookByCustomerDetailsVM> getBookCustomerByID(long ID)
        {

            return _bookCustomerRepository.getBookCustomerByID(ID);
        }
        public Task<ReserveBookByCustomerDetailsVM> getBookCustomerBy_C_B_ID(long CID, long BID)
        {

            return _bookCustomerRepository.getBookCustomerBy_C_B_ID(CID, BID);
        }

        public Task<bool> updateBookCustomerByID(long ID, ReserveBookByCustomerVM customer)
        {
            return _bookCustomerRepository.updateBookCustomerByID(ID, customer);
        }

        public string returnBookCustomerByID(returnBookCustomerVM bookCustomer)
        {
            if (bookCustomer == null || _bookCustomerRepository.getBookCustomerBy_C_B_ID(bookCustomer.CustomerId, bookCustomer.BookId).Result == null)
                return "NF";

            BookM bookM = _bookRepository.getBookByID(bookCustomer.BookId).Result;
            CustomerVM customerVM = _customerRepository.getCustomerByID(bookCustomer.CustomerId).Result;
            FinanceTransactionsVM financeTransactions = _financeRepository.getTransByReservationID(bookCustomer.BookId).Result;

            UserVM user = _userRepository.getUserByID(bookCustomer.ReturnedUserID).Result;
            long userId = -1;
            if (user != null)
                userId = user.roleID;
            if (userId != ((int)(UserLookups.Libarian)) + 1)
                return "AD";

            if (customerVM == null)
                return "CNF";
            if (bookM == null)
                return "BNF";
            if (financeTransactions == null)
                return "FNA";

            bookM.Avilable += 1;

            if (_bookCustomerRepository.returnBookCustomer(bookCustomer).Result)
                if (_bookRepository.UpdateBookAsync(bookM).Result)
                    return "R";

            return "NF";
        }
    }
}
