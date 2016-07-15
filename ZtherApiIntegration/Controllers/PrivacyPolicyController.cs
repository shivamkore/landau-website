using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZtherApiIntegration.Common;

namespace ZtherApiIntegration.Controllers
{
    public class PrivacyPolicyController : BaseController
    {
        // GET: PrivacyPolicy
        [Route(UrlBuilder.PRIVACY_POLICY)]
        public ActionResult Index()
        {
            this.FillSeoInformation("Privacy Policy");
            return View(PathFromView("PrivacyPolicy"));
        }
    }
}