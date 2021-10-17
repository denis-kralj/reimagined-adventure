using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReimaginedAdventure.Server.Data;
using ReimaginedAdventure.Shared;

namespace ReimaginedAdventure.Server.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class MessageController : ApplicationController
    {
        private IChatStore _chatStore;

        public MessageController(IChatStore chatStore, ApplicationDbContext databaseContext) : base(databaseContext)
        {
            _chatStore = chatStore;
        }
        [HttpGet]
        public IEnumerable<ChatMessage> Get()
        {
            return _chatStore.GetAllMessages().ToArray();
        }
    }
}
