using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZtherApiIntegration.API.Managers.Catalog;
using ZtherApiIntegration.API.Managers.Detail;
using ZtherApiIntegration.Models;
using ZtherApiIntegration.Models.Catalog;
using ZtherApiIntegration.Models.Detail;
using ZtherApiIntegration.API.Managers.Review;
using ZtherApiIntegration.Common;

namespace ZtherApiIntegration.Controllers
{
    public class DetailController : BaseController
    {
        private const int PAGE_REVIEW_SIZE = 2;

        // GET: Product Detail
        public ActionResult Index(String product)
        {
            string category = null, collection = null, gender = null, genderFilter = null;

            try
            {
                if (this.RouteData.Values["type"].ToString().ToLower() == "category")
                    category = this.RouteData.Values["typeName"].ToString();
                else if (this.RouteData.Values["type"].ToString().ToLower() == "collection")
                    collection = this.RouteData.Values["typeName"].ToString();

                gender = this.RouteData.Values["gender"].ToString().ToLower();
                genderFilter = Constants.GenderFilterFor(gender);

                var bc = new BreadcrumbModel();
                this.BuildBreadcrumb(bc, category, collection, gender, genderFilter);

                if (string.IsNullOrEmpty(product) || string.IsNullOrEmpty(gender) || (bc.Category == null && bc.Collection == null))
                    throw Utility.Exception404();

                var model = GetDetailModelFromProduct(product, bc);

                if (model.ProductDetail == null || !ProductUrlIsCorrect(model.ProductDetail))
                    throw Utility.Exception404();

                return BuildDetailView(model);
            }
            catch
            {
                throw Utility.Exception404();
            }
        }        

        public ActionResult Canonical(String product)
        {
            try
            {
                var bc = new BreadcrumbModel();

                var model = GetDetailModelFromProduct(product, bc, false);

                if (!ProductUrlIsCorrect(model.ProductDetail))
                    throw Utility.Exception404();

                this.BuildBreadcrumb(bc, model.ProductDetail.DefaultCategory, model.ProductDetail.DefaultCollection, Constants.GenderFor(model.ProductDetail.DefaultGender), model.ProductDetail.DefaultGender.ToLower());

                //navigation should not be available since it's not entering from a catalog search

                model.IsCanonicalUrl = true;

                if (!String.IsNullOrEmpty(Request.QueryString["color"]))
                {                    
                    //color selected in previous page
                    model.SelectedColor = model.ColorsAndSizes.GetProductColorModel(Request.QueryString["color"]);
                    if (model.SelectedColor != null)
                    {
                        model.ProductImages = DetailManager.GetProductImageModelByColor(product, model.SelectedColor.ColorCode);
                    }
                }

                return BuildDetailView(model);
            }
            catch
            {
                throw Utility.Exception404();
            }
        }

        private bool ProductUrlIsCorrect(ProductDetailModel model)
        {
            return this.Request.Path.ToLower().EndsWith(UrlBuilder.GenerateSlug(model.Code, model.Name).ToLower());
        }

        private string NextProductUrl(string productId, BreadcrumbModel bc)
        {
            var nextPod = ProductsManager.NextProductCode(this.Session, productId);

            return BuildUrl(bc, nextPod);
        }

        private string PreviousProductUrl(string productId, BreadcrumbModel bc)
        {
            var prevProd = ProductsManager.PreviousProductCode(this.Session, productId);

            return BuildUrl(bc, prevProd);
        }

        private static string BuildUrl(BreadcrumbModel bc, ProductModel newProd)
        {
            if (newProd != null && (bc.Collection != null || (bc.Category != null)))
            {
                return UrlBuilder.BuildProductDetailUrl(bc, newProd.Code, newProd.Name);
            }
            else
                return "#";
        }

        private ActionResult BuildDetailView(DetailModel model)
        {
            ViewBag.Title = model.ProductDetail.Seo.PageTitle;
            ViewBag.Description = model.ProductDetail.Seo.PageDescription;
            ViewBag.Scripts = new List<string>() { "detail.js" };
            ViewBag.CanonicalUrl = UrlBuilder.BuildCanonicalProductDetailUrl(model.ProductDetail.Code, model.ProductDetail.Name);
            ViewBag.IsProductDetail = true;

            return View(PathFromView("Detail"), model);
        }

        private DetailModel GetDetailModelFromProduct(String productId, BreadcrumbModel bc, bool buildNavigation = true)
        {
            DetailModel model;

            if (!String.IsNullOrEmpty(productId))
            {
                model = DetailManager.GetModel(this.CurrentBrand, productId);

                model.Breadcrumb = bc;

                //search for default category size containing default color
                model.ProductDetail.DefaultCategorySize = model.ColorsAndSizes.ProductCategorySizes.Count > 0 ? model.ColorsAndSizes.ProductCategorySizes[0] : null;
                foreach (var aSizeCategory in model.ColorsAndSizes.AvailableColorsPerSizeCategory)
                {
                    var match = aSizeCategory.Value.Find(c => c.ColorCode == model.ProductDetail.DefaultColorCode);
                    if (match != null)
                    {
                        model.ProductDetail.DefaultCategorySize = aSizeCategory.Key;
                        break;
                    }
                }
                
                ReviewFilter reviewFilter = new ReviewFilter();
                reviewFilter.Code = productId;
                reviewFilter.PageNumber = 1;
                reviewFilter.Size = PAGE_REVIEW_SIZE;
                model.ProductReviews = DetailManager.GetProductReviewModel(reviewFilter);

                if (buildNavigation)
                    BuildProductsNavigation(productId, bc, model);
            }
            else
                model = new DetailModel();

            return model;
        }

        private void BuildProductsNavigation(String productId, BreadcrumbModel bc, DetailModel model)
        {
            model.NextProductUrl = NextProductUrl(productId, bc);
            model.PreviousProductUrl = PreviousProductUrl(productId, bc);
        }

        public ActionResult ReviewsPagination(string productId, int pageNumber)
        {
            var model = new DetailModel();

            ReviewFilter reviewFilter = new ReviewFilter();
            reviewFilter.Code = productId;
            reviewFilter.PageNumber = pageNumber;
            reviewFilter.Size = PAGE_REVIEW_SIZE;

            model.ProductReviews = DetailManager.GetProductReviewModel(reviewFilter);

            return PartialView("~/Views/Partials/Detail/_ReviewsPaginationPartial.cshtml", model);
        }

        public ActionResult ChangeProductImage(string productId, string color, string sizeCategory)
        {
            //decode size category
            sizeCategory = sizeCategory.Replace("_amp_", "'");

            var imgsModel = DetailManager.GetProductImageModelByColor(productId, color);
            var videoModel = DetailManager.GetProductVideoModel(productId);
            var sizesModel = DetailManager.GetSizesByColorAndSizeCategory(productId, color, sizeCategory);

            var detailModel = new DetailModel
            {
                ProductImages = imgsModel,
                ProductVideos = videoModel
            };

            return RenderMultipleViews(new List<RenderViewInfo>() { 
                                    new RenderViewInfo() {ViewName= "zoomedView", ViewPath="~/Views/Partials/Detail/_ZoomedImagePartial.cshtml", Model=imgsModel },                                    
                                    new RenderViewInfo(){ViewName="imagesView", ViewPath="~/Views/Partials/Detail/_ImagesPartial.cshtml", Model= detailModel},
                                    new RenderViewInfo(){ViewName="sizesView", ViewPath="~/Views/Partials/Detail/_SizesPartial.cshtml", Model= sizesModel},
                                    new RenderViewInfo(){ViewName="shareView", ViewPath="~/Views/Partials/Detail/_SocialSharePartial.cshtml", Model= imgsModel}});
        }
    }
}