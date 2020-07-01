using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZtherApiIntegration.Common;
using ZtherApiIntegration.Models.Catalog;

namespace ZtherApiIntegration.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            this.FillSeoInformation("Home");

            ViewBag.Scripts = new List<string>() { "homepage.js" };
            var model = new CatalogSelectionModel();
            return View(PathFromView("Index"));
        }

        [HttpPost]
        public ActionResult Index(string zipCode)
        {
            return Redirect(Common.UrlBuilder.BuildFullUrl(Common.UrlEnum.WHERE_TO_BUY) + "?filter=" + zipCode);
        }

        [HttpGet]
        [Route("write-a-review")]
        public ActionResult WriteReview(string pr_page_id)
        {
            var model = CommonService.GetPowerReviewModel(pr_page_id);

            return View(PathFromView("WriteReview"), model);
        }
    }
}