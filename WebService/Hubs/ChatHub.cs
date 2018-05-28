using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace WebService.Hubs
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            // Call the addMessage method (which is lisened to in the MainChatWindow.xaml.cs) to update clients.
            Clients.All.addMessage(name, message);
        }
    }
}