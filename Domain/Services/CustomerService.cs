using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;
using Domain.IServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
        public bool addCustomer(CustomerVM customer)
        {
            return _customerRepository.addCustomer(_mapper.Map<Customer>(customer));
            
        }

        public bool deleteCustomerByID(long ID)
        {
            return _customerRepository.deleteCustomerByID(ID); 
        }

        public IEnumerable<CustomerVM> getAllCustomers()
        {
            yield return _mapper.Map<CustomerVM>(_customerRepository.getAllCustomers());
        }

        public CustomerVM getCustomerByID(long ID)
        {
            return _mapper.Map < CustomerVM > (_customerRepository.getCustomerByID(ID));
        }
    }
}
