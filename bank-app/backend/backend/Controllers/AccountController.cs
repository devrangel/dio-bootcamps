using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Route("v1/accounts")]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Account>>> Get()
        {
            List<Account> accounts = await _accountService.findAllAsync();

            return Ok(accounts);
        }

        //[HttpPut]
        //[Route("")]

        //[HttpDelete]
        //[Route("")]

    }
}
