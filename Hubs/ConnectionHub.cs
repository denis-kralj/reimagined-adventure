using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace reimagined_adventure
{
     public class ConnectionHub : Hub
     {
        public async Task NewMessage(long username, string message)
        {
            await Clients.All.SendAsync("messageReceived", username, message);
        }
     }
}