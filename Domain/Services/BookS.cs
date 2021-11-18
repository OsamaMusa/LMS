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
            return _repo.addBookAsync(_mapper.Map<Book>(book));
        }
       /* public Task<bool> addBook(int Id)
        {
            return _repo.addBookAsync(Id);
        }*/
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

       /* public Task<bool> removeBook(int Id)
        {
            return true;
        }

        public Task<bool> reserveBook(int Id)
        {
            return true;
        }

        public Task<bool> returnBook(int Id)
        {
            return true;
        }*/
    }
}
