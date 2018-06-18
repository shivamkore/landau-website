using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZtherApiIntegration.API.Managers.Catalog;
using ZtherApiIntegration.Common;
using ZtherApiIntegration.Models;
using ZtherApiIntegration.Models.Catalog;

namespace ZtherApiIntegration.Controllers
{

    public class CatalogController : BaseController
    {
        public ActionResult IndexFit(string fit)
        {
            string fitFilter = null, category = null, collection = null;

            if (fit != null)
            {
                switch (fit)
                {
                    case UrlBuilder.CATALOG_CLASSIC_FIT:
                        fitFilter = "Classic Fit";
                        break;

                    case UrlBuilder.CATALOG_MODERN_FIT:
                        fitFilter = "Modern Fit";
                        break;

                    //case UrlBuilder.CATALOG_NATURAL_FIT:
                    //    fitFilter = "Natural Fit";
                    //    break;

                    case UrlBuilder.CATALOG_CONTEMPORARY_FIT:
                        fitFilter = "Contemporary Fit";
                        break;
                }

                try
                {
                    if (this.RouteData.Values["type"].ToString().ToLower() == "category")
                        category = this.RouteData.Values["selection"].ToString();
                    else if (this.RouteData.Values["type"].ToString().ToLower() == "collection")
                        collection = this.RouteData.Values["selection"].ToString();

                    return BuildCatalogHome(category, collection, fitFilter);
                }
                catch
                {
                    throw Utility.Exception404();
                }
            }
            else
                throw Utility.Exception404();
        }


        public ActionResult Index(string selection)
        {
            string category = null, collection = null;

            try
            {
                if (this.RouteData.Values["type"].ToString().ToLower() == "category")
                    category = selection;
                else if (this.RouteData.Values["type"].ToString().ToLower() == "collection")
                    collection = selection;

                return BuildCatalogHome(category, collection, null);
            }
            catch
            {
                throw Utility.Exception404();
            }
        }

        private ActionResult BuildCatalogHome(string category, string collection, string fitFilter)
        {
            string gender = null, genderFilter = null;

            gender = this.RouteData.Values["gender"].ToString().ToLower();
            genderFilter = Constants.GenderFilterFor(gender);
            
            ViewBag.Scripts = new List<string>() { "catalog.js" };

            var model = new CatalogModel();
            model.Selections = SelectionsManager.GetSelectionModel(this.CurrentBrand);

            this.BuildBreadcrumb(model.Selections.Breadcrumb, category, collection, gender, genderFilter);

            if (string.IsNullOrEmpty(gender) ||
                ((model.Selections.Breadcrumb.Category == null && !model.Selections.Breadcrumb.IsCategoryForNewProds) &&
                model.Selections.Breadcrumb.Collection == null))
                throw Utility.Exception404();

            //get filters
            model.Filters = FiltersManager.GetFilterModel(this.CurrentBrand, genderFilter);
            if (fitFilter != null)
            {
                var fit = model.Filters.FitTypes.Where(d => d.Name == fitFilter).FirstOrDefault();
                if (fit != null)
                    fit.Selected = true;
            }

            model.ProductList = ProductsManager.GetProducts(this.Session,
                new ProductListFilter()
                {
                    Brand = this.CurrentBrand,
                    ViewAll = false,
                    PageNumber = 1,
                    Collection = model.Selections.Breadcrumb.Collection != null ? model.Selections.Breadcrumb.Collection.Name : null,
                    Gender = genderFilter,
                    Category = model.Selections.Breadcrumb.Category != null ? model.Selections.Breadcrumb.Category.Name : null,
                    IsNew = model.Selections.Breadcrumb.IsCategoryForNewProds ? "true" : null,
                    Fit = string.IsNullOrEmpty(fitFilter) ? new List<string>() : new List<string>() { fitFilter }
                });

            model.Filters.FilterDisplay = model.ProductList.FilterDisplay;
            model.ProductList.DisplaySlider = !((category == "other-products") ||
                                                (category == "new-arrivals") ||
                                                (genderFilter == Constants.WOMEN_GENDER && category == "pre-washed") ||
                                                (genderFilter == Constants.MEN_GENDER && category == "pre-washed") ||
                                                (genderFilter == Constants.MEN_GENDER && category == "mens-ripstop"));

            ViewBag.Title = model.ProductList.Seo.PageTitle;
            ViewBag.Description = model.ProductList.Seo.PageDescription;

            return View(PathFromView("Catalog"), model);
        }

        public ActionResult ProductsFilter(bool viewAll, int pageNr, string collection, string gender, string category, List<string> fit, List<string> size, List<string> color, string sort)
        {
            var model = new CatalogModel();
            
            this.BuildBreadcrumb(model.Selections.Breadcrumb, category, collection, gender == Constants.MEN_GENDER ? "Men" : "Women", gender);
            
            model.ProductList = 
                ProductsManager.GetProducts(this.Session, 
                    new ProductListFilter() 
                    { 
                        Brand = this.CurrentBrand, 
                        ViewAll = viewAll, 
                        PageNumber = pageNr, 
                        Collection = model.Selections.Breadcrumb.Collection != null ? model.Selections.Breadcrumb.Collection.Name : null, 
                        Gender = gender, 
                        Category = model.Selections.Breadcrumb.Category != null ? model.Selections.Breadcrumb.Category.Name : null, 
                        Fit = fit, 
                        Size = size, 
                        Color = color, 
                        Sort = sort,
                        IsNew = model.Selections.Breadcrumb.IsCategoryForNewProds ? "true" : null
                    });

            return RenderMultipleViews(new List<RenderViewInfo>() { 
                                    new RenderViewInfo() {ViewName= "paginationView", ViewPath="~/Views/Partials/Catalog/_PaginationPartial.cshtml", Model=model.ProductList.Pagination },
                                    new RenderViewInfo(){ ViewName="groupsView", ViewPath="~/Views/Partials/Catalog/_ProductGroupPartial.cshtml",Model= model} ,
                                    new RenderViewInfo(){ViewName="rowsView", ViewPath="~/Views/Partials/Catalog/_ProductRowsPartial.cshtml", Model= model}});
        }

        private List<string> FilterToList(string filter)
        {
            var list = new List<string>();
            if (!string.IsNullOrEmpty(filter))
                list = filter.Split(';').Where(f => f.Trim() != "").ToList();


            return list;
        }
    }
}