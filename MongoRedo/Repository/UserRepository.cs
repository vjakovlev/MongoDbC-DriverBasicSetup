using Microsoft.AspNetCore.Mvc;
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
    public class UserRepository : IUserRepository
    {
        private readonly DbContext _context = null;

        public UserRepository(IOptions<Settings> settings)
        {
            _context = new DbContext(settings);
        }



        //get all
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.Find(x => true).ToListAsync();
        }

        //get specific
        public async Task<User> GetUser(string id)
        {
            return await _context.Users.Find(Builders<User>.Filter.Eq("Id", id)).FirstOrDefaultAsync();
        }

        //create
        public async Task CreateUser(User user)
        {
            await _context.Users.InsertOneAsync(user);
        }

        //update
        public async Task UpdateUser(string id, User user)
        {
            await _context.Users.ReplaceOneAsync(x => x.Id == id, user);
        }

        //delete
        public async Task<DeleteResult> DeleteUser(string id)
        {
            return await _context.Users.DeleteOneAsync(Builders<User>.Filter.Eq("Id", id));
        }
    }
}
