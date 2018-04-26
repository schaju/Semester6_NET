using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Model;
using Model.Enum;

namespace Database.Repository
{
    public class ContactListRepository
    {
        public IEnumerable<UserAccount> GetContactListByUser(IDbConnection connection, string username, string password)
        {
            return connection.Query<UserAccount>(
                "SELECT c.useraccount_id, c.useraccount_firstname, c.useraccount_lastname, c.useraccount_username, c.useraccount_statusmessage FROM contact_lists a " +
                "JOIN useraccount b ON a.contact_lists_useraccount_owner = b.useraccount_id " +
                "JOIN useraccount c ON a.contact_lists_useraccount_id = c.useraccount_id " +
                "WHERE b.useraccount_username = @username and b.useraccount_password = @password", new
                {
                    username = username,
                    password = password
                }).ToList();
        }
    }
}