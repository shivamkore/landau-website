using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZtherApiIntegration.API.Managers.Seo
{
    public class SeoManager
    {
        public static Models.Seo GetSeoInformation(string brand, string pageName)
        {
            using (var client = new LandauPortalWebAPI())
            {
                var info = client.Seo.GetByBrandAndPageName(brand, pageName);
                return info;
            }
        }
    }
}