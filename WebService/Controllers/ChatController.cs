using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.Win32.SafeHandles;
using Model;
using WebService.Services;

namespace WebService.Controllers
{
    [RoutePrefix("api/chat")]
    public class ChatController : BaseController
    {
        private ChatService chatService;
        private ChatMemberService chatMemberService;
        private ChatMessageService chatMessageService;

        public ChatController()
        {
            this.chatService = new ChatService();
            this.chatMemberService = new ChatMemberService();
            this.chatMessageService = new ChatMessageService();
        }

        [HttpPost]
        [Route("chats")]
        public IHttpActionResult GetChats([FromBody] LoginUserData loginUserData)
        {
            using (IDbConnection connection = base.ConnectionProvider.GetMySqlConnection())
            {
                IEnumerable<Chat> chats =  chatService.GetChatsByUserAccount(connection, loginUserData.UserName, loginUserData.Password);
                foreach (Chat chat in chats)
                {
                    chat.ChatMembers =  new List<ChatMember>(chatMemberService.GetChatsMembersByChat(connection, chat.Id));
                    //could also be loaded just if the chat is clicked (if there are a lot of chats available)
                    chat.ChatMessages = new List<ChatMessage>(chatMessageService.GetChatsMessagesByChat(connection, chat.Id));
                }
                return Ok(chats);
            }
        }

        public void InsertChatMessage(int chatId, int userId, string message)
        {
            using (IDbConnection connection = base.ConnectionProvider.GetMySqlConnection())
            {
                chatMessageService.InsertChatMessage(connection, chatId, userId, message);
            }
        }
    }
}