using AutoMapper;
using Data.Context;
using Domain.Entities;
using Domain.IRepositories;
using Domain.Models;
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

        public BookCustomerRepository(LMSContext context)
        {
            this._context = context;
        }
        public async Task<bool> addBookCustomerAsync(BookCustomer bookCustomer)
        {
            await _context.BookCustomer.AddAsync(bookCustomer);
            await _context.SaveChangesAsync();
            return true;
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
         _context.BookCustomer.Where(r => r.ID == ID);

        public async Task<IEnumerable<BookCustomer>> getAllBookCustomers()
        {
            return _context.BookCustomer.ToList();
        }

        public async Task<BookCustomer> getBookCustomerByID(long ID)
        {
            return GetExistingBookCustomer(ID).FirstOrDefault();
        }

        public async Task<bool> updateBookCustomerByID(long ID, BookCustomer bookCustomer)
        {
            BookCustomer item = GetExistingBookCustomer(ID).FirstOrDefault();
            if (item != null)
            {
                _context.BookCustomer.Update(item);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

   
    }
}
