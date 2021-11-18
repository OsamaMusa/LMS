using AutoMapper;
using Data.Context;
using Domain.Entities;
using Domain.IRepositories;
using Domain.Models;
using Domian.Entities;
using HotChocolate;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{

    public class CustomerRepository : ICustomerRepository
    {
        private readonly LMSContext _context;
        private readonly IMapper _mapper;

        public CustomerRepository(LMSContext context , IMapper mapper ) {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<bool> addCustomerAsync(CustomerVM customer)
        {
            await _context.Customers.AddAsync(_mapper.Map<Customer>(customer));
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> deleteCustomerByID(long ID)
        {
            Customer item = GetExistingCustomer(ID).FirstOrDefault();
            if (item != null) {
                 _context.Customers.Remove(item);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
            
        }

        private IQueryable<Customer> GetExistingCustomer(long ID) =>
         _context.Customers.Where(r => r.ID == ID);

        public async Task<IEnumerable<CustomerVM>> getAllCustomers()
        {
            return  _mapper.Map<IEnumerable<CustomerVM>>(_context.Customers.ToList());
        }

        public async Task<CustomerVM> getCustomerByID(long ID)
        {
            return _mapper.Map<CustomerVM>(GetExistingCustomer(ID).FirstOrDefault());
        }

        public async Task<bool> updateCustomerByID(long ID, CustomerVM customer)
        {
            Customer item = GetExistingCustomer(ID).FirstOrDefault();
            if (item != null)
            {
                item = _mapper.Map<Customer>(customer);
                _context.Customers.Update(item);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

      
    }
}
