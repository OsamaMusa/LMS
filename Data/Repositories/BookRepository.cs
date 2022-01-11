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
using Microsoft.EntityFrameworkCore;



namespace Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LMSContext _context;
        private readonly IMapper _mapper;



        public BookRepository(LMSContext context, IMapper mapper)
        {
            _mapper = mapper;
            this._context = context;
        }
        private IQueryable<Book> GetExistingBook(long ID)
        {
            return _context.Books.Where(r => r.ID == ID).Include(e => e.Publisher).Include(e => e.User).AsNoTracking();
        }
        public async Task<bool> addBookAsync(BookM book)
        {



            await _context.Books.AddAsync(_mapper.Map<Book>(book));
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<BookM>> getAllBooks()
        {
            return _mapper.Map<List<Book>, List<BookM>>(_context.Books.Include(e => e.Publisher).ToList());
        }
        public async Task<IEnumerable<BookM>> getAllAvailable()
        {
            return _mapper.Map<List<Book>, List<BookM>>(_context.Books.Where(r => r.Avilable > 0).Include(e => e.Publisher).ToList());
        }



        public async Task<BookM> getBookByID(long ID)
        {
            return _mapper.Map<BookM>(GetExistingBook(ID).FirstOrDefault());
        }



        public async Task<bool> UpdateBookAsync(BookM book)
        {

            if (book != null)
            {



                Book item = GetExistingBook(book.ID).FirstOrDefault();
                item.Price = book.Price;
                item.Title = book.Title;
                item.TotalNum = book.TotalNum;
                item.Author = book.Author;
                item.Avilable = book.Avilable;



                _context.Books.Update(item);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}