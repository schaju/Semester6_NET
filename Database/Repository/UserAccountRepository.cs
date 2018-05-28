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
                "SELECT useraccount_id, useraccount_firstname, useraccount_lastname, useraccount_username, useraccount_statusmessage, useraccount_status FROM useraccount WHERE id = @id",
                new { id = id }).FirstOrDefault();
        }

        public UserAccount GetUserAccountByUsername(IDbConnection connection, string username)
        {
            return connection.Query<UserAccount>("SELECT useraccount_id, useraccount_firstname, useraccount_lastname, useraccount_username, useraccount_statusmessage, useraccount_status FROM useraccount WHERE useraccount_username = @username", new { username = username }).FirstOrDefault();
        }


        public long CountUserAccountByUsername(IDbConnection connection, string username)
        {
            return (long)connection.ExecuteScalar("SELECT count(*) FROM useraccount WHERE useraccount_username = @username", new { username = username });
        }

        public UserAccount GetUserAccountByUsernameAndPassword(IDbConnection connection, string username, string password)
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
                "SELECT useraccount_id, useraccount_firstname, useraccount_lastname, useraccount_username, useraccount_statusmessage, useraccount_status FROM useraccount").ToList();
        }

        public void Insert(IDbConnection connection, string firstname, string lastname, string username, string password, string statusMessage, byte[] userIcon, UserAccountStatus status)
        {

            string insertQuery = @"INSERT into useraccount(useraccount_firstname, useraccount_lastname, useraccount_username, useraccount_password, useraccount_statusmessage, useraccount_usericon, useraccount_status) " +
                                  "VALUES (@firstname, @lastname, @username, @password, @statusmessage, @usericon, @status)";

            var result = connection.Execute(insertQuery, new
            {
                firstname = firstname,
                lastname = lastname,
                username = username,
                password = password,
                statusmessage = statusMessage,
                usericon = userIcon,
                status = status
            });
        }

        public void Update(IDbConnection connection, UserAccount userAccount) {

            //TODO: if username and password can be change it is not nice to check in the where clause the id, not secure...
            string updateQuery =
                @"UPDATE useraccount SET useraccount_firstname = @firstname, useraccount_lastname = @lastname, useraccount_username = @username, " +
                "useraccount_password = @password, useraccount_statusmessage = @statusmessage, useraccount_usericon = @usericon, useraccount_status = @status " +
                "WHERE useraccount_id = @id";

            var result = connection.Execute(updateQuery, new
            {
                id = userAccount.Id,
                firstname = userAccount.FirstName,
                lastname = userAccount.LastName,
                username = userAccount.UserName,
                password = userAccount.Password,
                statusmessage = userAccount.StatusMessage,
                usericon = userAccount.UserIcon,
                status = (int) userAccount.UserAccountStatus
            });
        }
    }
}
