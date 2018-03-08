using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Message : DomainObject
    {
        public UserAccount Sender { get; set; }
        public UserAccount Recepiant { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
