using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IServices
{
   public interface IRoleService
    {
        Task<RoleVM> GetRoleById(long id);
        Task<IEnumerable<RoleVM>> GetAllRoles();
        Task<bool> AddNewRole(RoleVM Role);

        Task<bool> UpdateRole(long id, RoleVM Role);

        Task<bool> DeleteRole(long id);
    }
}
