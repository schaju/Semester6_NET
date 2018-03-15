using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using Model;

namespace Database
{
    public class UserAccountRepository
    {
        public UserAccount Login(IDbConnection connection, string username, string password)
        {
            return connection.Query<UserAccount>(
                "SELECT * FROM useraccount WHERE useraccount_username = @username AND useraccount_password = @password",
                new
                {
                    username = username,
                    password = password
                }).FirstOrDefault();
        }

    }
}
