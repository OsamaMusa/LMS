using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.IServices
{
    public interface IBookS
    {
        BookM getBookById(int Id);
        bool addNewBook(BookM book);
        public bool addBook(int Id);
        List<BookM> getAllBooks();
        List<BookM> getAllAvilableBooks();
        bool removeBook(int Id);
        bool reserveBook(int Id);
        bool returnBook(int Id);
    }
}
