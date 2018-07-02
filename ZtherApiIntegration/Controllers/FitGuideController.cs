using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZtherApiIntegration.Common;

namespace ZtherApiIntegration.Controllers
{
    public class FitGuideController : BaseController
    {
        // GET: FitGuide
        [Route(UrlBuilder.FIT_GUIDE)]
        public ActionResult Index()
        {
            this.FillSeoInformation("Fit Guide");
            
            ViewBag.Scripts = new List<string>() { "fitguide.js" };
            return View(PathFromView("FitGuide"));
        }

        [Route(UrlBuilder.SIZE_CHARTS)]
        public ActionResult SizeCharts()
        {
            this.FillSeoInformation("Size Charts");

            return View(PathFromView("FitGuide"));
        }
    }
}