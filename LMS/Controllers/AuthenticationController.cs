using API.Authentications;
using AutoMapper;
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
    public class AuthenticationController : ControllerBase
    {
    
       
            private readonly IAuthService _services;
            private readonly IMapper _mapper;

            public AuthenticationController(IAuthService services, IMapper mapper)
            {
                _services = services;
                _mapper = mapper;
            }


            // POST: api/Cars
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [AllowAnonymous]
            [HttpGet]
            public IActionResult SignIn(String userName, String password)
            {
                var result = _services.Authentication(userName, password);
                if (result != null)
                    return Ok(result);
                return NotFound();

            }

            [AllowAnonymous]
            [HttpPost]
            public IActionResult SignUp(UserVM user)
            {
                var result = _services.registerUserAsync(user);
                if (result != null)
                    return Ok(result);
                return BadRequest();

            }

        }
    }