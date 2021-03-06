using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Services;
using Microsoft.Extensions.Logging;
using Domain.IServices;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {
        IBookService _service;
        public BookController( IBookService service)
        {
            _service = service;
        }
        
        [HttpGet("/AllBooks")]
        public IEnumerable<BookM> GetAll()
        {
            return _service.getAllBooks().Result;
        }

        [HttpGet("/AvilableBooks")]
        public IEnumerable<BookM> GetAvilable()
        {
            return _service.getAllAvilableBooks().Result;
        }
        [HttpGet]

         public BookM Get(long Id)

         {
             return _service.getBookById(Id).Result;
         }
        [HttpDelete]
        public bool Delete(long Id)
        {
           
            return _service.removeBook(Id).Result;
        }
        [HttpPost]
        public bool Post([FromBody] BookM book)
        {
            return _service.addNewBook(book).Result;
        }
        [HttpPut]
        public bool Put(BookM book)
        {
            return _service.editBook(book).Result;
        }
    }
}
