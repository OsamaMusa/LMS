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
        private readonly IMapper _mapper;
       
        public CustomerService(ICustomerRepository customerRepository ,IMapper mapper) {
            this._customerRepository = customerRepository;
            this._mapper = mapper;
        }
        public Task<bool> addCustomer(CustomerVM customer)
        {
            return _customerRepository.addCustomerAsync(_mapper.Map<Customer>(customer));

        }

        public Task<bool> deleteCustomerByID(long ID)
        {
            return _customerRepository.deleteCustomerByID(ID); 
        }

        public async  Task<IEnumerable<CustomerVM>> getAllCustomers()
        {
            return _mapper.Map<IEnumerable<CustomerVM>>(_customerRepository.getAllCustomers());
        }

        public  async Task<CustomerVM> getCustomerByID(long ID)
        {
            return  _mapper.Map < CustomerVM > (_customerRepository.getCustomerByID(ID));
        }

        public Task<bool> updateCustomerByID(long ID, CustomerVM customer)
        {
            return _customerRepository.updateCustomerByID(ID,customer);
        }
    }
}
