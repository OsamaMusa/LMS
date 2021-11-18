using AutoMapper;
using Data.Context;
using Domain.Entities;
using Domain.IRepositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class BookCustomerRepository : IBookCustomerRepository
    {
        private readonly LMSContext _context;
        private readonly IMapper _mapper;

        public BookCustomerRepository(LMSContext context ,IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<bool> addBookCustomerAsync(BookCustomerVM bookCustomer)
        {
            await _context.BookCustomer.AddAsync(_mapper.Map<BookCustomer>(bookCustomer));
            await _context.SaveChangesAsync();
            return true;
        }
        
         public async Task<bool> deleteBookCustomerBy_B_C_ID(long CID,long BID)
         {

            BookCustomer item = GetExistingBookCustomer_B_C_ID(CID,BID).FirstOrDefault();
           
            if (item != null)
            {
                _context.BookCustomer.Remove(item);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;

        }
        public async Task<bool> deleteBookCustomerByID(long ID)
        {
            BookCustomer item = GetExistingBookCustomer(ID).FirstOrDefault();
            if (item != null)
            {
                _context.BookCustomer.Remove(item);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;

        }
        

        private IQueryable<BookCustomer> GetExistingBookCustomer(long ID) =>

         _context.BookCustomer.Where(r => r.ID == ID).AsNoTracking();
        private IQueryable<BookCustomer> GetExistingBookCustomer_B_C_ID(long CID, long BID) =>
       _context.BookCustomer.Where(r => r.BookId == BID && r.CustomerId == CID).AsNoTracking();


        public async Task<IEnumerable<BookCustomerVM>> getAllBookCustomers()
        {
            return _mapper.Map<IEnumerable<BookCustomerVM>>(_context.BookCustomer.ToList());
        }

        public async Task<BookCustomerVM> getBookCustomerByID(long ID)
        {
            return _mapper.Map<BookCustomerVM>(GetExistingBookCustomer(ID).FirstOrDefault());
        }
        public async Task<BookCustomerVM> getBookCustomerBy_C_B_ID(long CID,long BID)
        {
            return _mapper.Map<BookCustomerVM>(GetExistingBookCustomer_B_C_ID(CID,BID).FirstOrDefault());
        }


        public async Task<bool> updateBookCustomerByID(long ID, BookCustomerVM bookCustomer)
        {
            BookCustomer item = GetExistingBookCustomer(ID).FirstOrDefault();
            if (item != null)
            {
                item = _mapper.Map<BookCustomer>(bookCustomer);
                _context.BookCustomer.Update(item);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

  
    }
}
