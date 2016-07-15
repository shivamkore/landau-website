using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZtherApiIntegration.API.Managers.Swatch;
using ZtherApiIntegration.Common;
using ZtherApiIntegration.Models.Swatch;

namespace ZtherApiIntegration.Controllers
{
    public class SolidsController : BaseController
    {
        // GET: Prints
        [Route(UrlBuilder.SOLIDS)]
        public ActionResult Index()
        {
            this.FillSeoInformation(UrlBuilder.SOLIDS);

            ViewBag.Scripts = new List<string>() { "prints_solids.js" };

            var model = SwatchManager.Solids(this.CurrentBrand);
            return View(PathFromView("Solids"), model);
        }

        public ActionResult GetProductsByColor(string color)
        {

            var model = new List<SwatchProductModel>();
            model = SwatchManager.SolidsProduct(this.CurrentBrand, color);
            return PartialView(PathFromView("Partials/Swatch/_SwatchProductsPartial"), model);
        }
    }
}