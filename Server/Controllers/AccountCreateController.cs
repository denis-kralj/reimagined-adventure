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
    public class AccountCreateController : ApplicationController
    {
        private AccountManager _accountManager;

        public AccountCreateController(AccountManager accountManager, ApplicationDbContext databaseContext) : base(databaseContext)
        {
            _accountManager = accountManager;
        }

        [HttpPost]
        public async Task<AccountRegistrationResultModel> Post([FromBody] AccountRegistrationModel accountRegistrationModel, string returnUrl = "")
        {
            var result = await ValidateAndRegister(accountRegistrationModel);
            return new AccountRegistrationResultModel
            {
                ReturnUrl = GenerateReturnUrl(returnUrl),
                WasSuccessful = result.WasSuccessful,
                Errors = result.Errors
            };
        }

        private async Task<AccountCreationResult> ValidateAndRegister(AccountRegistrationModel accountRegistrationData)
        {
            return await _accountManager.RegisterNewUser(accountRegistrationData.ToRegistrationData());
        }
    }
}
