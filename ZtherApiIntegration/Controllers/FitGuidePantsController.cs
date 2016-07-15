using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZtherApiIntegration.Common;

namespace ZtherApiIntegration.Controllers
{
    public class FitGuidePantsController : BaseController
    {
        // GET: FitGuidePants
        [Route(UrlBuilder.FIT_GUIDE_PANTS)]
        public ActionResult Index()
        {
            this.FillSeoInformation("Fit Guide Pants");
            ViewBag.Scripts = new List<string>() { "fitguide.js" };
            return View(PathFromView("FitGuidePants"));
        }
    }
}