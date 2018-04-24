using System;
using System.Collections.Generic;
using Model.Enum;

namespace Model
{
    public class UserAccount : DomainObject
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] UserIcon { get; set; }
        public string StatusMessage { get; set; }
        public UserAccountStatus UserAccountStatus { get; set; }

        public List<UserAccount> Contacts { get; set; }
    }
}
