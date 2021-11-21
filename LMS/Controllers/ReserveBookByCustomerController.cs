using Domain.IServices;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReserveBookByCustomerController : ControllerBase
    {

        private readonly IReserveBookByCustomerService _service;

        public ReserveBookByCustomerController(IReserveBookByCustomerService service) {
            this._service = service;
        }

        // GET: api/<BookCustomerController>
        [HttpGet("getReservations")]
        public Task<IEnumerable<ReserveBookByCustomerDetailsVM>> GetAll()
        {
            var items = _service.getAllBookCustomers();
            return items;
        }

        // GET api/<BookCustomerController>/5
        [HttpGet("getReserve/{id}")]
        public Task<ReserveBookByCustomerDetailsVM> getReservationsByID(long id)
        {
            return _service.getBookCustomerByID(id);
        }

        // POST api/<BookCustomerController>
        [HttpPost("/ReserveBook")]
        public async Task<bool> ReserveBook(reserveBookCustomerVM bookCustomer)
        {
            bookCustomer.reserveTime = DateTime.UtcNow ;
            return _service.reserveBookCustomer(bookCustomer);
        }
        [HttpPost("/ReturnBook")]
        public async Task<bool> ReturnBook(returnBookCustomerVM bookCustomer)
        {
            bookCustomer.isReturned = true;
            bookCustomer.returnedTime = DateTime.UtcNow;
             return _service.returnBookCustomerByID(bookCustomer.ID , bookCustomer);
        } 

        // PUT api/<BookCustomerController>/5
        [HttpPut("updateReserve/{id}")]
        public Task<bool> updateReserve(long id, ReserveBookByCustomerVM bookCustomer)
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
