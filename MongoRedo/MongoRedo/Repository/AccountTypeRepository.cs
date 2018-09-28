using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoRedo.DbModel;
using MongoRedo.IRepository;
using MongoRedo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoRedo.Repository
{
    public class AccountTypeRepository : IAccountTypeRepository
    {
        private readonly DbContext _context = null;

        public AccountTypeRepository(IOptions<Settings> settings)
        {
            _context = new DbContext(settings);
        }



        //get all
        public async Task<IEnumerable<AccountType>> GetAllAccounts()
        {
            return await _context.AccountTypes.Find(x => true).ToListAsync();
        }

        //get specific
        public async Task<AccountType> GetAccount(string id)
        {
            return await _context.AccountTypes.Find(Builders<AccountType>.Filter.Eq("Id", id)).FirstOrDefaultAsync();
        }

        //create
        public async Task CreateAccount(AccountType accountType)
        {
            await _context.AccountTypes.InsertOneAsync(accountType);
        }

        //update
        public async Task UpdateAccount(string id, AccountType accountType)
        {
            await _context.AccountTypes.ReplaceOneAsync(x => x.Id == id, accountType);
        }

        //delete
        public async Task<DeleteResult> DeleteAccount(string id)
        {
            return await _context.AccountTypes.DeleteOneAsync(Builders<AccountType>.Filter.Eq("Id", id));
        }
    }
}
