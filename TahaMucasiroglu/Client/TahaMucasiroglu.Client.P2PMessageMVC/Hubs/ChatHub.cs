using Microsoft.AspNetCore.SignalR;

namespace TahaMucasirogluBlog.Client.P2PMessage.TahaMucasirogluMVC.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string fromId, string toId, string encryptedMessage)
        {
            await Clients.All.SendAsync("ReceiveMessage", fromId, toId, encryptedMessage);
        }

        public async Task RequestConnection(string fromId, string toId)
        {
            await Clients.All.SendAsync("ConnectionRequest", fromId, toId);
        }

        public async Task ConnectionAccepted(string accepterId, string requesterId)
        {
            await Clients.All.SendAsync("ConnectionAccepted", accepterId, requesterId);
        }

        public async Task ConnectionRejected(string requesterId)
        {
            await Clients.All.SendAsync("ConnectionRejected", requesterId);
        }

        public async Task NotifyDisconnection(string connectionId)
        {
            await Clients.All.SendAsync("UserDisconnected", connectionId);
        }
    }
}
