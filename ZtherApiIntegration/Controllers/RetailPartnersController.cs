using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZtherApiIntegration.Common;

namespace ZtherApiIntegration.Controllers
{
    public class RetailPartnersController : BaseController
    {
        // GET: RetailPartners
        [Route(UrlBuilder.RETAIL)]
        public ActionResult Index()
        {
            this.FillSeoInformation(UrlBuilder.RETAIL);

            return View(PathFromView("RetailPartners"));
        }
    }
}