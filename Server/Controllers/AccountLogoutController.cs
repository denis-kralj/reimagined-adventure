using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReimaginedAdventure.Shared.Models;

namespace ReimaginedAdventure.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountLogoutController : ControllerBase
    {
        private AccountManager _accountManager;

        public AccountLogoutController(AccountManager accountManager)
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
