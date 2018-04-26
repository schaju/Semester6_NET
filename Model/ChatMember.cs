using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ChatMember : DomainObject
    {
        public UserAccount User { get; set; }
        public bool IsAdmin { get; set; }
    }
}
