using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZtherApiIntegration.API.Managers.Catalog;
using ZtherApiIntegration.API.Managers.Seo;
using ZtherApiIntegration.API.Models;
using ZtherApiIntegration.Common;
using ZtherApiIntegration.Models;
using ZtherApiIntegration.Models.Catalog;

namespace ZtherApiIntegration.Controllers
{
    public class RenderViewInfo
    {
        public string ViewName { get; set; }
        public object Model { get; set; }
        public string ViewPath { get; set; }
    }

    public class BaseController : Controller
    {
        protected String RenderRazorViewToString(ControllerContext controllerContext, String viewName, Object model)
        {
            controllerContext.Controller.ViewData.Model = model;

            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(controllerContext, viewName);
                var viewContext = new ViewContext(controllerContext, viewResult.View, controllerContext.Controller.ViewData, controllerContext.Controller.TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(controllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }

        protected string PathFromView(string viewName)
        {
            return string.Format("~/Views/{0}.cshtml", viewName);
        }
        
        /// <summary>
        /// returns multiple views rendered with one model
        /// </summary>
        /// <param name="views">[name of the view - path of the view]</param>
        /// <returns></returns>
        protected JsonResult RenderMultipleViews(List<RenderViewInfo> views)
        {
            var values = new Dictionary<string, string>();

            foreach (var aView in views)
            {
                var render = RenderRazorViewToString(this.ControllerContext, aView.ViewPath, aView.Model);
                
                values[aView.ViewName] = render;
            }

            var result = Json(values, JsonRequestBehavior.AllowGet);

            return result;
        }


        protected string CurrentBrand 
        {
            get
            {
                return "LN";
            }
        }

        protected void BuildBreadcrumb(BreadcrumbModel breadCrumb, string category, string collection, string gender, string genderFilter)
        {
            breadCrumb.GenderFilter = genderFilter;
            breadCrumb.Gender = gender != null ? CultureInfo.CurrentCulture.TextInfo.ToTitleCase(gender.ToLower()) : null;

            if (category != null)
            {
                switch (category.ToLower())
                {                    
                    case UrlBuilder.CATALOG_NEW_ARRIVALS:
                        {
                            breadCrumb.Category = new DropDownModel() { Name = "new arrivals", Value = category.ToLower() };
                            breadCrumb.IsCategoryForNewProds = true;
                            break;
                        }
                    case UrlBuilder.CATALOG_TOPS_NEW:
                        {
                            breadCrumb.Category = new DropDownModel() { Name = "tops", Value = category.ToLower() };
                            breadCrumb.IsCategoryForNewProds = true;
                            break;
                        }
                    default:
                        {
                            var obj = SelectionsManager.GetCategoryByName(this.CurrentBrand, category, genderFilter);

                            if (obj != null)
                                breadCrumb.Category = new DropDownModel() { Name = obj.Name, Value = obj.Value };
                            break;
                        }
                }
            }

            if (collection != null)
            {
                var obj = SelectionsManager.GetCollectionByName(this.CurrentBrand, collection, genderFilter);

                if (obj != null)
                    breadCrumb.Collection = new DropDownModel() { Name = obj.Name, Value = obj.Value };
            }
        }

        protected void FillSeoInformation(string pageName)
        {
            string name = pageName;
            string desc = "";
            try
            {
                var seo = SeoManager.GetSeoInformation(this.CurrentBrand, pageName);
                name = seo.PageTitle;
                desc = seo.MetaDescription;
            }
            catch { }

            ViewBag.Title = name;
            ViewBag.Description = desc;
        }
    }
}