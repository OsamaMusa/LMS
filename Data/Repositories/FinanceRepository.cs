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
    public class FinanceRepository : IFinanceRepository
    {
        private readonly LMSContext _context;
        private readonly IMapper _mapper;

        public FinanceRepository(LMSContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<bool> addTransAsync(InsertFinanceTransactionVM transaction)
        {
            await _context.FinanceTransactions.AddAsync(_mapper.Map<FinanceTransactions>(transaction));
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> deleteTransAsync(long Id)
        {
            FinanceTransactions item = Get(e=>e.ID==Id).FirstOrDefault();
            if (item != null)
            {
                _context.FinanceTransactions.Remove(item);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        /*    private IQueryable<FinanceTransactions> GetExistingTrans(long ID) =>
                   _context.FinanceTransactions.Where(r => r.ID == ID).AsNoTracking();*/
        private IQueryable<FinanceTransactions> Get(
         Expression<Func<FinanceTransactions, bool>> filterExpressions,
         params Expression<Func<FinanceTransactions, object>>[] includeExpressions)

        {
            return includeExpressions
                          .Aggregate<Expression<Func<FinanceTransactions, object>>, IQueryable<FinanceTransactions>>
                      (_context.FinanceTransactions, (current, expression) => current.Include(expression)).Where(filterExpressions).AsNoTracking();
        }

        public async Task<IEnumerable<FinanceTransactionsVM>> getAllTrans()
        {
            return _mapper.Map<IEnumerable<FinanceTransactionsVM>>(
                Get(
                    e => true,
                    e => e.Reserve.Book,
                    e => e.Reserve.Customer,
                    e => e.Reserve.ReservedUser,
                    e => e.Reserve.ReturnedUser,
                    e => e.User
                    ).ToList());

               /* _context.FinanceTransactions
                .Include(e => e.Reserve).ThenInclude(e=>e.Book)
                .Include(e => e.Reserve).ThenInclude(e => e.Customer)
                .Include(e => e.Reserve).ThenInclude(e => e.ReservedUser)
                .Include(e => e.Reserve).ThenInclude(e => e.ReturnedUser)
                .Include(e => e.User)
                .ToList()
                );*/
        }
        
        public async Task<FinanceTransactionsVM> getTransByReservationID(long Id)
        {
            return _mapper.Map<FinanceTransactionsVM>(
                   Get(
                    e => e.ReserveID == Id,
                    e => e.Reserve.Book,
                    e => e.Reserve.Customer,
                    e => e.Reserve.ReservedUser,
                    e => e.Reserve.ReturnedUser,
                    e => e.User
                    ).FirstOrDefault());
            /* _context.FinanceTransactions.Where(r => r.ReserveID == Id)
             .Include(e => e.Reserve).ThenInclude(e => e.Book)
             .Include(e => e.Reserve).ThenInclude(e => e.Customer)
             .Include(e => e.Reserve).ThenInclude(e => e.ReservedUser)
             .Include(e => e.Reserve).ThenInclude(e => e.ReturnedUser)
             .Include(e => e.User)
             .AsNoTracking()
             .FirstOrDefault());*/
        }
            public async Task<FinanceTransactionsVM> getTransByID(long Id)
        {
            return _mapper.Map<FinanceTransactionsVM>(
                 Get(
                    e => e.ID == Id,
                    e => e.Reserve.Book,
                    e => e.Reserve.Customer,
                    e => e.Reserve.ReservedUser,
                    e => e.Reserve.ReturnedUser,
                    e => e.User
                    ).FirstOrDefault());

                /*GetExistingTrans(Id)
                .Include(e => e.Reserve).ThenInclude(e => e.Book)
                .Include(e => e.Reserve).ThenInclude(e => e.Customer)
                .Include(e => e.Reserve).ThenInclude(e => e.ReservedUser)
                .Include(e => e.Reserve).ThenInclude(e => e.ReturnedUser)
                .Include(e => e.User)
                .FirstOrDefault());*/
        }

        public async Task<bool> UpdateTransAsync(long Id, InsertFinanceTransactionVM transaction)
        {

            FinanceTransactions item = Get(e => e.ID == Id).FirstOrDefault();
            if (item != null)
            {
                item = _mapper.Map(transaction,item);
                _context.FinanceTransactions.Update(item);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
