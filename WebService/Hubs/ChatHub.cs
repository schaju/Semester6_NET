using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Model;
using WebService.Controllers;

namespace WebService.Hubs
{
    public class ChatHub : Hub
    {
        public void Send(UserAccount user, int chatId, string message)
        {
            //insert message:
            ChatController controller = new ChatController();
            controller.InsertChatMessage(user.Id, chatId, message);

            ChatMessage chatMessage = new ChatMessage()
                {
                    Message = message,
                    Sender = user,
                    TimeStamp = new DateTime()
                };

            // Call the addMessage method (which is lisened to in the MainChatWindow.xaml.cs) to update clients.
            Clients.All.addMessage(chatId, chatMessage);
        }
    }
}