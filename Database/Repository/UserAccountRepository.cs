using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Model;
using Model.Enum;

namespace Database.Repository
{
    public class UserAccountRepository
    {
        public UserAccount Get(IDbConnection connection, int id)
        {
            return connection.Query<UserAccount>(
                "SELECT * FROM useraccount WHERE id = @id",
                new { id = id }).FirstOrDefault();
        }

        public long CountUserAccountByUsername(IDbConnection connection, string username)
        {
            return (long)connection.ExecuteScalar("SELECT count(*) FROM useraccount WHERE useraccount_username = @username", new { username = username });
        }

        public UserAccount GetByUsernameAndPassword(IDbConnection connection, string username, string password)
        {
            return connection.Query<UserAccount>(
                "SELECT * FROM useraccount WHERE useraccount_username = @username AND useraccount_password = @password",
                new
                {
                    username = username,
                    password = password
                }).FirstOrDefault();
        }

        public IEnumerable<UserAccount> GetAll(IDbConnection connection)
        {
            return connection.Query<UserAccount>(
                "SELECT * FROM useraccount").ToList();
        }

        public void Insert(IDbConnection connection, string firstname, string lastname, string username, string password, string statusMessage, byte[] userIcon)
        {

            string insertQuery = @"INSERT into useraccount(useraccount_firstname, useraccount_lastname, useraccount_username, useraccount_password, useraccount_statusmessage, useraccount_usericon) " +
                                  "VALUES (@firstname, @lastname, @username, @password, @statusmessage, @usericon)";

            var result = connection.Execute(insertQuery, new
            {
                firstname = firstname,
                lastname = lastname,
                username = username,
                password = password,
                statusmessage = statusMessage,
                usericon = userIcon
            });
        }

        public void UpdateUserAccountStatus(IDbConnection connection, LoginUserData loginUserData, UserAccountStatus status)
        {
            string updateQuery = @"UPDATE useraccount SET useraccount_status = @status WHERE useraccount_username = @username AND useraccount_password = @password";

            var result = connection.Execute(updateQuery, new
            {
                status = (int) status,
                username = loginUserData.UserName,
                password = loginUserData.Password
            });
        }
    }
}
