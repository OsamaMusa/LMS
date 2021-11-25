using AutoMapper;
using Data.Context;
using Domain.Entities;
using Domain.IRepositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LMSContext _context;
        private readonly IMapper _mapper;

        public UserRepository(LMSContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        } 

        public async Task<bool> addUserAsync(UserVM user)
        {
            await _context.Users.AddAsync(_mapper.Map<Users>(user));
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> deleteUserAsync(long Id)
        {
            Users item = GetExistingUser(Id).FirstOrDefault();
            if (item != null)
            {
                _context.Users.Remove(item);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        private IQueryable<Users> GetExistingUser(long ID) =>
                  _context.Users.Where(r => r.ID == ID).AsNoTracking();

     
        public async Task<IEnumerable<UserVM>> getAllUsers()
        {
            return   _mapper.Map<IEnumerable<UserVM>>(_context.Users.ToList());
        }

        public async Task<UserVM> getUserByID(long Id)
        {
            return _mapper.Map<UserVM>(GetExistingUser(Id).FirstOrDefault());
        }

        public async Task<bool> UpdateUserAsync(long Id, UserVM user)
        {

            Users item = GetExistingUser(Id).FirstOrDefault();
            if (item != null)
            {
                item = _mapper.Map<Users>(user);
                _context.Users.Update(item);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
