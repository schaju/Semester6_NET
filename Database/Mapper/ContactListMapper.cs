using System;
using System.Collections.Generic;
using System.Text;
using Dapper.FluentMap.Mapping;
using Model;

namespace Database.Mapper
{
    public class ContactListMapper : EntityMap<ContactListItem>
    {
        public ContactListMapper()
        {
            Map(x => x.ContactListsUserAccountId).ToColumn("contact_lists_useraccount_id");
            Map(x => x.ContactListsUserAccountOwnerId).ToColumn("contact_lists_useraccount_owner");
        }
    }
}
