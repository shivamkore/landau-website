using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZtherApiIntegration.API.Managers.Catalog;
using ZtherApiIntegration.API.Managers.Detail;
using ZtherApiIntegration.API.Models;
using ZtherApiIntegration.Common;
using ZtherApiIntegration.Models;


namespace ZtherApiIntegration.Controllers
{
    public class SearchController : BaseController
    {

        public readonly string Searchurl_UR = System.Configuration.ConfigurationManager.AppSettings["SearchURL_UR"];
        public readonly string Searchurl_SN = System.Configuration.ConfigurationManager.AppSettings["SearchURL_SN"];

        // GET: Search
        [Route(UrlBuilder.SEARCH)]
        public ActionResult Index(string search_term_string)
        {
            
        ViewBag.Title = "Landau Catalog";
            ViewBag.Scripts = new List<string>() { "catalog.js" };
            ViewBag.ViewAll = false;
            ViewBag.HasNoFollow = true;
           
            var product = Available(search_term_string);
           
           if( product != null && product.Brand == "UR" )
            {
                String url = string.Concat(Searchurl_UR, search_term_string);
                return Redirect(url);
            }
           else if (product != null && product.Brand == "SN")
            {
                String url = string.Concat(Searchurl_SN, search_term_string);
                return Redirect(url);
            }
            else
            {
                 var model = SearchProducts(false, 1, search_term_string);
                 return View(PathFromView("Search"), model);
                    
            }
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
                 model = ProductsManager.Search(new ProductListFilter() { Brand = this.CurrentBrand,  SearchKey = key, PageNumber = pageNr, ViewAll = viewAll });
                 return model;
        }

        public Product Available(string search_term_string)
        {
            Product product;
            product = ProductsManager.FindProduct(search_term_string);
            return product;
        }
    }
}
