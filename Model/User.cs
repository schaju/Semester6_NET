using System;

namespace Model
{
    public class User : DomainObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime LastLogin { get; set; }
    }
}
