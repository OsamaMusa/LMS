﻿using Domain.IServices;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookCustomerController : ControllerBase
    {

        private readonly IBookCustomerService _service;

        public BookCustomerController(IBookCustomerService service) {
            this._service = service;
        }

        // GET: api/<BookCustomerController>
        [HttpGet]
        public Task<IEnumerable<BookCustomerVM>> GetAll()
        {
            var items = _service.getAllBookCustomers();
            return items;
        }

        // GET api/<BookCustomerController>/5
        [HttpGet("{id}")]
        public Task<BookCustomerVM> getBookCustomer(long id)
        {
            return _service.getBookCustomerByID(id);
        }

        // POST api/<BookCustomerController>
        [HttpPost]
        public Task<bool> Post(BookCustomerVM bookCustomer)
        {
            return _service.addBookCustomer(bookCustomer);
        }

        // PUT api/<BookCustomerController>/5
        [HttpPut("{id}")]
        public Task<bool> Put(long id, BookCustomerVM bookCustomer)
        {
            return _service.updateBookCustomerByID(id, bookCustomer);

        }

        // DELETE api/<BookCustomerController>/5
        [HttpDelete("{id}")]
        public Task<bool> Delete(long id)
        {
            return _service.deleteBookCustomerByID(id);
        }
    }
}