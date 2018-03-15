using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;
using Database;
using Model;
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

        [HttpPost]
        [ActionName("login")]
        public IHttpActionResult Login([FromBody] UserAccount userAccount)
        {
            using (IDbConnection connection = base.ConnectionProvider.GetMySqlConnection())
            {
                bool loginSuccessful = service.Login(connection, userAccount.UserName, userAccount.Password);

                if (loginSuccessful)
                {
                    return Ok("Your are logged in.");
                }

                return BadRequest("Sorry, Login failed.");
            }
        }

        [HttpGet]
        [ActionName("logout")]
        public IHttpActionResult Logout(string username)
        {
            using (IDbConnection connection = base.ConnectionProvider.GetMySqlConnection())
            {
                //TODO
            }

            return null;
        }

        //[HttpPost]
        //[Route("Insert")]
        //public IHttpActionResult Insert(UserAccount userAccount)
        //{
        //    using (IDbConnection connection = base.ConnectionProvider.GetMySqlConnection())
        //    {
        //        int result = service.Save(connection, item);
        //        return Ok(new { id = result });
        //    }
        //}

        //[HttpPut]
        //[Route("Update")]
        //public IHttpActionResult Update(int id, [FromBody]Tour item)
        //{
        //    using (IDbConnection connection = base.ConnectionProvider.GetMySqlConnection())
        //    {
        //        Tour oldItem = service.Get(connection, id);
        //        if (oldItem == null)
        //        {
        //            return NotFound();
        //        }

        //        int result = service.Save(connection, item);
        //        return Ok(new { id = result });
        //    }
        //}

        //[HttpDelete]
        //[Route("{id}")]
        //public IHttpActionResult Delete(int id)
        //{
        //    using (IDbConnection connection = base.ConnectionProvider.GetMySqlConnection())
        //    {
        //        int rows = service.Delete(connection, id);
        //        return Ok(new { count = rows });


        //    }
        //}
    }
}