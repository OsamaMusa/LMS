using Domain.IServices;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Permissioncontroller:Controller
    {
        private readonly IPermissionService _service;

        public Permissioncontroller(IPermissionService _service)
        {
            this._service = _service;

        }
        [HttpGet]
        public Task<IEnumerable<PermissionVM>> GetAllPermission()
        {
            return _service.GetAllPermission();
        }
        [HttpGet("{id}")]
        public Task<PermissionVM> GetPermissionById(long id)
        {
            return _service.GetPermissionById(id);
        }
        [HttpDelete("{id}")]
        public Task<bool> DeletePermission(long id)
        {
            return _service.DeletePermission(id);
        }
        [HttpPut("{id}")]
        public Task<bool> UpdatePermission(long id, PermissionVM permission)
        {
            return _service.UpdatePermission(id, permission);
        }

        [HttpPost]
        public Task<bool> AddNewPermission(PermissionVM permission)
        {
            return _service.AddNewPermission(permission);
        }
    }
}
