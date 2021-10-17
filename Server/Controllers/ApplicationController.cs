using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReimaginedAdventure.Server.Data;

namespace ReimaginedAdventure.Server.Controllers
{
    public abstract class ApplicationController : ControllerBase
    {
        private ApplicationDbContext _databaseContext;

        public ApplicationController(ApplicationDbContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public IdentityUser CurrentUser =>
            User.Identity.IsAuthenticated ?
            _databaseContext.Users.Single(u => u.Email == User.Identity.Name) :
            null;

        public string GenerateReturnUrl(string returnUrl) =>
            string.IsNullOrEmpty(returnUrl) ? returnUrl : Url.Content("~/");
    }
}
