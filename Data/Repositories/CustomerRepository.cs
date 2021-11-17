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

        public CustomerRepository(LMSContext context ) {
            this._context = context;
        }
        public async Task<bool> addCustomerAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
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

        public async Task<IEnumerable<Customer>> getAllCustomers()
        {
            return  _context.Customers.ToList();
        }

        public async Task<Customer> getCustomerByID(long ID)
        {
            return GetExistingCustomer(ID).FirstOrDefault();
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
