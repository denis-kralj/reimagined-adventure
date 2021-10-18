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
    public class AccountDataController : ApplicationController
    {
        private AccountManager _accountManager;

        public AccountDataController(AccountManager accountManager, ApplicationDbContext databaseContext) : base(databaseContext)
        {
            _accountManager = accountManager;
        }

        [HttpGet]
        public Task<AccountDataModel> Post()
        {
            return Task.FromResult(new AccountDataModel
            {
                IsAuthenticated = User?.Identity?.IsAuthenticated ?? false,
                Email = User?.Identity?.Name ?? string.Empty
            });
        }
    }
}
