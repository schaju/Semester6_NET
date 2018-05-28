using System.Collections.Generic;
using System.Data;
using Database;
using Database.Repository;
using Model;
using Model.Enum;

namespace WebService.Services
{
    public class UserAccountService
    {
        private UserAccountRepository repository;

        public UserAccountService()
        {
            this.repository = new UserAccountRepository();
        }

        public void Insert(IDbConnection connection, string firstname, string lastname, string username, string password, string statusMessage, List<byte> userIcon, UserAccountStatus status)
        {
            repository.Insert(connection, firstname, lastname, username, password, statusMessage, userIcon?.ToArray(), status);
        }

        public UserAccount GetUserAccountByUsername(IDbConnection connection, string userNameToAdd)
        {
            return repository.GetUserAccountByUsername(connection, userNameToAdd);
        }

        public long CountUserAccountByUsername(IDbConnection connection, string username)
        {
            return repository.CountUserAccountByUsername(connection, username);
        }

        public UserAccount GetUserAccountByUsernameAndPassword(IDbConnection connection, string username, string password)
        {
            return repository.GetUserAccountByUsernameAndPassword(connection, username, password);
        }

        public IEnumerable<UserAccount> GetContactListByUsernameAndPassword(IDbConnection connection, string username, string password)
        {
            ContactListRepository contactListRepository = new ContactListRepository();
            return contactListRepository.GetContactListByUser(connection, username, password);
        }

        public void Update(IDbConnection connection, UserAccount userAccount)
        {
            repository.Update(connection, userAccount);
        }
    }
}