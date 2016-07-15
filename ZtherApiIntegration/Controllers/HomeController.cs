using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
    }
}