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
        public async Task<CreateGameTableResultModel> Post([FromBody] CreateGameTableModel createGameTableModel)
        {
            return await ValidateAndCreate(createGameTableModel);
        }

        private async Task<CreateGameTableResultModel> ValidateAndCreate(CreateGameTableModel createGameTableModel)
        {
            var result = new CreateGameTableResultModel();
            try
            {
                var newGameTable = Activator.CreateInstance<GameTable>();

                newGameTable.Name = createGameTableModel.Name;
                newGameTable.Description = createGameTableModel.Description ?? string.Empty;
                newGameTable.Owner = CurrentUser ?? throw new Exception("This should not happen");

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
