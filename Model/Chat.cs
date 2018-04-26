using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Chat : DomainObject
    {
        public string Title { get; set; }
        public IEnumerable<ChatMember> ChatMembers { get; set; }
        public IEnumerable<ChatMessage> ChatMessages { get; set; }

        public string MembersString => String.Join(", ", ChatMembers.Select(m => $"{m.User.FirstName} {m.User.LastName}"));
    }
}
