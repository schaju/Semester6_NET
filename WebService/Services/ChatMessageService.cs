using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Database.Repository;
using Model;

namespace WebService.Services
{
    public class ChatMessageService
    {
        private ChatMessageRepository repository;

        public ChatMessageService()
        {
            this.repository = new ChatMessageRepository();
        }

        public IEnumerable<ChatMessage> GetChatsMessagesByChat(IDbConnection connection, int chatId)
        {
            return repository.GetChatsMessagesByChat(connection, chatId);
        }

        public void InsertChatMessage(IDbConnection connection, int chatId, int userId, string message)
        {
            repository.InsertChatMessage(connection, chatId, userId, message);
        }
    }
}