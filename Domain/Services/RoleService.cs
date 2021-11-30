using Domain.IRepositories;
using Domain.IServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository Repository;
      public RoleService(IRoleRepository _Repository)
        {
            Repository = _Repository;
        }

        public async Task<bool> AddNewRole(RoleVM Role)
        {
            return await Repository.AddNewRole(Role);

                }

        public async Task<bool> DeleteRole(long id)
        {
            return await Repository.DeleteRole(id);
        }

        public async Task<IEnumerable<RoleVM>> GetAllRoles()
        {
            return await Repository.GetAllRoles();
        }

        public async Task<RoleVM> GetRoleById(long id)
        {
            return await Repository.GetRoleById(id);
        }

        public async Task<bool> UpdateRole(long id, RoleVM Role)
        {
            return await Repository.UpdateRole(id, Role);
        }
    }
}
