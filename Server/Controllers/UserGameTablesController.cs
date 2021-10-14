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
    public class UserGameTablesController : ControllerBase
    {
        private readonly ApplicationDbContext _databaseContext;

        public UserGameTablesController(ApplicationDbContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpGet]
        public IEnumerable<GameTableListElementModel> Get() =>
            _databaseContext.GameTables
                .Where(t => t.Owner == _databaseContext.Users.Single(u => u.Email == User.Identity.Name))
                .Select(t => new GameTableListElementModel { Name = t.Name, Id = t.Id });
    }
}
