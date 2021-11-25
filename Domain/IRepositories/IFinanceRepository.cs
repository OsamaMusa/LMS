using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IFinanceRepository
    {
        public Task<IEnumerable<FinanceTransactionsVM>> getAllTrans();
        public Task<FinanceTransactionsVM> getTransByID(long Id);
        public Task<bool> deleteTransAsync(long Id);
        public Task<bool> addTransAsync(InsertFinanceTransactionVM transaction);
        public Task<bool> UpdateTransAsync(long Id, InsertFinanceTransactionVM transaction);
    }
}
