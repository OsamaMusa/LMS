using Domain.IServices;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace API.Controllers
{
    [Authorize]
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
        public IActionResult GetAll()
        {
            var items = _service.getAllBookCustomers().Result;
            if(items != null)
               return Ok(items);
            return BadRequest();
        }

        // GET api/<BookCustomerController>/5
        [HttpGet("getReserve/{id}")]
        public IActionResult getReservationsByID(long id)
        {
            var res =  _service.getBookCustomerByID(id).Result;
            if (res != null)
                return Ok(res);
            return NoContent();
        }

        // POST api/<BookCustomerController>
        [HttpPost("/ReserveBook")]
        public IActionResult ReserveBook(reserveBookCustomerVM bookCustomer)
        {
           // bookCustomer.reserveTime = DateTime.UtcNow ;
            var res = _service.reserveBookCustomer(bookCustomer);
            if (res.CompareTo("AD") == 0)
                return BadRequest("Acsess Denied");
            else if (res.CompareTo("NF") == 0)
                return NotFound("Reserve Not Found");
            else if (res.CompareTo("BNF") == 0)
                return NotFound("Book Not Found");
            else if (res.CompareTo("CNF") == 0)
                return NotFound("Customer Not Found");
            else if (res.CompareTo("BL") == 0)
                return BadRequest("Customer Was Blocked");
            else
                return Ok("Reserved");

        }
        [HttpPost("/ReturnBook")]
        public IActionResult ReturnBook(returnBookCustomerVM bookCustomer)
        {

            var res = _service.returnBookCustomerByID( bookCustomer);
            if (res.CompareTo("AD") == 0)
                return BadRequest("Acsess Denied");
            else if (res.CompareTo("NF") == 0)
                return NotFound("Returned Not Found");
            else if (res.CompareTo("BNF") == 0)
                return NotFound("Book Not Found");
            else if (res.CompareTo("CNF") == 0)
                return NotFound("Customer Not Found");
            else if (res.CompareTo("FNA") == 0)
                return BadRequest("Payment Required");
            else
                return Ok("Returned");
           
        } 

        // PUT api/<BookCustomerController>/5
/*        [HttpPut("updateReserve/{id}")]
        public IActionResult updateReserve(long id, ReserveBookByCustomerVM bookCustomer)
        {
            var res=  _service.updateBookCustomerByID(id, bookCustomer).Result;
            if (res != null)
                return Ok("Updated");
            return NoContent();

        }*/

        // DELETE api/<BookCustomerController>/5
/*        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var res =  _service.deleteBookCustomerByID(id).Result;
            if (res != null)
                return Ok("Deleted");
            return NoContent();
        }*/
    }
}
