using System;
using System.Collections.Generic;
using System.Configuration;
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
using BVSeoSdkDotNet.Config;
using BVSeoSdkDotNet.Content;
using BVSeoSdkDotNet.Model;
using BVSeoSdkDotNet.BVException;

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


                #region BAZAAR VOICE
                /** BAZAAR VOICE - BEGIN ***********************/

                var bvseoKey = ConfigurationManager.AppSettings["bvseo-key"].ToString();
                var bvseoRootFolder = ConfigurationManager.AppSettings["bvseo-root-folder"].ToString();
                var bvseoStaging = ConfigurationManager.AppSettings["bvseo-staging"].ToString();

                //Establish a new BVConfiguration. Properties within this configuration are typically set in bvconfig.properties.  
                //addProperty can be used to override configurations set in bvconfig.properties.
                BVConfiguration bvConfig = new BVSdkConfiguration();
                bvConfig.addProperty(BVClientConfig.CLOUD_KEY, bvseoKey);
                bvConfig.addProperty(BVClientConfig.BV_ROOT_FOLDER, bvseoRootFolder); //adjust this for each locale
                bvConfig.addProperty(BVClientConfig.STAGING, bvseoStaging);

                //Prepare pageURL and SubjectID/ProductID values.	
                String subjectID = product.Trim().ToUpper();
                String pageURL = Request.Url.ToString();

                //Set BV Parameters that are specific to the page and content type.
                BVParameters bvParam = new BVParameters();
                bvParam.BaseURI = pageURL.Contains("?") ? pageURL.Substring(0, pageURL.IndexOf("?")) : pageURL;
                bvParam.PageURI = Request.Url.ToString(); //this value is used to extract the page number from bv URL parameters
                bvParam.ContentType = new BVContentType(BVContentType.REVIEWS);
                bvParam.SubjectType = new BVSubjectType(BVSubjectType.PRODUCT);
                bvParam.SubjectId = subjectID;


                //Get content and place into strings, then output into the injection divs.
                BVUIContent bvOutput = new BVManagedUIContent(bvConfig);
                String sBvOutputSummary = bvOutput.getAggregateRating(bvParam);  //getAggregateRating delivers the AggregateRating section only
                String sBvOutputReviews = bvOutput.getReviews(bvParam);  //getReviews delivers the review content with pagination only

                ViewBag.OutputReviews = sBvOutputSummary + " " + sBvOutputReviews;
                

                /** BAZAAR VOICE - END ***********************/
                #endregion

                return BuildDetailView(model);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
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
                    var match = aSizeCategory.Value.Find(c => c.ColorCode == model.ProductDetail.DefaultColorCode );
                  
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