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
  
    public class BookController : Controller
    {
        IBookS _service;
        ILogger _logger;
        public BookController(/*ILogger logger*/)
        {
            _service = new BookS();
           // this._logger = logger;

        }
        
        [HttpGet("/AllBooks")]
        public IActionResult GetAll()
        {
            return Json(_service.getAllBooks());
        }

        [HttpGet("/AvilableBooks")]
        public IActionResult GetAvilable()
        {
            return Json(_service.getAllBooks());
        }
        [HttpGet("{Id}")]
         public IActionResult Get(int Id)
         {
             return Json(_service.getBookById(Id));
         }
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var obj = new { Success = _service.removeBook(Id) };
            return Json(obj);
        }
        [HttpPost]
        public IActionResult Post([FromBody] BookM book)
        {
            return Json(_service.addNewBook(book));
        }
        [HttpPut("{Id}")]
        public IActionResult Put(int Id)
        {
            var obj = new { Success = _service.addBook(Id) };
            return Json(obj); ;
        }
    }
}
