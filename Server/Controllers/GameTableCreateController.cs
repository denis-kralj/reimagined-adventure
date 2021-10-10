using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReimaginedAdventure.Server.Data;
using ReimaginedAdventure.Shared.Models;

namespace ReimaginedAdventure.Server.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class GameTableCreateController : ControllerBase
    {
        private readonly UserAccountDbContext _databaseContext;
        public GameTableCreateController(UserAccountDbContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpPost]
        public async Task<CreateGameTableResultModel> Post([FromBody]CreateGameTableModel gameTableCreateModel)
        {
            var result = await ValidateAndCreate(gameTableCreateModel);
            return new CreateGameTableResultModel
            {
                ReturnUrl = Url.Content("~/"),
                WasSuccessful = result.WasSuccessful,
                Errors = result.Errors
            };
        }

        private async Task<AccountCreationResult> ValidateAndCreate(CreateGameTableModel accountRegistrationData)
        {
            var result = new AccountCreationResult();
            try
            {
                //TODO: validation serverside
                var userData = _databaseContext.Users.Single(u => u.Email == this.User.Identity.Name);
                var newGameTable = Activator.CreateInstance<GameTable>();

                newGameTable.Name = accountRegistrationData.Name;
                newGameTable.Description = accountRegistrationData.Description ?? string.Empty;
                newGameTable.Owner = userData;

                await _databaseContext.AddAsync(newGameTable);
                await _databaseContext.SaveChangesAsync();
                result.WasSuccessful = true;
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
                result.WasSuccessful = false;
            }

            return result;
        }
    }
}
