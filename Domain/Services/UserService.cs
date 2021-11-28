using Domain.Enums;
using Domain.IRepositories;
using Domain.IServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class UserService :  IUserService
    { 
            private readonly IUserRepository _userRepository;
          
            public UserService(IUserRepository userRepository)
            {
                this._userRepository = userRepository;
           
            }
           public Task<bool> addUser(UserVM user)
           {
            return _userRepository.addUserAsync(user);
           }

            public  Task<bool> deleteUserByID(long ID)
            {
           
                    return   _userRepository.deleteUserAsync(ID);
         
            }

            public Task<IEnumerable<UserVM>> getAllUsers()
            {
                return _userRepository.getAllUsers();
            }

            public Task<UserVM> getUserByID(long ID)
            {
                return _userRepository.getUserByID(ID);
            }


            public  Task<bool> updateUserByID(long ID, UserVM user)
            {
      
                return  _userRepository.UpdateUserAsync(ID, user);
   
        }
    }
 }