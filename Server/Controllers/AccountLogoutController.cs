using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReimaginedAdventure.Server.Data;

namespace ReimaginedAdventure.Server.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class AccountLogoutController : ApplicationController
    {
        private AccountManager _accountManager;

        public AccountLogoutController(AccountManager accountManager, ApplicationDbContext databaseContext) : base(databaseContext)
        {
            _accountManager = accountManager;
        }

        [HttpGet]
        public async Task<RedirectResult> Get()
        {
            await _accountManager.LogoutUserAsync();
            return Redirect(Url.Content("~/"));
        }
    }
}
