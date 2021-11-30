using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IServices
{
    public interface  IPermissionService
    {
        Task<PermissionVM> GetPermissionById(long id);
        Task<IEnumerable<PermissionVM>> GetAllPermission();
        Task<bool> AddNewPermission(PermissionVM permission);

        Task<bool> UpdatePermission(long id, PermissionVM permission);

        Task<bool> DeletePermission(long id);
    }
}
