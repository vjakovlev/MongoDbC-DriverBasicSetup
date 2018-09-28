using MongoDB.Driver;
using MongoRedo.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoRedo.IRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUser(string id);
        Task CreateUser(User user);
        Task UpdateUser(string id, User user);
        Task<DeleteResult> DeleteUser(string id);
    }
}
