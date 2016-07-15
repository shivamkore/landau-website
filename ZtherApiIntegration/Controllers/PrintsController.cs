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
    public class PrintsController : BaseController
    {
        // GET: Prints
        [Route(UrlBuilder.PRINTS)]
        public ActionResult Index()
        {
            this.FillSeoInformation(UrlBuilder.PRINTS);
            ViewBag.Scripts = new List<string>() { "prints_solids.js" };

            var model = new SwatchListModel();
            model = SwatchManager.Prints(this.CurrentBrand);
            return View(PathFromView("Prints"), model);
        }

        public ActionResult GetProductsByColor(string color)
        {

            var model = new List<SwatchProductModel>();
            model = SwatchManager.PrintsProduct(this.CurrentBrand, color);
            return PartialView(PathFromView("Partials/Swatch/_SwatchProductsPartial"), model);
        }
    }
}