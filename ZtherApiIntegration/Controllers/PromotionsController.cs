using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZtherApiIntegration.Common;

namespace ZtherApiIntegration.Controllers
{
    public class PromotionsController : BaseController
    {
        // GET: Promotions
        [Route(UrlBuilder.NEWS)]
        public ActionResult Index()
        {
            this.FillSeoInformation("Promotions");

            ViewBag.Scripts = new List<string>() { "promotions.js" };
            return View(PathFromView("Promotions"));
        }
    }
}