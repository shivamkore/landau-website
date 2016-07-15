using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZtherApiIntegration.Models;
using ZtherApiIntegration.Models.WhereToBuy;

namespace ZtherApiIntegration.API.Managers.WhereToBuy
{
    public class RetailManager
    {
        private const string RETAILS_FIND_BY_COUNTRY = "RetailsFindByCountry";
        private const string RETAILS_FIND_BY_ZIPCODE = "RetailsFindByZipCode";
        
        public static RetailListModel FindByCountry(string brand, string countryCode, int pageNumber, int pageSize)
        {
            var model = new RetailListModel();
            if (!string.IsNullOrEmpty(countryCode))
            {
                using (var client = new LandauPortalWebAPI())
                {
                    var retailers = client.Retailers.FindByCountry(brand, countryCode, pageNumber, pageSize);
                    model.Retailers = retailers.Results.Select(x => toRetailModel(x)).ToList();

                    model.Pagination.CurrentPage = retailers.Pagination.CurrentPage ?? 0;
                    model.Pagination.PageCount = retailers.Pagination.TotalCount ?? 0;
                    model.Pagination.PageSize = pageSize;

                    model.Seo.PageDescription = retailers.Seo.MetaDescription;
                    model.Seo.PageTitle = retailers.Seo.PageTitle;
                    
                }
            }
            return model;
        }
        

        public static RetailListModel GetByZipCode(HttpSessionStateBase session, string zipCode, bool isDiamond, int pageNum, int pageSize)
        {
            var model = new RetailListModel();
            if (!string.IsNullOrEmpty(zipCode))
            {
                using (var client = new LandauPortalWebAPI())
                {
                    var retailers = client.Retailers.FindByZipcode(zipCode, isDiamond, null, pageNum, pageSize);
                    model.Retailers = retailers.Results.Select(x => toRetailModel(x)).ToList();

                    model.Pagination.CurrentPage = retailers.Pagination.CurrentPage ?? 0;
                    model.Pagination.PageCount = retailers.Pagination.TotalCount ?? 0;
                    model.Pagination.PageSize = pageSize;
                }
            }
            return model;
        }

        public static RetailListModel GetByCityAndState(HttpSessionStateBase session, string city, string state, bool isDiamond, int pageNum, int pageSize)
        {
            var model = new RetailListModel();
            if (!string.IsNullOrEmpty(city) && !string.IsNullOrEmpty(state))
            {
                using (var client = new LandauPortalWebAPI())
                {
                    var retailers = client.Retailers.FindByCityAndState(city, state, isDiamond, null, pageNum, pageSize);
                    model.Retailers = retailers.Results.Select(x => toRetailModel(x)).ToList();

                    model.Pagination.CurrentPage = retailers.Pagination.CurrentPage ?? 0;
                    model.Pagination.PageCount = retailers.Pagination.TotalCount ?? 0;
                    model.Pagination.PageSize = pageSize;

                }
            }
            return model;
        }


        private static RetailModel toRetailModel(Models.Retailer model)
        {
            return new RetailModel()
            {
                StoreName = model.StoreName,
                Address = model.Address,
                City = model.City,
                State = model.State,
                ZipCode = model.Zipcode,
                Country = model.Country,
                WebSite = model.Website,
                LandauSiteUrl = model.LandauSiteUrl,
                SmittenSiteUrl = model.SmittenSiteUrl,
                UrbaneSiteUrl = model.UrbaneSiteUrl,
                Email = model.Email,
                Phone = model.Phone,
                Fax = model.Fax,
                imageUri = model.ImageUri,
                IsDiamond = model.IsDiamond == null ? false : (bool)model.IsDiamond,
                Distance = model.Distance == null ? 0 : Math.Round((double)model.Distance, 2),
                Latitude = model.Latitude == null ? 0 : (double)model.Latitude,
                Longitude = model.Longitude == null ? 0 : (double)model.Longitude,
            };
        }

        public static RetailListModel GetByBrand(string brand)
        {
            var model = new RetailListModel();
            if (!string.IsNullOrEmpty(brand))
            {
                using (var client = new LandauPortalWebAPI())
                {
                    var retailers = client.Retailers.GetAllOnlineByBrand(brand);
                    model.Retailers = retailers.Results.Select(x => toRetailModel(x)).ToList();                    
                }
            }
            return model;
        }

    }
}