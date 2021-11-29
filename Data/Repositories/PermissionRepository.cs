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
    public class PermissionRepository : IPermissionRepository
    {
        private readonly LMSContext _context;
        private readonly IMapper _mapper;
        public PermissionRepository(LMSContext context, IMapper mapper)
        {
            _mapper = mapper;
            this._context = context;
        }
        public async Task<bool> AddNewPermission(PermissionVM permission)
        {
            await _context.Permissions.AddAsync(_mapper.Map<Permission>(permission));
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePermission(long id)
        {
            var item = GetExistingPermission(id).FirstOrDefault();
            if (item != null)
            {
                
                _context.Permissions.Remove(item);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<PermissionVM>> GetAllPermission()
        {
            return  _mapper.Map<IEnumerable<PermissionVM>>(_context.Permissions.ToList());
        }

        public async Task<PermissionVM> GetPermissionById(long id)
        {

            return _mapper.Map<PermissionVM>(GetExistingPermission(id).FirstOrDefault());
        }

        public async Task<bool> UpdatePermission(long id, PermissionVM permission)
        {
            var item = GetExistingPermission(id).FirstOrDefault();
            if (item != null)
            {
                item = _mapper.Map<Permission>(permission);
                _context.Permissions.Update(item);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        private IQueryable<Permission> GetExistingPermission(long ID) =>
     _context.Permissions.Where(r => r.ID == ID).AsNoTracking();
    }
}
