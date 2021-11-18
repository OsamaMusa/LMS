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
    public class BookS : IBookS
    { IBookR _repo;
        private readonly IMapper _mapper;
        public BookS(IBookR repo , IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public Task<bool> addNewBook(BookM book)
        {
            return _repo.addBookAsync(book);
        }
        public Task<IEnumerable<BookM>> getAllAvilableBooks()
        {
            return _repo.getAllAvailable() ;
        }

        public Task<IEnumerable<BookM>> getAllBooks()
        {
            return _repo.getAllBooks() ;
        }

        public Task<BookM> getBookById(long Id)
        {
            return _repo.getBookByID(Id);
        }

        public Task<bool> removeBook(long Id)
        {
            BookM book = getBookById(Id).Result;
            if(book.TotalNum>0 && book.Avilable > 0)
            {
                book.Avilable -= 1;
                book.TotalNum -= 1;
                return _repo.UpdateBookAsync(book);
            }

            return Task.FromResult(false);
        }

        public Task<bool> editBook(BookM book)
        {
            return _repo.UpdateBookAsync(book);
        }
    }
}
