using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ChatMessage : DomainObject
    {
        public string Message { get; set; }
        public UserAccount Sender { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
