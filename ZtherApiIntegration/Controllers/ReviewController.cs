using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZtherApiIntegration.Models.Review;
using ZtherApiIntegration.API.Managers.Detail;
using ZtherApiIntegration.API.Managers.Review;
using ZtherApiIntegration.Models.Detail;

namespace ZtherApiIntegration.Controllers
{
    public class ReviewController : BaseController
    {
        [HttpGet]
        public ActionResult Index(String product)
        {
            SetSeoInformation(product);
            ViewBag.Scripts = new List<string>() { "review.js" };
            ViewBag.HasNoFollow = true;
            ReviewItemModel reviewItemModel = new ReviewItemModel();

            try
            {
                reviewItemModel.BreadCrumbAndProductId = product;

                ProductDetailModel productDetail = DetailManager.GetProductDetailModel(product);
                reviewItemModel.ProductCode = productDetail.Code;
                reviewItemModel.ProductDescription = productDetail.Description;
                reviewItemModel.ProductName = productDetail.Name;
                reviewItemModel.ProductImage = productDetail.Image;
                reviewItemModel.Rating = "5";
                reviewItemModel.Average = DetailManager.GetProductReviewAverage(product);

            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
            return View(PathFromView("Review"), reviewItemModel);
        }

        [HttpPost]
        public ActionResult Index(ReviewItemModel reviewItemModel)
        {
            SetSeoInformation(reviewItemModel.ProductCode);
            ViewBag.Scripts = new List<string>() { "review.js" };
            ViewBag.HasNoFollow = true;

            if (ModelState.IsValid && reviewItemModel.Email.ToLower().Trim() == reviewItemModel.EmailConfirmation.ToLower().Trim())
            {
                //TODO -> review validation
                var ok = ReviewManager.Create(reviewItemModel);
                if (ok)
                    return Redirect(this.Request.Url.AbsoluteUri + "/" + Common.UrlBuilder.REVIEW_THANK_YOU);
                return Redirect(this.Request.Url.AbsoluteUri.Replace("/review/", "/"));
            }

            return View(PathFromView("Review"), reviewItemModel);
        }

        public ActionResult ReviewConfirmation()
        {
            ViewBag.ProductUrl = this.Request.Url.AbsoluteUri.Replace("/review/", "/").Replace("/" + Common.UrlBuilder.REVIEW_THANK_YOU, "");
            ViewBag.HasNoFollow = true;
            return View(PathFromView("ReviewConfirmation"));
        }

        private void SetSeoInformation(String product)
        {
            var seo = ReviewManager.GetReviewSeo(product);
            ViewBag.Title = seo.PageTitle;
            ViewBag.Description = seo.PageDescription;
            ViewBag.HasNoFollow = true;
        }

    }
}
