using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Database;

namespace WebService.Controllers
{
    public class BaseController : ApiController
    {
        public ConnectionProvider ConnectionProvider;

        public BaseController()
        {
            ConnectionProvider = new ConnectionProvider();
        }
    }
}