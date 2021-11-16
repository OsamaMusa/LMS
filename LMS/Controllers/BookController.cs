using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Services;

namespace API.Controllers
{
  
    public class BookController : Controller
    {
        BookS service;
        public BookController()
        {
            service = new BookS();
        }
        public IActionResult Index()
        {
            return Ok();
        }
        public IActionResult ShowAll()
        {
            return Json(service.getAllBooks());
        }
        public IActionResult ShowAvilable()
        {
            return Json(service.getAllAvilableBooks());
        }
        public IActionResult GetById(int Id)
        {
            return Json(service.getBookById(Id));
        }
        public IActionResult Remove(int Id)
        {
            return Json(service.removeBook(Id));
        }
    }
}
