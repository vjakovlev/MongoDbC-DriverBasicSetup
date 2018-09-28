using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoRedo.IRepository;
using MongoRedo.Model;

namespace MongoRedo.Controllers
{
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("/api/users")]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            return (List<User>)users;
        }

        [HttpGet("/api/users/{id}")]
        public async Task<ActionResult<User>> GetUser(string id)
        {
            return await _userRepository.GetUser(id);
        }

        [HttpPost("api/users")]
        public async Task<ActionResult<User>> CreateUser([FromBody] User user)
        {
            await _userRepository.CreateUser(user);
            return new OkResult();
        }

        [HttpPut("api/users/{id}")]
        public async Task<ActionResult<User>> EditUser(string id, [FromBody] User user)
        {
            await _userRepository.UpdateUser(id, user);
            return new OkResult();
        }

        [HttpDelete("api/users/{id}")]
        public async Task<ActionResult<User>> DeleteUser(string id)
        {
            await _userRepository.DeleteUser(id);
            return new OkResult();
        }
 

    }
}