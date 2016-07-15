using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZtherApiIntegration.Common;

namespace ZtherApiIntegration.Controllers
{
    public class AboutController : BaseController
    {
        // GET: About
        [Route(UrlBuilder.ABOUT)]
        public ActionResult Index()
        {
            this.FillSeoInformation(UrlBuilder.ABOUT);
            
            return View(PathFromView("About"));
        }
    }
}