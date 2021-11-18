using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IServices
{
    public interface IBookS
    {
        Task<BookM> getBookById(long Id);
        Task<bool> addNewBook(BookM book);
       // public Task<bool> addBook(int Id);
        Task<IEnumerable<BookM>> getAllBooks();
        Task<IEnumerable<BookM>> getAllAvilableBooks();
        /*bool removeBook(int Id);
        bool reserveBook(int Id);
        bool returnBook(int Id);*/
    }
}
