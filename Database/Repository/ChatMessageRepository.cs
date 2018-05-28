using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using Model;

namespace Database.Repository
{
    public class ChatMessageRepository
    {
        public IEnumerable<ChatMessage> GetChatsMessagesByChat(IDbConnection connection, int chatId)
        {
            return connection.Query<ChatMessage, UserAccount, ChatMessage>(
                "SELECT a.chat_messages_id, a.chat_messages_message, a.chat_messages_timestamp, b.useraccount_id, b.useraccount_firstname, b.useraccount_lastname, b.useraccount_username " +
                "FROM chat_messages a " +
                "JOIN useraccount b ON a.chat_messages_sender_id = b.useraccount_id " +
                "WHERE a.chat_messages_chat_id = @chatId",
                (chatmessage, useraccount) =>
                {
                    chatmessage.Sender = new UserAccount()
                    {
                        Id = useraccount.Id,
                        UserName = useraccount.UserName,
                        FirstName = useraccount.FirstName,
                        LastName = useraccount.LastName,
                    };
                    return chatmessage;
                },
                new
                {
                    chatId = chatId
                }, splitOn: "useraccount_id");
        }

        public void InsertChatMessage(IDbConnection connection, int chatId, int userId, string message)
        {
            string insertQuery = @"INSERT INTO chat_messages(chat_messages_chat_id, chat_messages_message, chat_messages_sender_id, chat_messages_timestamp) 
                                    VALUES (@ChatId, @Message, @SenderId, @Timestamp)";

            connection.Execute(insertQuery, new
                {
                    ChatId = chatId,
                    Message = message,
                    SenderId = userId,
                    Timestamp = DateTime.Now
                });
        }
    }
}