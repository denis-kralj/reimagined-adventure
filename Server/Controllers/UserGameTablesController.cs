using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReimaginedAdventure.Server.Data;
using ReimaginedAdventure.Shared.Models;

namespace ReimaginedAdventure.Server.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class UserGameTablesController : ApplicationController
    {
        private readonly ApplicationDbContext _databaseContext;

        public UserGameTablesController(ApplicationDbContext databaseContext) : base(databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpGet]
        public IEnumerable<GameTableListElementModel> Get() =>
            _databaseContext.GameTables
            .Where(t => t.Owner == CurrentUser)
            .Select(t => new GameTableListElementModel(t.Name, t.Id));
    }
}
