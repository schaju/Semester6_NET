using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Chat : DomainObject
    {
        public string Name { get; set; }
        public int Host { get; set; }
    }
}
