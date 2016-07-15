using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZtherApiIntegration.Models.Review;
using ZtherApiIntegration.API.Models;
using Microsoft.Rest;
using ZtherApiIntegration.Models;

namespace ZtherApiIntegration.API.Managers.Review
{

    public class ReviewFilter
    {
        public String Code { get; set; }
        public int PageNumber { get; set; }
        public int Size { get; set; }
    }

    public class ReviewSearchResult
    {
        public ReviewFilter Filter { get; set; }
        //public ReviewModel Result { get; set; }
    }

    public class ReviewManager
    {

        public static bool Create(ReviewItemModel reviewItemModel)
        {
            using (var client = new LandauPortalWebAPI())
            {

                var productReview = new ProductReviewCreate();

                productReview.Comments = reviewItemModel.Comments;                

                Char[] whitespace = new char[] { ' ', '\t' };
                String [] names = reviewItemModel.CommentatorName.Split(null);

                if (names.Count() > 0)
                {
                    if (names.Count() == 1) 
                    {
                        productReview.FirstName = names[0].Trim();
                        productReview.LastName = names[0].Trim();
                    }
                    else if (names.Count() == 2 || names.Count()>2)
                    {
                        productReview.FirstName = names[0].Trim();
                        productReview.LastName = reviewItemModel.CommentatorName.Replace(names[0], "").Trim();
                    }
                }
                productReview.ProductCode = reviewItemModel.ProductCode;
                productReview.Rating = Convert.ToInt16(reviewItemModel.Rating);
                /// Landau: Added Title, Location and Email.
                productReview.Title = reviewItemModel.Title;
                productReview.Location = reviewItemModel.Location;
                productReview.Email = reviewItemModel.Email;

                try 
                {
                    client.ProductReviews.Create(productReview.ProductCode, productReview);
                    return true;
                }
                catch (Exception e){
                    if (e is HttpOperationException)
                    {
                        var httpEx = (HttpOperationException)e;
                        return httpEx.Response.IsSuccessStatusCode;
                    }
                }
                return false;
            }
        }

        public static SeoModel GetReviewSeo(string code)
        {
            using (var client = new LandauPortalWebAPI())
            {
                var seoInfo = client.ProductReviews.GetAllByProduct(code, 1, 1);

                return new SeoModel() { PageTitle = seoInfo.Seo.PageTitle, PageDescription = seoInfo.Seo.MetaDescription };
            }
        }
    }
}