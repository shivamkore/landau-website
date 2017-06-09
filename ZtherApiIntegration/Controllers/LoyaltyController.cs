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

        [Route("loyalty/faq")]
        public ActionResult Faq()
        {
            return View();
        }

        [Route("loyalty/disclaimer")]
        public ActionResult disclaimer()
        {
            return View();
        }
    }
}