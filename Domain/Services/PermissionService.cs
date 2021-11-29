using Domain.IRepositories;
using Domain.IServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository repository;


        public PermissionService (IPermissionRepository repository)
        {
            this.repository = repository;
        }
        public async Task<bool> AddNewPermission(PermissionVM permission)
        {
           return await repository.AddNewPermission(permission);
        }

        public async Task<bool> DeletePermission(long id)
        {
            return await repository.DeletePermission(id);
        }

        public async Task<IEnumerable<PermissionVM>> GetAllPermission()
        {
            return await repository.GetAllPermission();
        }

        public async Task<PermissionVM> GetPermissionById(long id)
        {
            return await repository.GetPermissionById(id);
        }

        public async Task<bool> UpdatePermission(long id, PermissionVM permission)
        {
            return await repository.UpdatePermission(id, permission);
        }
    }
}
