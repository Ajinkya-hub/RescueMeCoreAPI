using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace RescueMeCoreAPI.SignalRHubs
{
    public class BroadCastHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
