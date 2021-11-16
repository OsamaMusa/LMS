using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.IServices
{
    interface IBookS
    {
        BookM getBookById(int Id);
        bool addBook(string Title, string Author, float Price, int TotalNum, int Avilable);
        List<BookM> getAllBooks();
        List<BookM> getAllAvilableBooks();
        string removeBook(int Id);
        bool reserveBook(int Id);
        bool returnBook(int Id);
    }
}
