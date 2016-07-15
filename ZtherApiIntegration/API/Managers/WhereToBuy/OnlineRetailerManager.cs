using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZtherApiIntegration.Models.WhereToBuy;

namespace ZtherApiIntegration.API.Managers.WhereToBuy
{
    public class OnlineRetailManager
    {
        public static List<OnlineRetailModel> GetAllOnlineByBrand(string brand)
        {
            using (var client = new LandauPortalWebAPI())
            {
                var countries = client.Retailers.GetAllOnlineByBrand(brand, true);
                return countries.Results.Select(x => new OnlineRetailModel() { ImageUri = x.ImageUri, LandauSiteUrl = x.LandauSiteUrl }).ToList();
            }
        }

        public static List<OnlineRetailModel> GetAllBuyNow(string brand, string productCode)
        {
            using (var client = new LandauPortalWebAPI())
            {
                var retailers = client.Retailers.GetAllBuyNow(brand, productCode);
                return retailers.Results.Select(x => new OnlineRetailModel() { ImageUri = x.ImageUri, LandauSiteUrl = x.SiteUri }).ToList();
            }
        }
    }     
}