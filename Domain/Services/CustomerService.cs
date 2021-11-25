using AutoMapper;
using Domain.Entities;
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
 
       
        public CustomerService(ICustomerRepository customerRepository) {
            this._customerRepository = customerRepository;

        }
        public Task<bool> addCustomer(CustomerVM customer)
        {
            return _customerRepository.addCustomerAsync(customer);

        }

        public Task<bool> deleteCustomerByID(long ID)
        {
            return _customerRepository.deleteCustomerByID(ID); 
        }

        public   Task<IEnumerable<CustomerVM>> getAllCustomers()
        {
            return _customerRepository.getAllCustomers();
        }

        public  Task<CustomerVM> getCustomerByID(long ID)
        {
            return _customerRepository.getCustomerByID(ID);
        }

  
        public Task<bool> updateCustomerByID(long ID, CustomerVM customer)
        {
            return _customerRepository.updateCustomerByID(ID, customer);
        }
    }
}
