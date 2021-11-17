using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Services;
using Microsoft.Extensions.Logging;
using Domain.IServices;

namespace API.Controllers
{
  
    public class BookController : Controller
    {
        private readonly IBookS _service;
        private readonly ILogger _logger;
        public BookController( ILogger logger)
        {
            _service = new BookS();
            this._logger = logger;
        }
        public IActionResult Index()
        {
            return Ok();
        }
        public IActionResult ShowAll()
        {
            return Json(_service.getAllBooks());
        }
        public IActionResult ShowAvilable()
        {
            return Json(_service.getAllAvilableBooks());
        }
        public IActionResult GetById(int Id)
        {
            return Json(_service.getBookById(Id));
        }
        [HttpDelete]
        public IActionResult Remove(int Id)
        {
            var obj = new { Sucess = _service.removeBook(Id) };
            return Json(obj);
        }
        [HttpPost]
        public IActionResult AddNew(string Title, string Author, float Price, int TotalNum, int Avilable, int PubId,string Address, string Name)
        {
            return Json(_service.addNewBook(Title,Author,Price,TotalNum,Avilable));
        }
        [HttpPut]
        public IActionResult AddBook(int Id)
        {
            var obj = new{ Sucess= _service.addBook(Id) };
            return Json(obj); ;
        }
    }
}
