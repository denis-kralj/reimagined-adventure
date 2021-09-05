using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReimaginedAdventure.Shared.Models;

namespace ReimaginedAdventure.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountLoginController : ControllerBase
    {
        private AccountManager _accountManager;

        public AccountLoginController(AccountManager accountManager)
        {
            _accountManager = accountManager;
        }

        [HttpPost]
        public async Task<AccountLoginResultModel> Post([FromBody]AccountLoginModel accountLoginModel, string returnUrl = "")
        {
            var result = await _accountManager.LoginUserAsync(accountLoginModel.ToLoginData());
            return new AccountLoginResultModel
            {
                WasSuccessful = result.WasSuccessful,
                Errors = result.Errors,
                ReturnUrl = string.IsNullOrEmpty(returnUrl) ? returnUrl : Url.Content("~/")
            };
        }
    }
}
