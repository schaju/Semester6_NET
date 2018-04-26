using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Database.Repository;
using Model;

namespace WebService.Services
{
    public class ChatMemberService
    {
        private ChatMemberRepository repository;

        public ChatMemberService()
        {
            this.repository = new ChatMemberRepository();
        }

        public IEnumerable<ChatMember> GetChatsMembersByChat(IDbConnection connection, int chatId)
        {
            return repository.GetChatMembersByChat(connection, chatId);
        }
    }
}