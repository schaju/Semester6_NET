using System;
using System.Collections.Generic;
using System.Text;
using Dapper.FluentMap.Mapping;
using Model;

namespace Database.Mapper
{
    public class ChatMapper : EntityMap<Chat>
    {
        public ChatMapper()
        {
            Map(x => x.Id).ToColumn("chat_id");
            Map(x => x.Title).ToColumn("chat_title");

            Map(x => x.ChatMembers).Ignore();
            Map(x => x.ChatMessages).Ignore();
        }
    }
}
