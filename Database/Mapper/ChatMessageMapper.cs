using System;
using System.Collections.Generic;
using System.Text;
using Dapper.FluentMap.Mapping;
using Model;

namespace Database.Mapper
{
    public class ChatMessageMapper : EntityMap<ChatMessage>
    {
        public ChatMessageMapper()
        {
            Map(x => x.Id).ToColumn("chat_messages_id");
            Map(x => x.Message).ToColumn("chat_messages_message");
            Map(x => x.TimeStamp).ToColumn("chat_messages_timestamp");

            Map(x => x.Sender).Ignore();
        }
    }
}
