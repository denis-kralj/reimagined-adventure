using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReimaginedAdventure.Shared.Models;

namespace ReimaginedAdventure.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountCreateController : ApplicationController
    {
        private AccountManager _accountManager;

        public AccountCreateController(AccountManager accountManager)
        {
            _accountManager = accountManager;
        }

        [HttpPost]
        public async Task<AccountRegistrationResultModel> Post([FromBody]AccountRegistrationModel accountRegistrationModel, string returnUrl = "")
        {
            var result = await ValidateAndRegister(accountRegistrationModel);
            return new AccountRegistrationResultModel
            {
                ReturnUrl = string.IsNullOrEmpty(returnUrl) ? returnUrl : Url.Content("~/"),
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
