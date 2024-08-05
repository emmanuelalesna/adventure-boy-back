using Microsoft.AspNetCore.Mvc;
using Project2.app.Models;
using Project2.app.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project2.app.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        // Create a new account
        [HttpPost("Create")]
        public async Task<IActionResult> CreateAccount([FromBody] Account account)
        {
            if (account == null || string.IsNullOrWhiteSpace(account.Username) || string.IsNullOrWhiteSpace(account.Password))
            {
                return BadRequest("Username and Password are required.");
            }

            try
            {
                var createdAccount = await _accountService.CreateNewEntity(account);
                return CreatedAtAction(nameof(GetAccountById), new { id = createdAccount.AccountId }, createdAccount);
            }
            catch (InvalidDataException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // Get all accounts
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAccounts()
        {
            try
            {
                var accounts = await _accountService.GetAllEntities();
                return Ok(accounts);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // Get account by ID
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetAccountById(int id)
        {
            try
            {
                var account = await _accountService.GetEntityById(id);
                if (account == null)
                {
                    return NotFound("Account not found.");
                }
                return Ok(account);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // Update account by ID
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateAccount(int id, [FromBody] Dictionary<string, object> updates)
        {
            try
            {
                var updatedAccount = await _accountService.UpdateEntity(id, updates);
                if (updatedAccount == null)
                {
                    return NotFound("Account not found.");
                }
                return Ok(updatedAccount);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // Delete account by ID
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            try
            {
                var account = await _accountService.DeleteEntity(id);
                if (account == null)
                {
                    return NotFound("Account not found.");
                }
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
