using Microsoft.AspNetCore.SignalR;

namespace TestServer.Hubs
{
    public class UnityHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}