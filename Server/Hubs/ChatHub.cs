using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using ReimaginedAdventure.Shared;

namespace ReimaginedAdventure.Server.Hubs
{
    public class ChatHub : Hub
    {
        private IChatStore _chatStore;

        public ChatHub(IChatStore chatStore)
        {
            _chatStore = chatStore;
        }
        public async Task SendMessage(User user, string message)
        {
            var newMessage = new ChatMessage
            {
                User = user,
                Message = message,
                Posted = DateTimeOffset.Now
            };

            _chatStore.PostMessage(newMessage);
            await Clients.All.SendAsync("MessagesUpdated", newMessage);
        }
    }
}