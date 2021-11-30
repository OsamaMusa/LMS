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
    public class RoleRepository : IRoleRepository
    {
        private readonly LMSContext _context;
        private readonly IMapper _mapper;
        public RoleRepository(LMSContext context, IMapper mapper)
        {
            _mapper = mapper;
            this._context = context;
        }
        public async Task<bool> AddNewRole(RoleVM role)
        {
            await _context.Roles.AddAsync(_mapper.Map<Role>(role));
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteRole(long id)
        {
            Role item = GetExistingRole(id).FirstOrDefault();
            if (item != null)
            {
                _context.Roles.Remove(item);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<RoleVM>> GetAllRoles()
        {
            return _mapper.Map<IEnumerable<RoleVM>>(_context.Roles.ToList());
        }

        public async Task<RoleVM> GetRoleById(long id)
        {
            return _mapper.Map<RoleVM>(GetExistingRole(id).FirstOrDefault());
        }

        public async Task<bool> UpdateRole(long id, RoleVM Role)
        {
            var item = GetExistingRole(id).FirstOrDefault();
            if(item != null)
            {
                item = _mapper.Map<Role>(Role);
                _context.Roles.Update(item);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        private IQueryable<Role> GetExistingRole(long ID) =>
     _context.Roles.Where(r => r.ID == ID).AsNoTracking();
    }
}
