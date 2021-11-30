using Domain.IServices;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service) {
            this._service = service;
        }

        [HttpGet]
        public Task<IEnumerable<CustomerVM>> getAllCustomers() {
            var items =  _service.getAllCustomers();
            return items;
        }
        [HttpGet("{id}")]
        public  Task<CustomerVM> getCustomer(long id)
        {
            return _service.getCustomerByID(id);
        }
        [HttpDelete("{id}")]
        public Task<bool> deleteCustomer(long Id)
        {
            return _service.deleteCustomerByID(Id);
        }
        [HttpPut("{id}")]
        public Task<bool> updateCustomer(long id, CustomerVM customer)
        {
            return _service.updateCustomerByID(id, customer);
        }
        [HttpPost]
        public Task<bool> addCustomer(CustomerVM customer)
        {
            return _service.addCustomer(customer);
        }

    }
}
