using Microsoft.AspNet.SignalR;
using System;

namespace SignalRApp
{
    public class ChatHub : Hub
    {
        public void HerkeseGonder(string gonderen,string mesaj)
        {
            Clients.All.herkeseGonder(gonderen, mesaj,$"{DateTime.Now:g}");
        }
    }
}