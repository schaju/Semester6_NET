using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Model;

namespace Database
{
    public class UserAccountBroker
    {
        public UserAccountBroker(ConnectionProvider provider)
        {
            this.provider = provider;
        }

        private ConnectionProvider provider;

        public UserAccount GetUser(string username, string password)
        {
            using (IDbConnection connection = provider.GetConnection())
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM useraccount WHERE useraccount_username = ?username AND useraccount_password = ?password";
                    command.AddParameter("?username", DbType.String, username);
                    command.AddParameter("?password", DbType.String, password);

                    IDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        UserAccount userAccount = new UserAccount();
                        userAccount.Id = (int) reader["useraccount_id"];
                        userAccount.FirstName = (string) reader["useraccount_firstname"];
                        userAccount.LastName = (string) reader["useraccount_lastname"];
                        userAccount.UserName = (string) reader["useraccount_username"];
                        userAccount.Password = (string) reader["useraccount_password"];
                        return userAccount;
                    }

                    throw new Exception("Username or password did not match.");
                }
            }
        }
    }
}
