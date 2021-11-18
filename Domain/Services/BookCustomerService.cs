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
        private readonly IMapper _mapper;

        public BookCustomerService(IBookCustomerRepository bookCustomerRepository, IMapper mapper)
        {
            this._bookCustomerRepository = bookCustomerRepository;
            this._mapper = mapper;
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

        public  Task<IEnumerable<BookCustomerVM>> getAllBookCustomers() 
        {
            return _bookCustomerRepository.getAllBookCustomers();
        }


        public  Task<BookCustomerVM> getBookCustomerByID(long ID)
        {

            return _bookCustomerRepository.getBookCustomerByID(ID);
        }
        public  Task<BookCustomerVM> getBookCustomerBy_C_B_ID(long CID,long BID)
        {

            return _bookCustomerRepository.getBookCustomerBy_C_B_ID(CID,BID);
        }

        public Task<bool> updateBookCustomerByID(long ID, BookCustomerVM customer)
        {
            return _bookCustomerRepository.updateBookCustomerByID(ID, customer);
        }
     
    }
}
