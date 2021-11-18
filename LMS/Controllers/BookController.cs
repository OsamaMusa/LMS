using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Services;
using Microsoft.Extensions.Logging;
using Domain.IServices;
using Domain.Models;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {
        IBookS _service;
        ILogger _logger;
        public BookController(/*ILogger logger*/ IBookS service)
        {
            _service = service;
           // this._logger = logger;

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
         public BookM Get(int Id)
         {
             return _service.getBookById(Id).Result;
         }
        [HttpDelete("{Id}")]
        public bool Delete(int Id)
        {
           
            return _service.removeBook(Id).Result;
        }
        [HttpPost]
        public bool Post([FromBody] BookM book)
        {
            return _service.addNewBook(book).Result;
        }
        [HttpPut("{Id}")]
        public bool Put(BookM book)
        {
            return _service.editBook(book).Result;
        }
    }
}
