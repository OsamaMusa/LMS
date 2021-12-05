using Domain.IServices;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            this._service = service;
        }

        [HttpGet]
        public Task<IEnumerable<UserVM>> getAllUsers()
        {     
            return _service.getAllUsers();
        }
     /*   [HttpGet("{id}")]
        public Task<UserVM> getUser(long id)
        {
            return _service.getUserByID(id);
        }*/
        [HttpGet("{username}")]
        public Task<UserVM> getUserByUserName(string username)
        {
            return _service.getUserByUserName(username);
        }
        [HttpDelete("{id}")]
        public Task<bool> deleteUser(long id)
        {
            return _service.deleteUserByID(id);
        }
        [HttpPut("{id}")]
        public Task<bool> updateUser(long id, UserVM user)
        {
            return _service.updateUserByID(id, user);
        }
        [HttpPost]
        public Task<bool> addUser(UserVM user)
        {
            return _service.addUser(user);
        }

    }
}
