using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Database
{
    public class ConnectionProvider
    {
        public IDbConnection GetConnection()
        {
            IDbConnection connection = new MySqlConnection("Server=dbsrv.infeo.at;Database=fhv_chat;Uid=fhv_chat_user;Pwd=test;Ssl Mode=None");
            connection.Open();
            return connection;
        }
    }
}
