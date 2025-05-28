using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project2.app.Services.Interface;

namespace Project2.app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController(IAccountService accountService) : ControllerBase
    {
        private readonly IAccountService _accountService = accountService;

        // Create a new account
        /* [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] AccountDTO account)
        {
            if (account == null || string.IsNullOrWhiteSpace(account.UserName) || string.IsNullOrWhiteSpace(account.Password))
            {
                return BadRequest("Username and Password are required.");
            }

            try
            {
                var result = await _accountService.CreateNewEntity(account);
                if (result.Succeeded) return Ok(result.ToString());
                return Unauthorized(result.Errors);
            }
            catch (InvalidDataException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        } */

        // Get all accounts
        [HttpGet, Authorize]
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
        [HttpGet("{username}"), Authorize]
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

        /*  [HttpPost("login")]
         public async Task<IActionResult> Login([FromBody] AccountDTO account)
         {
             try
             {
                 // Console.WriteLine(account.UserName);
                 // Console.WriteLine(account.Password);
                 var loginResult = await _accountService.Login(account);
                 Console.WriteLine(loginResult);
                 if (loginResult is not null && loginResult.Succeeded)
                 {
                     // AccountReturnDTO account1 = new() { AccountId = loginResult.AccountId, Username = loginResult.FirstName, OwnedPlayer = loginResult.OwnedPlayer };
                     return Ok(loginResult.ToString());
                 }
                 else
                 {
                     return Unauthorized(loginResult.ToString());
                 }
             }
             catch (Exception e)
             {
                 return BadRequest(e.Message);
             }
         } */
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
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> DeleteAccount(string id)
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

        [HttpGet("logout"), Authorize]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _accountService.Logout();
                return Ok("logged out successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("id"), Authorize]
        public IActionResult GetAccountId()
        {
            try
            {
                string? account = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (account is not null)
                {
                    return Ok(account);
                }
                return Unauthorized();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
