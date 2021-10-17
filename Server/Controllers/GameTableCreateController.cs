using System;
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
    public class GameTableCreateController : ApplicationController
    {
        private readonly ApplicationDbContext _databaseContext;
        public GameTableCreateController(ApplicationDbContext databaseContext) : base(databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpPost]
        public async Task<CreateGameTableResultModel> Post([FromBody] CreateGameTableModel gameTableCreateModel)
        {
            var result = await ValidateAndCreate(gameTableCreateModel);
            return new CreateGameTableResultModel
            {
                ReturnUrl = Url.Content("~/"),
                WasSuccessful = result.WasSuccessful,
                Errors = result.Errors
            };
        }

        private async Task<AccountCreationResult> ValidateAndCreate(CreateGameTableModel createGameData)
        {
            var result = new AccountCreationResult();
            try
            {
                var newGameTable = Activator.CreateInstance<GameTable>();

                newGameTable.Name = createGameData.Name;
                newGameTable.Description = createGameData.Description ?? string.Empty;
                newGameTable.Owner = CurrentUser;

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
