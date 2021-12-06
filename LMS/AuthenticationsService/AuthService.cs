using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Authentications
{
    public class AuthService:IAuthService
    {
        private readonly IUserRepository _repository;
        private List<UserVM> users = new List<UserVM>();
        public IConfiguration Configuration { get; }
        public AuthService(IUserRepository repository , IConfiguration configuration)
        {
            Configuration = configuration;       
            _repository = repository;
            
            IEnumerable<UserVM> itemE = _repository.getAllUsers().Result;
            if (itemE !=null && itemE.Count() > 0)
                this.users = itemE.ToList();

        }

     

        public string Authentication(string username, string password)
        {
            password = EncoderPass(password);
            if (users.Count < 1 || !users.Any(u => u.username == username && u.password == password))
                return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(Configuration["Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
               {
                   new Claim(ClaimTypes.Name, username)
               }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }


        public async Task<string> registerUserAsync(UserVM user)
        {
            user.password = EncoderPass(user.password);
            await _repository.addUserAsync(user);
            return "User Added !!";

        }

        private string EncoderPass(string pass)
        {
            if (String.IsNullOrEmpty(pass)) return "";
            pass += Configuration["Key"];
            var result = Encoding.UTF8.GetBytes(pass);
            return Convert.ToBase64String(result);

        }

    }

}