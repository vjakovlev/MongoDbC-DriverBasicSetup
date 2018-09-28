using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoRedo.IRepository;
using MongoRedo.Model;

namespace MongoRedo.Controllers
{
    public class AccountTypesController : ControllerBase
    {
        private readonly IAccountTypeRepository _accountTypeRepository;

        public AccountTypesController(IAccountTypeRepository accountTypeRepository)
        {
            _accountTypeRepository = accountTypeRepository;
        }


        [HttpGet("/api/accounts")]
        public async Task<ActionResult<List<AccountType>>> GetAllAccount()
        {
            var accounts = await _accountTypeRepository.GetAllAccounts();
            return (List<AccountType>)accounts;
        }

        [HttpGet("/api/accounts/{id}")]
        public async Task<ActionResult<AccountType>> GetAccount(string id)
        {
            return await _accountTypeRepository.GetAccount(id);
        }

        [HttpPost("api/accounts")]
        public async Task<ActionResult<AccountType>> CreateUser([FromBody] AccountType account)
        {
            await _accountTypeRepository.CreateAccount(account);
            return new OkResult();
        }

        [HttpPut("api/accounts/{id}")]
        public async Task<ActionResult<AccountType>> EditAccount(string id, [FromBody] AccountType account)
        {
            await _accountTypeRepository.UpdateAccount(id, account);
            return new OkResult();
        }

        [HttpDelete("api/accounts/{id}")]
        public async Task<ActionResult<AccountType>> DeleteAccount(string id)
        {
            await _accountTypeRepository.DeleteAccount(id);
            return new OkResult();
        }

    }
}