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
            return _bookCustomerRepository.addBookCustomerAsync(_mapper.Map<BookCustomer>(bookCustomer));

        }

        public Task<bool> deleteBookCustomerByID(long ID)
        {
            return _bookCustomerRepository.deleteBookCustomerByID(ID);
        }

        
        public async Task<IEnumerable<CustomerVM>> getAllbookCustomers()
        {
            return _mapper.Map<IEnumerable<CustomerVM>>(_bookCustomerRepository.getAllBookCustomers());
        }

        public Task<IEnumerable<BookCustomerVM>> getAllBookCustomers()
        {
            throw new NotImplementedException();
        }

        public async Task<BookCustomerVM> getBookCustomerByID(long ID)
        {
            
            return _mapper.Map<BookCustomerVM>(_bookCustomerRepository.getBookCustomerByID(ID));
        }

        public Task<bool> updateBookCustomerByID(long ID, BookCustomerVM customer)
        {
            return _bookCustomerRepository.updateBookCustomerByID(ID, _mapper.Map<BookCustomer>(customer));
        }

     
    }
}
