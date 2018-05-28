using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using Database;
using Model;
using Model.Enum;
using WebService.Services;

namespace WebService.Controllers
{
    [RoutePrefix("api/useraccount")]
    public class UserAccountController : BaseController
    {
        private UserAccountService service;

        public UserAccountController()
        {
            this.service = new UserAccountService();
        }

        [HttpPost]
        [Route("update")]
        public IHttpActionResult UpdateUserAccount([FromBody] UserAccount userAccount)
        {
            using (IDbConnection connection = base.ConnectionProvider.GetMySqlConnection())
            {
                if (string.IsNullOrEmpty(userAccount.FirstName) ||
                    string.IsNullOrEmpty(userAccount.LastName) ||
                    string.IsNullOrEmpty(userAccount.UserName) ||
                    string.IsNullOrEmpty(userAccount.Password))
                {
                    return BadRequest("Firstname, lastname, username and password must be set.");
                }

                service.Update(connection, userAccount);

                UserAccount loadedUserAccount = service.GetUserAccountByUsernameAndPassword(connection, userAccount.UserName, userAccount.Password);
                return Ok(loadedUserAccount);
            }
        }

        [HttpPost]
        [Route("registration")]
        public IHttpActionResult Registration([FromBody] UserAccount userAccount)
        {
            using (IDbConnection connection = base.ConnectionProvider.GetMySqlConnection())
            {
                if (string.IsNullOrEmpty(userAccount.FirstName) ||
                    string.IsNullOrEmpty(userAccount.LastName) ||
                    string.IsNullOrEmpty(userAccount.UserName) ||
                    string.IsNullOrEmpty(userAccount.Password))
                {
                    return BadRequest("Firstname, lastname, username and password must be set.");
                }

                long userAccountCount = service.CountUserAccountByUsername(connection, userAccount.UserName);

                if (userAccountCount > 0)
                {
                    return BadRequest("Username does already exist.");
                }

                service.Insert(connection, userAccount.FirstName, userAccount.LastName, userAccount.UserName, userAccount.Password, userAccount.StatusMessage, userAccount.UserIcon, UserAccountStatus.Active);

                UserAccount loadedUserAccount = service.GetUserAccountByUsernameAndPassword(connection, userAccount.UserName, userAccount.Password);
                return Ok(loadedUserAccount);
            }
        }

        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login([FromBody] LoginUserData loginUserData)
        {
            using (IDbConnection connection = base.ConnectionProvider.GetMySqlConnection())
            {
                UserAccount loadedUserAccount = service.GetUserAccountByUsernameAndPassword(connection, loginUserData.UserName, loginUserData.Password);

                if (loadedUserAccount != null && loadedUserAccount.UserAccountStatus == UserAccountStatus.Inactive)
                {
                    loadedUserAccount.UserAccountStatus = UserAccountStatus.Active;
                    service.Update(connection, loadedUserAccount);
                    return Ok(loadedUserAccount);
                }
                return Unauthorized();
            }
        }

        [HttpPost]
        [Route("logout")]
        public IHttpActionResult Logout([FromBody] LoginUserData loginUserData)
        {
            using (IDbConnection connection = base.ConnectionProvider.GetMySqlConnection())
            {
                UserAccount loadedUserAccount = service.GetUserAccountByUsernameAndPassword(connection, loginUserData.UserName, loginUserData.Password);
                loadedUserAccount.UserAccountStatus = UserAccountStatus.Inactive;
                service.Update(connection, loadedUserAccount);
                return Ok();
            }
        }

        [HttpPost]
        [Route("contacts")]
        public IHttpActionResult GetContacts([FromBody] LoginUserData loginUserData)
        {
            using (IDbConnection connection = base.ConnectionProvider.GetMySqlConnection())
            {
                IEnumerable<UserAccount> userContactList =
                    service.GetContactListByUsernameAndPassword(connection, loginUserData.UserName,
                        loginUserData.Password);
                return Ok(userContactList);
            }
        }
    }
}