using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebService.Controllers
{
    public class ClientController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Test()
        {
            return Ok();
        }
    }
}