using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Base
{
    public class NamedDomainObject : DomainObject
    {
        public NamedDomainObject()
        {
            Name = string.Empty;
        }

        public string Name { get; set; }
    }
}
