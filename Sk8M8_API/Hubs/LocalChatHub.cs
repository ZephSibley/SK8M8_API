using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRChat.Hubs
{
    public class LocalChatHub : Hub
    {
        public async Task CarryMessage(
            double latitude,
            double longitude,
            string message
        )
        {

            var sender = Context.User?.Identity?.Name ?? "anonymous";
            await Clients.All.SendAsync("carryMessage", sender, message);
        }
    }
}