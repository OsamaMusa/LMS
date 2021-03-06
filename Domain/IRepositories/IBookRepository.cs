using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IBookRepository
    {
        public Task<IEnumerable<BookM>> getAllBooks();
        public Task<BookM> getBookByID(long ID);
        
        public Task<bool> addBookAsync(BookM book);
        public Task<IEnumerable<BookM>> getAllAvailable();
        public Task<bool> UpdateBookAsync(BookM book);
    }
}
