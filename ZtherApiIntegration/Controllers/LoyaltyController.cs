using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZtherApiIntegration.Controllers
{
    public class LoyaltyController : Controller
    {
        [Route("loyalty")]
        public ActionResult Index()
        {
            return View();
        }
    }
}