using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using ZtherApiIntegration.Models;

namespace ZtherApiIntegration.Common
{
    public static class CommonService
    {
        public static PowerReviewModel GetPowerReviewModel(string productCode)
        {
            var requestUrl = HttpContext.Current.Request.Url;
            var domain = requestUrl.AbsoluteUri.Replace(requestUrl.AbsolutePath, string.Empty);
            var writeReviewUrl = $"{domain}/write-a-review/?";

            return new PowerReviewModel
            {
                ProductCode = productCode,
                Locale = "en_US",
                API_Key = ConfigurationManager.AppSettings["Power-Reviews-API-Key"],
                Merchant_Id = ConfigurationManager.AppSettings["Power-Reviews-Merchant-Id"],
                Merchant_Group_Id = ConfigurationManager.AppSettings["Power-Reviews-Merchant-Group-Id"],
                Write_Review_URL = writeReviewUrl
            };
        }

        public static string ToCleanString(this string value)
        {
            return value.Replace("\n", string.Empty).Replace("\r", string.Empty);
        }
    }
}