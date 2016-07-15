using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZtherApiIntegration.Common;

namespace ZtherApiIntegration.Controllers
{
    public class FitGuideTopsController : BaseController
    {
        // GET: FitGuideTops
        [Route(UrlBuilder.FIT_GUIDE_TOPS)]
        public ActionResult Index()
        {
            this.FillSeoInformation("Fit Guide Tops");

            ViewBag.Scripts = new List<string>() { "fitguide.js" };
            return View(PathFromView("FitGuideTops"));
        }
    }
}