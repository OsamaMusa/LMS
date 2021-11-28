using Domain.Enums;
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
        private readonly IUserRepository _userRepository;

        public FinanceService(IFinanceRepository repository,IUserRepository userRepository)
        {
            this._repository = repository;
            this._userRepository = userRepository;
        }

        public async Task<bool> addTransAsync(InsertFinanceTransactionVM transaction)
        {
            if (transaction != null)
            {
                UserVM user = _userRepository.getUserByID(transaction.UserID).Result;
                long userId = -1;
                if (user != null)
                    userId = user.PermissionID;
                if (userId == ((int)(UserLookups.Finance)) + 1)

                    return await this._repository.addTransAsync(transaction);
            }
            return false;
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
        public async Task<bool> UpdateTransAsync(long Id, InsertFinanceTransactionVM transaction)
        {
            if (transaction != null)
            {
                UserVM user = _userRepository.getUserByID(transaction.UserID).Result;
                long userId = -1;
                if (user != null)
                    userId = user.PermissionID;
                if (userId == ((int)(UserLookups.Finance)) + 1)

                    return await this._repository.UpdateTransAsync(Id, transaction);
            }
            return false;
        }
    }
}
