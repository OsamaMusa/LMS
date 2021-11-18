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
        public IActionResult GetAll()
        {
            return Json(_service.getAllBooks().Result);
        }

        [HttpGet("/AvilableBooks")]
        public IActionResult GetAvilable()
        {
            return Json(_service.getAllAvilableBooks().Result);
        }
        [HttpGet("{Id}")]
         public IActionResult Get(int Id)
         {
             return Json(_service.getBookById(Id).Result);
         }
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var obj = new { Success = _service.removeBook(Id) };
            return Json(obj);
        }
        [HttpPost]
        public Task<bool> Post([FromBody] BookM book)
        {
            return _service.addNewBook(book);
        }
        [HttpPut("{Id}")]
        public IActionResult Put(int Id)
        {
            var obj = new { Success = _service.addBook(Id) };
            return Json(obj);
        }
    }
}
