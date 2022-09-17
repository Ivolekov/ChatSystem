using Chat.Server.Controllers;
using Chat.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Chat.Server.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IDictionary<string, string> _connectionsUser;

        public ChatHub(IDictionary<string, string> connectionsUser)
        {
            _connectionsUser = connectionsUser;
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            if (_connectionsUser.TryGetValue(Context.ConnectionId, out string username))
            {
                _connectionsUser.Remove(username);
            }
            
            return base.OnDisconnectedAsync(exception);
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public async Task AddUserToChatSystem(string connectionId, string username) 
        {
            if (!string.IsNullOrEmpty(username))
            {
                _connectionsUser[username] = connectionId;
            }
        }

        public async Task SendMessage(Message message)
        {
            var connectionId = _connectionsUser.FirstOrDefault(x => x.Key == message.ReceiverName).Value;
            await Clients.Client(connectionId).SendAsync("receiveMessage", message.Text);
        }

        public async Task SendOnlineUsernames() 
        {
            var usernamesList = _connectionsUser.Keys.ToList();
            await Clients.All.SendAsync("receiveOnlineUsernames", _connectionsUser);
        }
    }
}
