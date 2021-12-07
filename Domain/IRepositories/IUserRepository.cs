using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IUserRepository
    {
        public Task<IEnumerable<UserVM>> getAllUsers();
        public Task<UserVM> getUserByID(long Id);
        public Task<bool> deleteUserAsync(long Id);
        public Task<bool> addUserAsync(UserVM user);
        public Task<bool> UpdateUserAsync(long Id , UserVM user);
        public Task<UserVM> getUserByUserName(string username);
        Task<bool> resetUserPassword(ResetUserPassword userPassword);
    }
}
