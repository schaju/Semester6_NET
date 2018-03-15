using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;
using Database;
using WebService.Models;

namespace WebService.Controllers
{
    public class UserAccountController : BaseController
    {
        private UserAccountService service;

        public UserAccountController()
        {
            this.service = new UserAccountService();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok("YEAH");
        }

        [HttpPost]
        public IHttpActionResult Login(
            [FromBody]string username,
            [FromBody]string password)
        {
            using (IDbConnection connection = base.ConnectionProvider.GetMySqlConnection())
            {
                bool loginSuccessful = service.Login(connection, username, password);

                if (loginSuccessful)
                {
                    return Ok("Your are logged in.");
                }
                return BadRequest("Sorry, Login failed.");
            }
        }
    }
}