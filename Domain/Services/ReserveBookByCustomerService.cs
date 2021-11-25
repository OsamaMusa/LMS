﻿using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;
using Domain.IServices;
using Domain.Models;
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

        public ReserveBookByCustomerService(IReserveBookByCustomerRepository bookCustomerRepository ,IBookRepository bookRepository, ICustomerRepository customerRepository,IFinanceRepository financeRepository)
        {
            this._bookCustomerRepository = bookCustomerRepository;
            this._bookRepository = bookRepository;
            this._customerRepository = customerRepository;
            this._financeRepository = financeRepository;
        }
        public Task<bool> addBookCustomer(ReserveBookByCustomerVM bookCustomer)
        {
            return _bookCustomerRepository.addBookCustomerAsync(bookCustomer);

        }

        public Task<bool> deleteBookCustomerByID(long ID)
        {
            return _bookCustomerRepository.deleteBookCustomerByID(ID);
        }

        public Task<bool> deleteBookCustomerBy_B_C_ID(long CustomerID,long BookID)
        {
            return _bookCustomerRepository.deleteBookCustomerBy_B_C_ID(CustomerID, BookID);
        }

        public  Task<IEnumerable<ReserveBookByCustomerDetailsVM>> getAllBookCustomers() 
        {
            return _bookCustomerRepository.getAllBookCustomers();
        }

        public  bool reserveBookCustomer(reserveBookCustomerVM reserveBookCustomerVM)
        {
            if (reserveBookCustomerVM == null)
                return false;
            BookM bookM = _bookRepository.getBookByID(reserveBookCustomerVM.BookId).Result;
            CustomerVM customerVM = _customerRepository.getCustomerByID(reserveBookCustomerVM.CustomerId).Result;
            if (customerVM != null && bookM != null && bookM.Avilable > 0 )
            {
                bookM.Avilable -= 1;

                if (_bookCustomerRepository.reserveBookCustomer(reserveBookCustomerVM).Result)
                {
                    if(_bookRepository.UpdateBookAsync(bookM).Result)
                       return true;
                }
            }
            return false;

        }

        public  Task<ReserveBookByCustomerDetailsVM> getBookCustomerByID(long ID)
        {

            return _bookCustomerRepository.getBookCustomerByID(ID);
        }
        public  Task<ReserveBookByCustomerDetailsVM> getBookCustomerBy_C_B_ID(long CID,long BID)
        {

            return _bookCustomerRepository.getBookCustomerBy_C_B_ID(CID,BID);
        }

        public Task<bool> updateBookCustomerByID(long ID, ReserveBookByCustomerVM customer)
        {
            return _bookCustomerRepository.updateBookCustomerByID(ID, customer);
        }

        public bool returnBookCustomerByID(long Id, returnBookCustomerVM bookCustomer)
        {
            if (bookCustomer == null)
                return false;
            BookM bookM = _bookRepository.getBookByID(bookCustomer.BookId).Result;
            CustomerVM customerVM = _customerRepository.getCustomerByID(bookCustomer.CustomerId).Result;
            FinanceTransactionsVM financeTransactions = _financeRepository.getTransByReservationID(Id).Result;
            if (customerVM != null && bookM != null && !_bookCustomerRepository.getBookCustomerByID(Id).Result.isReturned && financeTransactions != null)
            {
                bookM.Avilable += 1;

                if(_bookCustomerRepository.returnBookCustomer(bookCustomer).Result)
                    if(_bookRepository.UpdateBookAsync(bookM).Result)
                       return true;

            }
            return false;
        }
    }
}
