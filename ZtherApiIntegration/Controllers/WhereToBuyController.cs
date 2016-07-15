using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using ZtherApiIntegration.API.Managers.WhereToBuy;
using ZtherApiIntegration.Common;
using ZtherApiIntegration.Models.WhereToBuy;

namespace ZtherApiIntegration.Controllers
{
    public class WhereToBuyController : BaseController
    {

        private const int PAGE_SIZE = 9;
        private const int DIAMOND_PAGE_SIZE = 999;

        // GET: WhereToBuy
        [Route(UrlBuilder.WHERE_TO_BUY)]
        public ActionResult Index()
        {
            this.FillSeoInformation("Where To Buy");

            ViewBag.Scripts = new List<string>() { "where_to_buy.js" };

            var model = new WhereToBuyModel();
            model.Countries = CountryManager.GetCountries();

            model.AllRetailList = RetailManager.GetByBrand(this.CurrentBrand);
            if (model.AllRetailList.Retailers != null)
            {
                //sort random
                model.AllRetailList.Retailers = model.AllRetailList.Retailers.OrderBy(x => Guid.NewGuid()).Take(12).ToList();
            }

            ViewBag.HasGoogleMaps = true;
            return View(PathFromView("WhereToBuy"), model);
        }

        // GET: WhereToBuyIntl
        //[Route("where-to-buy-intl")]
        public ActionResult WhereToBuyIntl(string countryCode)
        {
            countryCode = countryCode.ToUpper();

            ViewBag.Scripts = new List<string>() { "where_to_buy.js" };

            var model = new WhereToBuyIntlModel();
            model.Countries = CountryManager.GetCountries();

            model.RetailList = RetailManager.FindByCountry(this.CurrentBrand, countryCode, 1, PAGE_SIZE);
            model.SearchByDesc = model.Countries.Find(x => x.Code.Equals(countryCode)).Name;

            ViewBag.HasGoogleMaps = true;

            ViewBag.Title = model.RetailList.Seo.PageTitle;
            ViewBag.Description = model.RetailList.Seo.PageDescription;

            return View(PathFromView("WhereToBuyIntl"), model);
        }

        public ActionResult SearchRetailers(string filter)
        {
            if (!string.IsNullOrEmpty(filter))
            {
               //verify zip code
                int pageNum = 1;
                List<RetailModel> listRetailers = new List<RetailModel>();
                var model = new WhereToBuyModel();

                if (isFilterByZipCode(filter))
                {
                    model.RetailList = RetailManager.GetByZipCode(this.Session, filter, false, pageNum, PAGE_SIZE);
                    model.DiamondList = RetailManager.GetByZipCode(this.Session, filter, true, pageNum, DIAMOND_PAGE_SIZE);
                    model.SearchByDesc = "Zip Code";
                }
                else if(isFilterByCityAndState(filter))
                {
                    var splitString = filter.Split(',');
                    string city = splitString[0];
                    string state = splitString[1];

                    model.RetailList  = RetailManager.GetByCityAndState(this.Session,city ,state , false, pageNum, PAGE_SIZE);
                    model.DiamondList = RetailManager.GetByCityAndState(this.Session, city, state, true, pageNum, DIAMOND_PAGE_SIZE);
                }
                model.SearchByValue = filter;

                return RenderMultipleViews(new List<RenderViewInfo>() {
                                    new RenderViewInfo(){ ViewName="retailersView", ViewPath="~/Views/Partials/WhereToBuy/_DealersPartial.cshtml",Model= model} ,
                                    new RenderViewInfo(){ViewName="diamondsView",ViewPath="~/Views/Partials/WhereToBuy/_DiamondDealersPartial.cshtml", Model= model}});
            }
            return new EmptyResult();
        }

        private static bool isFilterByZipCode(string filter)
        {
            Regex regexZipCode = new Regex(@"^\d{5}?$");
	        Match matchZipCode = regexZipCode.Match(filter);
            return matchZipCode.Success;
        }

        private static bool isFilterByCityAndState(string filter)
        {
            Regex regexCityState = new Regex(@"^[\w\s]+,\s\w{2}$");
	        Match match = regexCityState.Match(filter);
            return match.Success;
        }

        public ActionResult RefreshRetailers(string filter, int pageNumber)
        {
            if (!string.IsNullOrEmpty(filter))
            {
                //verify zip code
                List<RetailModel> listRetailers = new List<RetailModel>();
                var model = new WhereToBuyModel();

                if (isFilterByZipCode(filter))
                {
                    model.RetailList = RetailManager.GetByZipCode(this.Session, filter, false, pageNumber, PAGE_SIZE);
                    model.SearchByDesc = "Zip Code";
                }
                else if (isFilterByCityAndState(filter))
                {
                    var splitString = filter.Split(',');
                    string city = splitString[0];
                    string state = splitString[1];

                    model.RetailList = RetailManager.GetByCityAndState(this.Session, city, state, false, pageNumber, PAGE_SIZE);
                }
                model.SearchByValue = filter;

                return PartialView(PathFromView("Partials/WhereToBuy/_DealersPartial"), model);
            }
            return new EmptyResult();

        }

        public ActionResult RefreshIntRetailers(string countryCode, int pageNumber)
        {
            if (!string.IsNullOrEmpty(countryCode))
            {
                ViewBag.Scripts = new List<string>() { "where_to_buy.js" };

                var model = new WhereToBuyIntlModel();
                model.Countries = CountryManager.GetCountries();

                model.RetailList = RetailManager.FindByCountry(this.CurrentBrand, countryCode, pageNumber, PAGE_SIZE);
                model.SearchByDesc = model.Countries.Find(x => x.Code.ToLower().Equals(countryCode.ToLower())).Name;

                ViewBag.Title = model.RetailList.Seo.PageTitle;
                ViewBag.Description = model.RetailList.Seo.PageDescription;

                return PartialView(PathFromView("Partials/WhereToBuy/_DealersIntlPartial"), model);
            }
            return new EmptyResult();

        }

    }
}
