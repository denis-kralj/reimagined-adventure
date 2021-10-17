using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReimaginedAdventure.Shared.Models;

namespace ReimaginedAdventure.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountDataController : ApplicationController
    {
        private AccountManager _accountManager;

        public AccountDataController(AccountManager accountManager)
        {
            _accountManager = accountManager;
        }

        [HttpGet]
        public Task<AccountDataModel> Post()
        {

            return Task.FromResult(new AccountDataModel
            {
                IsAuthenticated = this.User.Identity.IsAuthenticated,
                Email = this.User.Identity.Name
            });
        }
    }
}
