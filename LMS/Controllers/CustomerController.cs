using Domain.IServices;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;
        private readonly ILogger _logger;

        public CustomerController(ICustomerService customerService ,ILogger logger) {
            this._service = customerService;
            this._logger = logger;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<CustomerVM> Get()
        {
            return _service.getAllCustomers();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public string Get(long id)
        {
            return "value";
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
        }
    }
}
