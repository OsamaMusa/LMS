using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Domain.IRepositories;
using Domain.IServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Domain.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repo;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository repo, IUserRepository userRepository, IMapper mapper)
        {
            this._repo = repo;
            this._userRepository = userRepository;
            this._mapper = mapper;
        }
        public async Task<bool> addNewBook(BookM book)
        {



            if (book != null)
            {
                UserVM user = _userRepository.getUserByID(book.userID).Result;
                long userId = -1;
                if (user != null)
                    userId = user.roleID;



                if (userId == ((int)(UserLookups.CTO)))
                    return await _repo.addBookAsync(book);



            }



            return false;



        }
        public Task<IEnumerable<BookM>> getAllAvilableBooks()
        {
            return _repo.getAllAvailable();
        }



        public Task<IEnumerable<BookM>> getAllBooks()
        {
            return _repo.getAllBooks();
        }



        public Task<BookM> getBookById(long Id)
        {
            return _repo.getBookByID(Id);
        }



        public Task<bool> removeBook(long Id)
        {

            BookM book = getBookById(Id).Result;


            if (book != null)
            {
                UserVM user = _userRepository.getUserByID(book.userID).Result;
                long userId = user.ID;
                if (user != null)
                    userId = user.roleID;
                if (userId == ((int)(UserLookups.CTO)))
                {
                    if (book.TotalNum > 0 && book.Avilable > 0)
                    {
                        book.Avilable = 0;
                        return _repo.UpdateBookAsync(book);
                    }
                }
            }

            return Task.FromResult(false);

        }


        public Task<bool> editBook(BookM book)
        {
            if (book != null)
            {
                UserVM user = _userRepository.getUserByID(book.userID).Result;


                long userId = -1;
                if (user != null)
                    userId = user.roleID;
                if (userId == ((int)(UserLookups.CTO)))
                {
                    return _repo.UpdateBookAsync(book);
                }
            }
            return Task.FromResult(false);



        }
    }
}