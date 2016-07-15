using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZtherApiIntegration.API.Managers.Catalog;
using ZtherApiIntegration.Common;
using ZtherApiIntegration.Models;

namespace ZtherApiIntegration.Controllers
{
    public class SearchController : BaseController
    {
        // GET: Search
        [Route(UrlBuilder.SEARCH)]
        public ActionResult Index(string search_term_string)
        {
            ViewBag.Title = "Landau Catalog";
            ViewBag.Scripts = new List<string>() { "catalog.js" };
            ViewBag.ViewAll = false;
            ViewBag.HasNoFollow = true;

            var model = SearchProducts(false, 1, search_term_string);

            return View(PathFromView("Search"), model);
        }

        public ActionResult Paginate(string searchTerm, bool viewAll, int pageNr)
        {
            var model = SearchProducts(viewAll, pageNr, searchTerm);

            return PartialView(PathFromView("Partials/Search/_SearchPartial"), model);
        }

        private ProductListModel SearchProducts(bool viewAll, int pageNr, string key)
        {
            ViewBag.SearchKey = key;
            ViewBag.ViewAll = viewAll;

            ProductListModel model;
            if (string.IsNullOrEmpty(key))
                model = new ProductListModel();
            else
                model = ProductsManager.Search(new ProductListFilter() { Brand = this.CurrentBrand, SearchKey = key, PageNumber = pageNr, ViewAll = viewAll });
            return model;
        }
    }
}
