using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZtherApiIntegration.Common.GoogleMap
{
    public static class UriHelper
    {
        public static Uri CreateUri(string uriString)
        {
            try
            {
                return new UriBuilder(uriString).Uri;
            }
            catch
            {
                return default(Uri);
            }
        }

        public static bool IsValidHttpOrHttps(string uriString)
        {
            var isValid = false;

            var uri = UriHelper.CreateUri(uriString);

            if (uri != null)
            {
                isValid = (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps) ? true : false;
            }

            return isValid;
        }
    }
}