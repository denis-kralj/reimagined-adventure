using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReimaginedAdventure.Server.Data;
using ReimaginedAdventure.Shared.Models;

namespace ReimaginedAdventure.Server.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("[controller]")]
    public class AccountLoginController : ApplicationController
    {
        private AccountManager _accountManager;

        public AccountLoginController(AccountManager accountManager, ApplicationDbContext databaseContext) : base(databaseContext)
        {
            _accountManager = accountManager;
        }

        [HttpPost]
        public async Task<AccountLoginResultModel> Post([FromBody] AccountLoginModel accountLoginModel, string returnUrl = "")
        {
            var result = await _accountManager.LoginUserAsync(accountLoginModel.ToLoginData());
            return new AccountLoginResultModel
            {
                WasSuccessful = result.WasSuccessful,
                Errors = result.Errors,
                ReturnUrl = GenerateReturnUrl(returnUrl)
            };
        }
    }
}
