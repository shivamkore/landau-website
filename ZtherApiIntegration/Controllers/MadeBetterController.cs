using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZtherApiIntegration.Common;

namespace ZtherApiIntegration.Controllers
{
    public class MadeBetterController : BaseController
    {
        // GET: MadeBetter
        [Route(UrlBuilder.MAD_BETTER)]
        public ActionResult Index()
        {
            this.FillSeoInformation("Made Better ");

            return View(PathFromView("MadeBetter"));
        }
    }
}
