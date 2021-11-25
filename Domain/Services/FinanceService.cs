using Domain.IRepositories;
using Domain.IServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class FinanceService : IFinanceService
    {
        private readonly IFinanceRepository _repository;

        public FinanceService(IFinanceRepository repository)
        {
            this._repository = repository;

        }

        public Task<bool> addTransAsync(InsertFinanceTransactionVM transaction)
        {
            return this._repository.addTransAsync(transaction);
        }

        public Task<bool> deleteTransAsync(long Id)
        {
            return this._repository.deleteTransAsync(Id);
           
        }

        public Task<IEnumerable<FinanceTransactionsVM>> getAllTrans()
        {
            return this._repository.getAllTrans();

        }

        public Task<FinanceTransactionsVM> getTransByID(long Id)
        {
            return this._repository.getTransByID(Id);

        }
        public Task<FinanceTransactionsVM> getTransByReservationID(long Id)
        {
            return this._repository.getTransByReservationID(Id);

        }
        public Task<bool> UpdateTransAsync(long Id, InsertFinanceTransactionVM transaction)
        {
            return this._repository.UpdateTransAsync(Id,transaction);
        }
    }
}
