using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoRedo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoRedo.DbModel
{
    public class DbContext
    {
        private readonly IMongoDatabase _database = null;

        public DbContext(IOptions<Settings> settings)
        {
            //client
            var client = new MongoClient(settings.Value.ConnectionString);

            if (client != null)
            {
                _database = client.GetDatabase(settings.Value.Database);
            }
        }

        public IMongoCollection<User> Users
        {
            get
            {
                return _database.GetCollection<User>("User");
            }
        }

        public IMongoCollection<AccountType> AccountTypes
        {
            get
            {
                return _database.GetCollection<AccountType>("AccoutType");
            }
        }
    }
}
