using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Authentications
{
    public interface IAuthService
    {
        public string Authentication(string username, string password);
        public  Task<string> registerUserAsync(UserVM user);
    }
}
