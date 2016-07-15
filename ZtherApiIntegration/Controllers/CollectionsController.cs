using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZtherApiIntegration.API.Managers.Collections;
using ZtherApiIntegration.Common;

namespace ZtherApiIntegration.Controllers
{
    public class CollectionsController : BaseController
    {
        // GET: Collections
        [Route(UrlBuilder.COLLECTIONS)]
        public ActionResult Index()
        {
            this.FillSeoInformation(UrlBuilder.COLLECTIONS);
            
            ViewBag.Scripts = new List<string>() { "collections.js" };

            var model = CollectionsManager.SeasonalCollections(this.CurrentBrand);

            return View(PathFromView("Collections"), model);
        }
    }
}