using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using Model;

namespace Database.Repository
{
    public class ChatMemberRepository
    {
        public IEnumerable<ChatMember> GetChatMembersByChat(IDbConnection connection, int chatId)
        {
            return connection.Query<ChatMember, UserAccount, ChatMember>(
                "SELECT a.chat_member_id, a.chat_member_user_is_admin, b.useraccount_id, b.useraccount_username, b.useraccount_firstname, b.useraccount_lastname " +
                "FROM chat_member a " +
                "JOIN useraccount b ON a.chat_member_user_id = b.useraccount_id " +
                "WHERE a.chat_member_chat_id = @chatId",
                (chatMember, useraccount) =>
                {
                    chatMember.User = new UserAccount
                    {
                        Id = useraccount.Id,
                        UserName = useraccount.UserName,
                        FirstName= useraccount.FirstName,
                        LastName = useraccount.LastName,
                };
                    return chatMember;
                },
                new
                {
                    chatId = chatId
                },splitOn: "useraccount_id");
        }
    }
}