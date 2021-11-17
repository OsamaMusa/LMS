using Domain.IServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services
{
    public class BookS : IBookS
    {
        public bool addNewBook(string Title, string Author, float Price, int TotalNum, int Avilable)
        {
            return true;
        }
        public bool addBook(int Id)
        {
            return true;
        }
        public List<BookM> getAllAvilableBooks()
        {
            return new List<BookM>() ;
        }

        public List<BookM> getAllBooks()
        {
            return new List<BookM>() ;
        }

        public BookM getBookById(int Id)
        {
            return new BookM();
        }

        public bool removeBook(int Id)
        {
            return true;
        }

        public bool reserveBook(int Id)
        {
            return true;
        }

        public bool returnBook(int Id)
        {
            return true;
        }
    }
}
