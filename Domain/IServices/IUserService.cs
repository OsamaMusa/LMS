using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IServices
{
    public interface IUserService
    {
        public Task<IEnumerable<UserVM>> getAllUsers();
        public Task<UserVM> getUserByID(long ID);
        public Task<bool> deleteUserByID(long ID);
        public Task<bool> addUser(UserVM customer);
        public Task<bool> updateUserByID(long id, UserVM customer);
        public Task<UserVM> getUserByUserName(string username);
        Task<bool> resetUserPassword(ResetUserPassword userPassword);
    }
}
