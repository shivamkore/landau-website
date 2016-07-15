using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using ZtherApiIntegration.Models.Catalog;

namespace ZtherApiIntegration.Common
{

    public enum UrlEnum
    {
        [Description(UrlBuilder.WHERE_TO_BUY)]
        WHERE_TO_BUY,

        [Description(UrlBuilder.WHERE_TO_BUY_INTL)]
        WHERE_TO_BUY_INTL,

        [Description(UrlBuilder.SOLIDS)]
        SOLIDS,

        [Description(UrlBuilder.PRINTS)]
        PRINTS,

        [Description(UrlBuilder.COLLECTIONS)]
        COLLECTIONS,

        [Description(UrlBuilder.GROUPS)]
        GROUPS,

        [Description(UrlBuilder.ABOUT)]
        ABOUT,

        [Description(UrlBuilder.CONTACT)]
        CONTACT,

        [Description(UrlBuilder.FAQ)]
        FAQ,

        [Description(UrlBuilder.MAD_BETTER)]
        MAD_BETTER,

        [Description(UrlBuilder.FIT_GUIDE)]
        FIT_GUIDE,

        [Description(UrlBuilder.FIT_GUIDE_PANTS)]
        FIT_GUIDE_PANTS,

        [Description(UrlBuilder.FIT_GUIDE_TOPS)]
        FIT_GUIDE_TOPS,

        [Description(UrlBuilder.RETAIL)]
        RETAIL,

        [Description(UrlBuilder.FAVS)]
        FAVS,

        [Description(UrlBuilder.FAVS_EMAIL)]
        FAVS_EMAIL,

        [Description(UrlBuilder.NEWS)]
        NEWS,

        [Description(UrlBuilder.PRIVACY_POLICY)]
        PRIVACY_POLICY,

        [Description(UrlBuilder.SIZE_CHARTS)]
        SIZE_CHARTS,

        [Description(UrlBuilder.SEARCH)]
        SEARCH,

        [Description(UrlBuilder.ERROR)]
        ERROR
    }

    public class UrlBuilder
    {
        public const string NEWS = "news";
        public const string WHERE_TO_BUY = "where-to-buy";
        public const string WHERE_TO_BUY_INTL = "where-to-buy-intl";
        public const string SOLIDS = "solids";
        public const string PRINTS = "prints";
        public const string COLLECTIONS = "collections";
        public const string GROUPS = "group-order";
        public const string ABOUT = "about";
        public const string CONTACT = "contact";
        public const string CONTACT_THANK_YOU = CONTACT + "/success";
        public const string GROUP_THANK_YOU = GROUPS + "/success";
        public const string SIGNUP_THANK_YOU = "email-sign-up";
        public const string REVIEW_THANK_YOU = "success";
        public const string FAQ = "faqs";
        public const string FAQ_THANK_YOU = FAQ + "/success";
        public const string MAD_BETTER = "made-better";
        public const string FIT_GUIDE = "fit-guide";
        public const string FIT_GUIDE_PANTS = "fit-guide-pants";
        public const string FIT_GUIDE_TOPS = "fit-guide-tops";
        public const string SIZE_CHARTS = "size-charts";
        public const string RETAIL = "login";
        public const string FAVS = "favorites";
        public const string FAVS_EMAIL = "favorites-email";
        public const string PRIVACY_POLICY = "privacy-policy";
        public const string SEARCH = "search-results";
        public const string ERROR = "404";
        public const string CATALOG_NEW_ARRIVALS = "new-arrivals";
        public const string CATALOG_TOPS_NEW = "tops-new";
        public const string CATALOG_MODERN_FIT = "modern-fit";
        public const string CATALOG_NATURAL_FIT = "natural-fit";
        public const string CATALOG_CLASSIC_FIT = "classic-fit";

        public static string BuildFullUrl(UrlEnum anUrl)
        {
            return string.Format("{0}://{1}/{2}", HttpContext.Current.Request.Url.Scheme, HttpContext.Current.Request.Url.Authority, Utility.ToDescription(anUrl));
        }

        public static string BuildProductDetailUrl(BreadcrumbModel breadcrumb, string productCode, string productName)
        {
            var prodUrl = GenerateSlug(productCode, productName);
            var fullUrl = string.Format("{0}://{1}/{2}/{3}", HttpContext.Current.Request.Url.Scheme, HttpContext.Current.Request.Url.Authority, BreadcrumbAsUrl(breadcrumb), prodUrl);

            return fullUrl.ToLower();
        }

        public static string BuildCanonicalProductDetailUrl(string productCode, string productName)
        {
            var prodUrl = GenerateSlug(productCode, productName);
            var fullUrl = string.Format("{0}://{1}/{2}", HttpContext.Current.Request.Url.Scheme, HttpContext.Current.Request.Url.Authority, prodUrl);

            return fullUrl.ToLower();
        }


        public static string BuildCanonicalProductDetailUrlWithColor(string productCode, string productName, string colorCode)
        {
            if (string.IsNullOrEmpty(colorCode))
            {
                return BuildCanonicalProductDetailUrl(productCode, productName);
            }

            var prodUrl = GenerateSlug(productCode, productName);
            var fullUrl = string.Format("{0}://{1}/{2}?color={3}", HttpContext.Current.Request.Url.Scheme, HttpContext.Current.Request.Url.Authority, prodUrl, colorCode);

            return fullUrl.ToLower();
        }

        public static string BuildProductReviewUrl(BreadcrumbModel breadcrumb, string productCode, string productName)
        {
            var prodUrl = GenerateSlug(productCode, productName);
            var fullUrl = string.Format("{0}://{1}/{2}/review/{3}", HttpContext.Current.Request.Url.Scheme, HttpContext.Current.Request.Url.Authority, BreadcrumbAsUrl(breadcrumb), prodUrl);

            return fullUrl.ToLower();
        }

        public static string BuildCatalogUrl(BreadcrumbModel breadcrumb)
        {
            var fullUrl = string.Format("{0}://{1}/{2}", HttpContext.Current.Request.Url.Scheme, HttpContext.Current.Request.Url.Authority, BreadcrumbAsUrl(breadcrumb));

            return fullUrl.ToLower();
        }

        public static string BuildCollectionUrl(string gender, string collection)
        {
            return BuildCatalogUrl(gender, "collection", collection);
        }

        public static string BuildCategoryUrl(string gender, string category)
        {
            return BuildCatalogUrl(gender, "category", category);
        }

        public static string BuildCategoryPantsWithFitUrl(string gender, string fit)
        {
            return BuildCatalogUrl(gender, "category/pants", fit);
        }

        private static string BuildCatalogUrl(string gender, string type, string typeName)
        {
            if (string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(typeName))
                return "#";

            var fullUrl = string.Format("{0}://{1}/{2}/{3}/{4}", HttpContext.Current.Request.Url.Scheme, HttpContext.Current.Request.Url.Authority, Constants.GenderFor(gender), type, typeName);

            return fullUrl.ToLower();
        }

        public static string BuildInternationalRetailerUrl(string countryCode)
        {
            var fullUrl = string.Format("{0}/{1}", BuildFullUrl(UrlEnum.WHERE_TO_BUY_INTL), countryCode);

            return fullUrl.ToLower();
        }

        public static string BuildHomeUrl()
        {
            var fullUrl = string.Format("{0}://{1}", HttpContext.Current.Request.Url.Scheme, HttpContext.Current.Request.Url.Authority);
            return fullUrl.ToLower();
        }

        private static string BreadcrumbAsUrl(BreadcrumbModel breadcrumb)
        {
            /// Landau: Replaces the code to fix issue with some products produces bad product review url.
            var url = string.Empty;

            if (breadcrumb.Collection != null)
            {
                url = "collection/" + GenerateSlug(breadcrumb.Collection.Value);
            }
            else if (breadcrumb.Category != null)
            {
                url = "category/" + GenerateSlug(breadcrumb.Category.Value);
            }

            return (breadcrumb.Gender + "/" + url).ToString();

            //var url = breadcrumb.Collection != null ? "collection/" + GenerateSlug(breadcrumb.Collection.Value) : "";
            //url += breadcrumb.Category != null ? "category/" + GenerateSlug(breadcrumb.Category.Value) : "";
            //return (breadcrumb.Gender + "/" + url).ToString();
        }

        public static string GenerateSlug(string code, string name)
        {
            string phrase = string.Format("{0}-{1}", code, name);

            return GenerateSlug(phrase);
        }

        public static string GenerateSlug(string phrase)
        {
            string str = RemoveAccent(phrase).ToLower();
            // invalid chars
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            // convert multiple spaces into one space
            str = Regex.Replace(str, @"\s+", " ").Trim();

            str = Regex.Replace(str, @"\s", "-"); // hyphens
            return str;
        }

        private static string RemoveAccent(string text)
        {
            byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(text);
            return System.Text.Encoding.ASCII.GetString(bytes);
        }
    }
}
