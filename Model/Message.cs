using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Message : DomainObject
    {
        public User Sender { get; set; }
        public User Recepiant { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
