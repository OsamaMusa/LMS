using AutoMapper;
using Data.Context;
using Domain.Entities;
using Domain.IRepositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ReserveBookByCustomerRepository : IReserveBookByCustomerRepository
    {
        private readonly LMSContext _context;
        private readonly IMapper _mapper;

        public ReserveBookByCustomerRepository(LMSContext context ,IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<bool> addBookCustomerAsync(ReserveBookByCustomerVM bookCustomer)
        {
            var item = _mapper.Map<ReserveBookByCustomer>(bookCustomer);
            await _context.BookCustomer.AddAsync(item);
            await _context.SaveChangesAsync();
            return true;
        }
        
         public async Task<bool> deleteBookCustomerBy_B_C_ID(long CID,long BID)
         {

            ReserveBookByCustomer item = GetExistingBookCustomer_B_C_ID(CID,BID).FirstOrDefault();
           
            if (item != null)
            {
                _context.BookCustomer.Remove(item);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;

        }
        public async Task<bool> deleteBookCustomerByID(long ID)
        {
            ReserveBookByCustomer item = GetExistingBookCustomer(ID).FirstOrDefault();
            if (item != null)
            {
                _context.BookCustomer.Remove(item);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;

        }
        

        private IQueryable<ReserveBookByCustomer> GetExistingBookCustomer(long ID) =>
         _context.BookCustomer.Where(r => r.ID == ID).AsNoTracking();

        private IQueryable<ReserveBookByCustomer> GetExistingBookCustomer_B_C_ID(long CID, long BID) =>
       _context.BookCustomer.Where(r => r.BookId == BID && r.CustomerId == CID).AsNoTracking();


        public async Task<IEnumerable<ReserveBookByCustomerDetailsVM>> getAllBookCustomers()
        {
            return _mapper.Map<IEnumerable<ReserveBookByCustomerDetailsVM>>(
                GetExistingReserve(
                    e => e.Book,
                    e => e.Customer,
                    e => e.ReservedUser,
                    e => e.ReturnedUser
                    ).ToList());

               /* _context.BookCustomer
                .Include(e => e.Book)
                .Include(e => e.Customer)
                 .Include(e => e.ReservedUser)
                .Include(e => e.ReturnedUser)
                .ToList()); */
        }

        private IQueryable<ReserveBookByCustomer> GetExistingReserve(params Expression<Func<ReserveBookByCustomer, object>>[] includeExpressions )
        {

            return includeExpressions
                          .Aggregate<Expression<Func<ReserveBookByCustomer, object>>, IQueryable<ReserveBookByCustomer>>
                      (_context.BookCustomer, (current, expression) => current.Include(expression));
        }

        public async Task<ReserveBookByCustomerDetailsVM> getBookCustomerByID(long ID)
        {
            return _mapper.Map<ReserveBookByCustomerDetailsVM>(
                 GetExistingReserve(
                    e => e.Book,
                    e => e.Customer,
                    e => e.ReservedUser,
                    e => e.ReturnedUser
                    ).FirstOrDefault());

               /* GetExistingBookCustomer(ID)
                .Include(e => e.Book)
                .Include(e => e.Customer)
                .Include(e => e.ReservedUser)
                .Include(e => e.ReturnedUser)
                .FirstOrDefault());*/
        }
        public async Task<ReserveBookByCustomerDetailsVM> getBookCustomerBy_C_B_ID(long CID,long BID)
        {
            return _mapper.Map<ReserveBookByCustomerDetailsVM>(GetExistingBookCustomer_B_C_ID(CID,BID)
                .Include(e => e.Book)
                .Include(e => e.Customer)
                .FirstOrDefault());
        }


        public async Task<bool> updateBookCustomerByID(long ID, ReserveBookByCustomerVM bookCustomer)
        {
            ReserveBookByCustomer item = GetExistingBookCustomer(ID).FirstOrDefault();
            if (item != null)
            {
                item = _mapper.Map<ReserveBookByCustomer>(bookCustomer);
                _context.BookCustomer.Update(item);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> reserveBookCustomer(reserveBookCustomerVM bookCustomer)
        {
            var item = _mapper.Map<ReserveBookByCustomer>(bookCustomer);
            await _context.BookCustomer.AddAsync(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> returnBookCustomer(returnBookCustomerVM bookCustomer)
        {          
            ReserveBookByCustomer item = GetExistingBookCustomer(bookCustomer.ID).FirstOrDefault();
            if (item != null)
            {
                item = _mapper.Map(bookCustomer,item);
                _context.BookCustomer.Update(item);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}
