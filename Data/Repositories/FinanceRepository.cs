using AutoMapper;
using Data.Context;
using Domain.Entities;
using Domain.IRepositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            FinanceTransactions item = GetExistingTrans(Id).FirstOrDefault();
            if (item != null)
            {
                _context.FinanceTransactions.Remove(item);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        private IQueryable<FinanceTransactions> GetExistingTrans(long ID) =>
               _context.FinanceTransactions.Where(r => r.ID == ID).AsNoTracking();

        public async Task<IEnumerable<FinanceTransactionsVM>> getAllTrans()
        {
            return _mapper.Map<IEnumerable<FinanceTransactionsVM>>(
                _context.FinanceTransactions
                .Include(e => e.Reserve).ThenInclude(e=>e.Book)
                .Include(e => e.Reserve).ThenInclude(e => e.Customer)
                .Include(e => e.Reserve).ThenInclude(e => e.ReservedUser)
                .Include(e => e.Reserve).ThenInclude(e => e.ReturnedUser)
                .Include(e => e.User)
                .ToList()
                );
        }

        public async Task<FinanceTransactionsVM> getTransByID(long Id)
        {
            return _mapper.Map<FinanceTransactionsVM>(
                GetExistingTrans(Id)
                .Include(e => e.Reserve).ThenInclude(e => e.Book)
                .Include(e => e.Reserve).ThenInclude(e => e.Customer)
                .Include(e => e.Reserve).ThenInclude(e => e.ReservedUser)
                .Include(e => e.Reserve).ThenInclude(e => e.ReturnedUser)
                .Include(e => e.User)
                .FirstOrDefault());
        }

        public async Task<bool> UpdateTransAsync(long Id, InsertFinanceTransactionVM transaction)
        {

            FinanceTransactions item = GetExistingTrans(Id).FirstOrDefault();
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
