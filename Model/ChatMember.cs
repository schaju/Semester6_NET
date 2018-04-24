using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ChatMember : DomainObject
    {
        public Chat Chat { get; set; }
        public List<UserAccount> Users { get; set; }
    }
}
