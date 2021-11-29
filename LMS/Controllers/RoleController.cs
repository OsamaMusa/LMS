using Domain.IRepositories;
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
    public class RoleController : Controller
    {
        private readonly IRoleRepository _service;

        public RoleController(IRoleRepository service)
        {
            this._service = service;
        }

        [HttpGet]
        public Task<IEnumerable<RoleVM>> getAllRoles()
        {
            return _service.GetAllRoles();
        }
        [HttpGet("{id}")]
        public Task<RoleVM> getRole(long id)
        {
            return _service.GetRoleById(id);
        }
        [HttpDelete("{id}")]
        public Task<bool> deleteRole(long id)
        {
            return _service.DeleteRole(id);
        }
        [HttpPut("{id}")]
        public Task<bool> updateRole(long id, RoleVM role)
        {
            return _service.UpdateRole(id, role);
        }
        [HttpPost]
        public Task<bool> addRole(RoleVM role)
        {
            return _service.AddNewRole(role);
        }

    }
}
