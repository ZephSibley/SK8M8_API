using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace PrivateChat
{
    public class PrivateChatHub : Hub
    {
        private readonly static ConnectionMapping<string> _connections = new ConnectionMapping<string>();

        public void Send(string message)
        {
            string name = Context.QueryString["name"];

            Clients.All.SendAsync(name + ": " + message);
        }

        public void Send(string who, string message)
        {
            string name = Context.QueryString["name"];

            foreach (var connectionId in _connections.GetConnections(who))
            {
                Clients.Client(connectionId).SendAsync(name + ": " + message);
            }
        }

        public override Task OnConnectedAsync()
        {
            string name = Context.QueryString["name"];

            _connections.Add(name, Context.ConnectionId);

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            string name = Context.QueryString["name"];

            _connections.Remove(name, Context.ConnectionId);

            return base.OnDisconnectedAsync(exception);
        }
    }
}