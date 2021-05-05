using backend.Models;
using backend.Models.ViewModels;
using backend.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Route("api/v1/accounts")]
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

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Account>> GetById(int id)
        {
            Account account = await _accountService.findByIdAsync(id);

            if(account == null)
            {
                return NotFound(new { message = "Conta não encontrada" });
            }

            return Ok(account);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<AccountViewModel>> Put(
            int id, 
            [FromBody]AccountViewModel viewModel)
        {
            if(id != viewModel.Account.Id)
            {
                return NotFound(new { message = "Conta não encontrada" });
            }

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if(viewModel.Action == "sacar")
                {
                    await _accountService.SacarAsync(id, viewModel);
                }
                else if(viewModel.Action == "depositar")
                {
                    await _accountService.DepositarAsync(id, viewModel);
                } 
                else if(viewModel.Action == "transferir")
                {
                    await _accountService.TransferirAsync(id, viewModel);
                }
                
                return Ok(viewModel);
            }
            catch(ApplicationException e)
            {
                return BadRequest(new { message = e.Message });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        //[HttpDelete]
        //[Route("")]

    }
}
