using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Database.Repository;
using Model;

namespace WebService.Services
{
    public class ChatService
    {
        private ChatRepository repository;

        public ChatService()
        {
            this.repository = new ChatRepository();
        }

        public IEnumerable<Chat> GetChatsByUserAccount(IDbConnection connection, string username, string password)
        {
            return repository.GetChatsByUserAccount(connection, username, password);
        }
    }
}