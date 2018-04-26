using System;
using System.Collections.Generic;
using System.Text;
using Dapper.FluentMap.Mapping;
using Model;

namespace Database.Mapper
{
    public class ChatMemberMapper : EntityMap<ChatMember>
    {
        public ChatMemberMapper()
        {
            Map(x => x.Id).ToColumn("chat_member_id");
            Map(x => x.IsAdmin).ToColumn("chat_member_user_is_admin");
            Map(x => x.User).Ignore();
        }
    }
}
