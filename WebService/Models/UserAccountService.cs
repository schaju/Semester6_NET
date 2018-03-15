using System.Data;
using Database;
using Model;

namespace WebService.Models
{
    public class UserAccountService
    {
        private UserAccountRepository repository;

        public UserAccountService()
        {
            this.repository = new UserAccountRepository();
        }


        public UserAccount Register(IDbConnection connection, string username, string password, string firstname, string lastname, string email)
        {
            //TODO
            return null;
        }

        public bool Login(IDbConnection connection, string username, string password)
        {
            UserAccount userAccount = repository.Login(connection, username, password);
            return userAccount != null ? true : false;
        }

        public void Logout(string username)
        {
            //TODO
        }
    }
}