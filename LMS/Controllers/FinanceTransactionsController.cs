using Domain.IServices;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinanceTransactionsController : ControllerBase
    {
        private readonly IFinanceService _service;

        public FinanceTransactionsController(IFinanceService service)
        {
            this._service = service;
        }

        [HttpGet]
        public Task<IEnumerable<FinanceTransactionsVM>> getAllTrans()
        {
            return _service.getAllTrans();
        }
        [HttpGet("{id}")]
        public  Task<FinanceTransactionsVM> getTrans(long id)
        {
            return _service.getTransByID(id);
        }
        [HttpDelete("{id}")]
        public Task<bool> deleteUser(long id)
        {
            return _service.deleteTransAsync(id);
        }
        [HttpPut("{id}")]
        public Task<bool> updateTrans(long id, InsertFinanceTransactionVM trans)
        {
            return _service.UpdateTransAsync(id, trans);
        }
        [HttpPost]
        public Task<bool> addTrans(InsertFinanceTransactionVM trans)
        {
            return _service.addTransAsync(trans);
        }

    }
}
