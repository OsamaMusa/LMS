using AutoMapper;
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
    public class BookCustomerService : IBookCustomerService
    {
        private readonly IBookCustomerRepository _bookCustomerRepository;
        private readonly IBookR bookR;
        private readonly ICustomerRepository _customerRepository;

        public BookCustomerService(IBookCustomerRepository bookCustomerRepository ,IBookR bookR,ICustomerRepository customerRepository)
        {
            this._bookCustomerRepository = bookCustomerRepository;
            this.bookR = bookR;
            this._customerRepository = customerRepository;
        }
        public Task<bool> addBookCustomer(BookCustomerVM bookCustomer)
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

        public  Task<IEnumerable<BookCustomerDetailsVM>> getAllBookCustomers() 
        {
            return _bookCustomerRepository.getAllBookCustomers();
        }

        public  bool reserveBookCustomer(reserveBookCustomerVM reserveBookCustomerVM)
        {
            BookM bookM = bookR.getBookByID(reserveBookCustomerVM.BookId).Result;
            CustomerVM customerVM = _customerRepository.getCustomerByID(reserveBookCustomerVM.CustomerId).Result;
            if (customerVM != null && bookM != null && bookM.Avilable > 0)
            {
                bookM.Avilable -= 1;

                if (_bookCustomerRepository.reserveBookCustomer(reserveBookCustomerVM).Result)
                {
                    if(bookR.UpdateBookAsync(bookM).Result)
                       return true;
                }
>>>>>>>>> Temporary merge branch 2
            }
            return false;

        }

        public  Task<BookCustomerDetailsVM> getBookCustomerByID(long ID)
        {

            return _bookCustomerRepository.getBookCustomerByID(ID);
        }
        public  Task<BookCustomerDetailsVM> getBookCustomerBy_C_B_ID(long CID,long BID)
        {

            return _bookCustomerRepository.getBookCustomerBy_C_B_ID(CID,BID);
        }

        public Task<bool> updateBookCustomerByID(long ID, BookCustomerVM customer)
        {
            return _bookCustomerRepository.updateBookCustomerByID(ID, customer);
        }

        public bool returnBookCustomerByID(long iD, returnBookCustomerVM bookCustomer)
        {
            BookM bookM = bookR.getBookByID(bookCustomer.BookId).Result;
            CustomerVM customerVM = _customerRepository.getCustomerByID(bookCustomer.CustomerId).Result;
            if (customerVM != null && bookM != null && !_bookCustomerRepository.getBookCustomerByID(iD).Result.isReturned)
            {
                bookM.Avilable += 1;
<<<<<<<<< Temporary merge branch 1
                _bookCustomerRepository.returnBookCustomer(bookCustomer);
                bookR.UpdateBookAsync(bookM);
                return true;
=========
                if( _bookCustomerRepository.returnBookCustomer(bookCustomer).Result)
                  if( bookR.UpdateBookAsync(bookM).Result)
                    return true;
>>>>>>>>> Temporary merge branch 2
            }
            return false;
        }
    }
}
