using Microsoft.AspNetCore.Mvc;
using Project2.app.DTOs;
using Project2.app.Services.Interface;

namespace Project2.app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // Create a new account
        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] AccountDTO account)
        {
            if (account == null || string.IsNullOrWhiteSpace(account.Username) || string.IsNullOrWhiteSpace(account.Password))
            {
                return BadRequest("Username and Password are required.");
            }

            try
            {
                return Ok(await _accountService.CreateNewEntity(account));
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
        [HttpGet]
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

        // Get by username
        [HttpGet("{username}")]
        public async Task<IActionResult> GetEntityByUsername(string username)
        {
            var account = await _accountService.GetEntityByUsername(username);
            if (account is null)
            {
                return NotFound("Account not found.");
            }
            else
            {
                return Ok(account);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AccountDTO account)
        {
            try
            {
                var loginResult = await _accountService.Login(account);
                if (loginResult is not null)
                {
                    return Ok(loginResult);
                }
                else
                {
                    return Unauthorized("Incorrect password");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // Get account by ID
        /*
        [HttpGet("{id}")]
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
        */
        /*
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
        */
        // Delete account by ID
        [HttpDelete("{id}")]
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
