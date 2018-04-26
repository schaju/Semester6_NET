using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using Model;

namespace Database.Repository
{
    public class ChatRepository
    {
        public IEnumerable<Chat> GetChatsByUserAccount(IDbConnection connection, string username, string password)
        {
            return connection.Query<Chat>(
                "SELECT a.* FROM chat a " +
                "JOIN chat_member b ON a.chat_id = b.chat_member_chat_id " +
                "JOIN useraccount c ON b.chat_member_user_id = c.useraccount_id " +
                "WHERE c.useraccount_username = @username AND c.useraccount_password = @password", new
                {
                    username = username,
                    password = password
                }).ToList();
        }
    }
}