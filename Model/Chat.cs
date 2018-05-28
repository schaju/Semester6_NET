using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Chat : DomainObject
    {
        public string Title { get; set; }
        public List<ChatMember> ChatMembers { get; set; }
        public List<ChatMessage> ChatMessages { get; set; }

        public string MembersString => String.Join(", ", ChatMembers.Select(m => $"{m.User.FirstName} {m.User.LastName}"));
    }
}
