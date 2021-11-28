using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Domain.IRepositories;
using Domain.IServices;
using Domain.Models;
using HotChocolate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{

    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserRepository _userRepository;

        public CustomerService(ICustomerRepository customerRepository ,IUserRepository userRepository) {
            this._customerRepository = customerRepository;
            this._userRepository = userRepository;
        }
        public async Task<bool> addCustomer(CustomerVM customer)
        {

            if (customer != null)
            {
                UserVM user = _userRepository.getUserByID(customer.userID).Result;
                long userId = -1;
                if (user != null)
                    userId = user.roleID;
                if (userId == ((int)(UserLookups.CTO)) + 1)
                    return await _customerRepository.addCustomerAsync(customer);
            }
            return false;

        }

        public async Task<bool> deleteCustomerByID(long ID)
        {
            CustomerVM customer = getCustomerByID(ID).Result;
            if (customer != null)
            {
                UserVM user = _userRepository.getUserByID(customer.userID).Result;
                long userId = -1;
                if (user != null)
                    userId = user.roleID;
                if (userId == ((int)(UserLookups.CTO)) + 1)
                    return await _customerRepository.deleteCustomerByID(ID);
            }
            return false;
        }

        public   Task<IEnumerable<CustomerVM>> getAllCustomers()
        {
            return _customerRepository.getAllCustomers();
        }

        public  Task<CustomerVM> getCustomerByID(long ID)
        {
            return _customerRepository.getCustomerByID(ID);
        }

  
        public async Task<bool> updateCustomerByID(long ID, CustomerVM customer)
        {
            if (customer != null)
            {
                UserVM user = _userRepository.getUserByID(customer.userID).Result;
                long userId = -1;
                if (user != null)
                    userId = user.roleID;
                if (userId == ((int)(UserLookups.CTO)) + 1)
                    return await _customerRepository.updateCustomerByID(ID, customer);
            }
            return false;
        }
    }
}
