using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class DomainObject
    {
        public const int NO_ID = -1;

        public DomainObject()
        {
            Id = NO_ID;
        }

        public int Id { get; set; }
    }
}
