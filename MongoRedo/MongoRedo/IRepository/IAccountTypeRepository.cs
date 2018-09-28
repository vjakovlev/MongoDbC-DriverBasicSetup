using MongoDB.Driver;
using MongoRedo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoRedo.IRepository
{
    public interface IAccountTypeRepository
    {
        Task<IEnumerable<AccountType>> GetAllAccounts();
        Task<AccountType> GetAccount(string id);
        Task CreateAccount(AccountType accountType);
        Task UpdateAccount(string id, AccountType accountType);
        Task<DeleteResult> DeleteAccount(string id);
    }
}
