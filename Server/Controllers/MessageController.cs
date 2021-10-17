using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ReimaginedAdventure.Shared;

namespace ReimaginedAdventure.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ApplicationController
    {
        private IChatStore _chatStore;

        public MessageController(IChatStore chatStore)
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
