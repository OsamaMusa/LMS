using AutoMapper;
using Data.Context;
using Domain.Entities;
using Data;
using Domain.Models;
using Domian.Entities;
using HotChocolate;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.IRepositories;

namespace Data.Repositories
{
    public class BookR:IBookR
    {
        private readonly LMSContext _context;
        private readonly IMapper _mapper;

        public BookR(LMSContext context , IMapper mapper)
        {
            _mapper = mapper;
            this._context = context;
        }
        private IQueryable<Book> GetExistingBook(long ID)
        {
            return  _context.Books.Where(r => r.ID == ID);
        }
        public async Task<bool> addBookAsync(Book book)
        {
             await _context.Books.AddAsync(book);
             await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> deleteBookByID(long ID)
        {
            Book item = GetExistingBook(ID).FirstOrDefault();
            if (item != null)
            {
                _context.Books.Remove(item);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;

        }

       

        public async Task<IEnumerable<BookM>> getAllBooks()
        {
            return _mapper.Map<List<Book>, List<BookM>>(_context.Books.ToList());
        }
        public async Task<IEnumerable<BookM>> getAllAvailable()
        {
            return _mapper.Map<List<Book>, List<BookM>>(_context.Books.Where(r => r.Avilable >0 ).ToList());
        }

        public async Task<BookM> getBookByID(long ID)
        {
            return _mapper.Map<BookM>(GetExistingBook(ID).FirstOrDefault());
        }

        public async Task<bool> UpdateBookAsync(Book book)
        { 
            
            if (book != null)
            {

                _context.Books.Update(book);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
