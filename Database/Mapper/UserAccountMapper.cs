using System;
using System.Collections.Generic;
using System.Text;
using Dapper.FluentMap.Mapping;
using Model;

namespace Database.Mapper
{
    public class UserAccountMapper : EntityMap<UserAccount>
    {
        public UserAccountMapper()
        {
            Map(x => x.Id).ToColumn("useraccount_id");
            Map(x => x.FirstName).ToColumn("useraccount_firstname");
            Map(x => x.LastName).ToColumn("useraccount_lastname");
            Map(x => x.UserName).ToColumn("useraccount_username");
            Map(x => x.Password).ToColumn("useraccount_password");
        }
    }
}
